using System;
using System.IO;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;

class Class1
{
    [STAThread]
    static void Main(string[] args)
    {
        XmlDocument productsXml = LoadProducts();
        XmlNodeList xsltNodeList = GetXsltAsNodeList();
        TransformDoc(productsXml, xsltNodeList);

        // Use XmlDsigXsltTransform to resolve a Uri.
        Uri baseUri = new Uri("http://www.contoso.com");
        string relativeUri = "xml";
        Uri absoluteUri = ResolveUris(baseUri, relativeUri);

        Console.WriteLine("This sample completed successfully; " +
            "press Enter to exit.");
        Console.ReadLine();
    }

    private static void TransformDoc(
        XmlDocument xmlDoc, 
        XmlNodeList xsltNodeList)
    {
        try 
        {
            // Construct a new XmlDsigXsltTransform.
            XmlDsigXsltTransform xmlTransform = 
                new XmlDsigXsltTransform();

            // Load the Xslt tranform as a node list.
            xmlTransform.LoadInnerXml(xsltNodeList);

            // Load the Xml document to perform the tranform on.
            XmlNamespaceManager namespaceManager;
            namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);

            XmlNodeList productsNodeList;
            productsNodeList = xmlDoc.SelectNodes("//.", namespaceManager);

            xmlTransform.LoadInput(productsNodeList);

            // Retrieve the output from the transform.
            Stream outputStream = (Stream)
                xmlTransform.GetOutput(typeof(System.IO.Stream));

            // Read the output stream into a stream reader.
            StreamReader streamReader =
                new StreamReader(outputStream);

            // Read the stream into a string.
            string outputMessage = streamReader.ReadToEnd();

            // Close the streams.
            outputStream.Close();
            streamReader.Close();

            // Display to the console the Xml before and after
            // encryption.
            Console.WriteLine("\nResult of transformation: " + outputMessage);
            ShowTransformProperties(xmlTransform);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Caught exception in TransformDoc method: " + 
                ex.ToString());
        }
    }
    
    private static XmlNodeList GetXsltAsNodeList()
    {
        string transformXml = "<xsl:transform version='1.0' ";
        transformXml += "xmlns:xsl='http://www.w3.org/1999/XSL/Transform'>";
        transformXml += "<xsl:template match='products'>";
        transformXml += "<table><tr><td>ProductId</td><td>Name</td></tr>";
        transformXml += "<xsl:apply-templates/></table></xsl:template>";
        transformXml += "<xsl:template match='product'><tr>";
        transformXml += "<xsl:apply-templates/></tr></xsl:template>";
        transformXml += "<xsl:template match='productid'><td>";
        transformXml += "<xsl:apply-templates/></td></xsl:template>";
        transformXml += "<xsl:template match='description'><td>";
        transformXml += "<xsl:apply-templates/></td></xsl:template>";
        transformXml += "</xsl:transform>";

        Console.WriteLine("\nCreated the following Xslt tranform:");
        Console.WriteLine(transformXml);

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(transformXml);
        return xmlDoc.GetElementsByTagName("xsl:transform");
    }

    // Encrypt the text in the specified XmlDocument.
    private static void ShowTransformProperties(
        XmlDsigXsltTransform xmlTransform)
    {
        string classDescription = xmlTransform.ToString();
        Console.WriteLine("\n** Summary for " + classDescription + " **");

        // Retrieve the XML representation of the current transform.
        XmlElement xmlInTransform = xmlTransform.GetXml();
        Console.WriteLine("Xml representation of the current transform:\n" +
            xmlInTransform.OuterXml);

        // Ensure the transform is using the proper algorithm.
        xmlTransform.Algorithm =
            SignedXml.XmlDsigXsltTransformUrl;
        Console.WriteLine("Algorithm used: " + classDescription);

        // Retrieve the valid input types for the current transform.
        Type[] validInTypes = xmlTransform.InputTypes;
        Console.WriteLine("Transform accepts the following inputs:");
        for (int i=0; i<validInTypes.Length; i++)
        {
            Console.WriteLine("\t" + validInTypes[i].ToString());
        }

        Type[] validOutTypes = xmlTransform.OutputTypes;
        Console.WriteLine("Transform outputs in the following types:");
        for (int i=validOutTypes.Length-1; i >= 0; i--)
        {
            Console.WriteLine("\t " + validOutTypes[i].ToString());

            if (validOutTypes[i] == typeof(object))
            {
                object outputObject = xmlTransform.GetOutput();
            }
        }
    }

    // Create an XML document describing various products.
    private static XmlDocument LoadProducts()
    {
        string contosoProducts = "<?xml version='1.0'?>";
        contosoProducts += "<products>";
        contosoProducts += "<product><productid>1</productid>";
        contosoProducts += "<description>Widgets</description></product>";
        contosoProducts += "<product><productid>2</productid>";
        contosoProducts += "<description>Gadgits</description></product>";
        contosoProducts += "</products>";

        Console.WriteLine(
            "\nCreated the following Xml document for tranformation:");
        Console.WriteLine(contosoProducts);

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(contosoProducts);
        return xmlDoc;
    }

    // Resolve the specified base and relative Uri's .
    private static Uri ResolveUris(Uri baseUri, string relativeUri)
    {
        XmlUrlResolver xmlResolver = new XmlUrlResolver();
        xmlResolver.Credentials = 
            System.Net.CredentialCache.DefaultCredentials;

        XmlDsigXsltTransform xmlTransform =
            new XmlDsigXsltTransform();
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
//
// This sample produces the following output:
//
// Created the following Xml document for tranformation:
// <?xml version='1.0'?><products><product><productid>1</productid><descriptio
// n>Widgets</description></product><product><productid>2</productid><descript
// ion>Gadgits</description></product></products>
// 
// Created the following Xslt tranform:
// <xsl:transform version='1.0' xmlns:xsl='http://www.w3.org/1999/XSL/Transfor
// m'><xsl:template match='products'><table><tr><td>ProductId</td><td>Name</td
// ></tr><xsl:apply-templates/></table></xsl:template><xsl:template match='pro
// duct'><tr><xsl:apply-templates/></tr></xsl:template><xsl:emplate match='pro
// ductid'><td><xsl:apply-templates/></td></xsl:template><xsl:template match='
// description'><td><xsl:apply-templates/></td></xsl:template></xsl:transform>
// 
// Result of transformation: <table><tr><td>ProductId</td><td>Name</td></tr><t
// r><td>1</td><td>Widgets</td></tr><tr><td>2</td><td>Gadgits</td></tr></table
// >
//
// ** Summary for System.Security.Cryptography.Xml.XmlDsigXsltTransform **
// Xml representation of the current transform:
// <Transform Algorithm="http://www.w3.org/TR/1999/REC-xslt-19991116" xmlns="h
// ttp://www.w3.org/2000/09/xmldsig#"><xsl:transform version="1.0" xmlns:xsl="
// http://www.w3.org/1999/XSL/Transform"><xsl:template match="products"><table
//  xmlns=""><tr><td>ProductId</td><td>Name</td></tr><xsl:apply-templates /></
// table></xsl:template><xsl:template match="product"><tr xmlns=""><xsl:apply-
// templates /></tr></xsl:template><xsl:template match="productid"><td xmlns="
// "><xsl:apply-templates /></td></xsl:template><xsl:template match="descripti
// on"><td xmlns=""><xsl:apply-templates /></td></xsl:template></xsl:transform
// ></Transform>
// Algorithm used: System.Security.Cryptography.Xml.XmlDsigXsltTransform
// Transform accepts the following inputs:
// System.IO.Stream
// System.Xml.XmlDocument
// System.Xml.XmlNodeList
// Transform outputs in the following types:
// System.IO.Stream
// 
// Resolved the base Uri and relative Uri to the following:
// http://www.contoso.com/xml
// This sample completed successfully; press Enter to exit.