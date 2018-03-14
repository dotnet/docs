//<Snippet2>
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
        //<Snippet1>

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
        //</Snippet1>

        // Ensure the transform is using the proper algorithm.
        //<Snippet3>
        xmlTransform.Algorithm =
            SignedXml.XmlDsigXPathTransformUrl;
        //</Snippet3>

        // Retrieve the XML representation of the current transform.
        //<Snippet9>
        XmlElement xmlInTransform = xmlTransform.GetXml();
        //</Snippet9>

        Console.WriteLine("\nXml representation of the current transform: ");
        Console.WriteLine(xmlInTransform.OuterXml);

        // Retrieve the valid input types for the current transform.
        //<Snippet4>
        Type[] validInTypes = xmlTransform.InputTypes;
        //</Snippet4>

        // Verify the xmlTransform can accept the XMLDocument as an
        // input type.
        for (int i = 0; i < validInTypes.Length; i++)
        {
            if (validInTypes[i] == xmlDoc.GetType())
            {
                // Load the document into the transfrom.
                //<Snippet11>
                xmlTransform.LoadInput(xmlDoc);
                //</Snippet11>

                try
                {
                    // This transform is created for demonstration purposes.
                    XmlDsigXPathTransform secondTransform =
                        new XmlDsigXPathTransform();

                    //<Snippet12>
                    string classDescription = secondTransform.ToString();
                    //</Snippet12>

                    //<Snippet10>
                    xmlTransform.LoadInnerXml(xPathElem.SelectNodes(".")); ;
                    //</Snippet10>
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

        //<Snippet5>
        Type[] validOutTypes = xmlTransform.OutputTypes;
        //</Snippet5>

        for (int i = validOutTypes.Length - 1; i >= 0; i--)
        {
            if (validOutTypes[i] == typeof(System.Xml.XmlDocument))
            {
                try
                {
                    //<Snippet7>
                    Type xmlDocumentType = typeof(System.Xml.XmlDocument);
                    XmlDocument xmlDocumentOutput = (XmlDocument)
                        xmlTransform.GetOutput(xmlDocumentType);
                    //</Snippet7>

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
                //<Snippet8>
                object outputObject = xmlTransform.GetOutput();
                //</Snippet8>
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
        //<Snippet6>
        XmlUrlResolver xmlResolver = new XmlUrlResolver();
        xmlResolver.Credentials =
            System.Net.CredentialCache.DefaultCredentials;

        XmlDsigXPathTransform xmlTransform =
            new XmlDsigXPathTransform();
        xmlTransform.Resolver = xmlResolver;
        //</Snippet6>

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
//</Snippet2>