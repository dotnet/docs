using System;
using System.IO;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;

class Class1
{
    [STAThread]
    static void Main(string[] args)
    {
        // Encrypt a sample XML string.
        XmlDocument productsXml = LoadProducts();
        ShowTransformProperties(productsXml);

        // Encrypt an XPath Xml string.
        XmlDocument transformXml = LoadTransformByXml();
        ShowTransformProperties(transformXml);

        // Use XmlDsigXPathTransform to resolve a Uri.
        Uri baseUri = new Uri("http://www.contoso.com");
        string relativeUri = "xml";
        Uri absoluteUri = ResolveUris(baseUri, relativeUri);

        Console.WriteLine("This sample completed successfully; " +
            "press Enter to exit.");
        Console.ReadLine();
    }

    // Encrypt the text in the specified XmlDocument.
    private static void ShowTransformProperties(XmlDocument xmlDoc)
    {

        // Create a new XMLDocument object.
        XmlDocument doc = new XmlDocument();

        // Create a new XmlElement.
        XmlElement xPathElem = doc.CreateElement("XPath");

        // Set the element text to the value
        // of the XPath string.
        xPathElem.InnerText = "ancestor-or-self::PRODUCTS";

        // Create a new XmlDsigXPathTransform object.
        XmlDsigXPathTransform xmlTransform = new XmlDsigXPathTransform();

        // Load the XPath XML from the element. 
        xmlTransform.LoadInnerXml(xPathElem.SelectNodes("."));

        // Ensure the transform is using the proper algorithm.
        xmlTransform.Algorithm =
            SignedXml.XmlDsigXPathTransformUrl;

        // Retrieve the XML representation of the current transform.
        XmlElement xmlInTransform = xmlTransform.GetXml();

        Console.WriteLine("\nXml representation of the current transform: ");
        Console.WriteLine(xmlInTransform.OuterXml);

        // Retrieve the valid input types for the current transform.
        Type[] validInTypes = xmlTransform.InputTypes;

        // Verify the xmlTransform can accept the XMLDocument as an
        // input type.
        for (int i = 0; i < validInTypes.Length; i++)
        {
            if (validInTypes[i] == xmlDoc.GetType())
            {
                // Load the document into the transfrom.
                xmlTransform.LoadInput(xmlDoc);

                try
                {
                    // This transform is created for demonstration purposes.
                    XmlDsigXPathTransform secondTransform =
                        new XmlDsigXPathTransform();

                    string classDescription = secondTransform.ToString();

                    xmlTransform.LoadInnerXml(xPathElem.SelectNodes(".")); ;
                }
                catch (CryptographicException)
                {
                    Console.WriteLine("Caught exception while trying to " +
                        "load the specified Xml document. The document " +
                        "requires an XPath element to be valid.");
                }
                break;
            }
        }

        Type[] validOutTypes = xmlTransform.OutputTypes;

        for (int i = validOutTypes.Length - 1; i >= 0; i--)
        {
            if (validOutTypes[i] == typeof(System.Xml.XmlDocument))
            {
                try
                {
                    Type xmlDocumentType = typeof(System.Xml.XmlDocument);
                    XmlDocument xmlDocumentOutput = (XmlDocument)
                        xmlTransform.GetOutput(xmlDocumentType);

                    // Display to the console the Xml before and after
                    // encryption.
                    Console.WriteLine("Result of the GetOutput method call" +
                        " from the current transform: " +
                        xmlDocumentOutput.OuterXml);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected exception caught: " +
                        ex.ToString());
                }

                break;
            }
            else if (validOutTypes[i] == typeof(System.Xml.XmlNodeList))
            {
                try
                {
                    Type xmlNodeListType = typeof(System.Xml.XmlNodeList);
                    XmlNodeList xmlNodes = (XmlNodeList)
                        xmlTransform.GetOutput(xmlNodeListType);

                    // Display to the console the Xml before and after
                    // encryption.
                    Console.WriteLine("Encoding the following message: " +
                        xmlDoc.InnerText);

                    Console.WriteLine("Nodes of the XmlNodeList retrieved " +
                        "from GetOutput:");
                    for (int j = 0; j < xmlNodes.Count; j++)
                    {
                        Console.WriteLine("Node " + j +
                            " has the following name: " +
                            xmlNodes.Item(j).Name +
                            " and the following InnerXml: " +
                            xmlNodes.Item(j).InnerXml);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected exception caught: " +
                        ex.ToString());
                }

                break;
            }
            else
            {
                object outputObject = xmlTransform.GetOutput();
            }
        }
    }

    // Create an XML document for the dsig namespace.
    private static XmlDocument LoadTransformByXml()
    {
        XmlDocument xmlDoc = new XmlDocument();

        string transformXml = "<Signature><Reference URI=''><Transforms>";
        transformXml += "<Transform><XPath ";
        transformXml += "xmlns:dsig='http://www.w3.org/2000/09/xmldsig#'>";
        transformXml += "not(ancestor-or-self::dsig:Signature)";
        transformXml += "</XPath></Transform>";
        transformXml += "</Transforms></Reference></Signature>";

        xmlDoc.LoadXml(transformXml);
        return xmlDoc;
    }

    // Create an XML document describing various products.
    private static XmlDocument LoadProducts()
    {
        XmlDocument xmlDoc = new XmlDocument();

        string contosoProducts = "<PRODUCTS>";
        contosoProducts += "<PRODUCT><ID>123</ID>";
        contosoProducts += "<DESCRIPTION>Router</DESCRIPTION></PRODUCT>";
        contosoProducts += "<PRODUCT><ID>456</ID>";
        contosoProducts += "<DESCRIPTION>Keyboard</DESCRIPTION></PRODUCT>";
        contosoProducts += "<PRODUCT><ID>789</ID>";
        contosoProducts += "<DESCRIPTION>Monitor</DESCRIPTION></PRODUCT>";
        contosoProducts += "</PRODUCTS>";

        xmlDoc.LoadXml(contosoProducts);
        return xmlDoc;
    }

    // Resolve the specified base and relative Uri's .
    private static Uri ResolveUris(Uri baseUri, string relativeUri)
    {
        XmlUrlResolver xmlResolver = new XmlUrlResolver();
        xmlResolver.Credentials =
            System.Net.CredentialCache.DefaultCredentials;

        XmlDsigXPathTransform xmlTransform =
            new XmlDsigXPathTransform();
        xmlTransform.Resolver = xmlResolver;

        Uri absoluteUri = xmlResolver.ResolveUri(baseUri, relativeUri);

        if (absoluteUri != null)
        {
            Console.WriteLine(
                "\nResolved the base Uri and relative Uri to the following:");
            Console.WriteLine(absoluteUri.ToString());
        }
        else
        {
            Console.WriteLine(
                "Unable to resolve the base Uri and relative Uri");
        }
        return absoluteUri;
    }
}