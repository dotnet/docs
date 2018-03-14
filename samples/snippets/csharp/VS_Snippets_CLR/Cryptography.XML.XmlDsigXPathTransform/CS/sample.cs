//<SNIPPET1> 
//
// This example signs an XML file using an
// envelope signature. It then verifies the 
// signed XML.
//
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;

public class SignVerifyEnvelope
{

    public static void Main(String[] args)
    {
        // Generate a signing key.
        RSACryptoServiceProvider Key = new RSACryptoServiceProvider();

        try
        {
            // Create an XML file to sign.
            CreateSomeXml("Example.xml");
            Console.WriteLine("New XML file created.");

            // Sign the XML that was just created and save it in a 
            // new file.
            SignXmlFile("Example.xml", "SignedExample.xml", Key, "ancestor-or-self::TempElement");
            Console.WriteLine("XML file signed.");

            // Verify the signature of the signed XML.
            Console.WriteLine("Verifying signature...");
            bool result = VerifyXmlFile("SignedExample.xml");

            // Display the results of the signature verification to \
            // the console.
            if (result)
            {
                Console.WriteLine("The XML signature is valid.");
            }
            else
            {
                Console.WriteLine("The XML signature is not valid.");
            }
        }
        catch (CryptographicException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Key.Clear();
        }
    }

    // Sign an XML file and save the signature in a new file.
    public static void SignXmlFile(string FileName, string SignedFileName, RSA Key, string XPathString)
    {
        // Create a new XML document.
        XmlDocument doc = new XmlDocument();

        // Format the document to ignore white spaces.
        doc.PreserveWhitespace = false;

        // Load the passed XML file using it's name.
        doc.Load(new XmlTextReader(FileName));

        // Create a SignedXml object.
        SignedXml signedXml = new SignedXml(doc);

        // Add the key to the SignedXml document. 
        signedXml.SigningKey = Key;

        // Create a reference to be signed.
        Reference reference = new Reference();
        reference.Uri = "";

        // Create an XmlDsigXPathTransform object using 
        // the helper method 'CreateXPathTransform' defined
        // later in this sample.

        XmlDsigXPathTransform XPathTransform = CreateXPathTransform(XPathString);
        
        // Add the transform to the reference.
        reference.AddTransform(XPathTransform);

        // Add the reference to the SignedXml object.
        signedXml.AddReference(reference);

        // Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate).
        KeyInfo keyInfo = new KeyInfo();
        keyInfo.AddClause(new RSAKeyValue((RSA)Key));
        signedXml.KeyInfo = keyInfo;

        // Compute the signature.
        signedXml.ComputeSignature();

        // Get the XML representation of the signature and save
        // it to an XmlElement object.
        XmlElement xmlDigitalSignature = signedXml.GetXml();

        // Append the element to the XML document.
        doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));

        // Save the signed XML document to a file specified
        // using the passed string.
        XmlTextWriter xmltw = new XmlTextWriter(SignedFileName, new UTF8Encoding(false));
        doc.WriteTo(xmltw);
        xmltw.Close();
    }
    // Verify the signature of an XML file and return the result.
    public static Boolean VerifyXmlFile(String Name)
    {
        // Create a new XML document.
        XmlDocument xmlDocument = new XmlDocument();

        // Format using white spaces.
        xmlDocument.PreserveWhitespace = true;

        // Load the passed XML file into the document. 
        xmlDocument.Load(Name);

        // Create a new SignedXml object and pass it
        // the XML document class.
        SignedXml signedXml = new SignedXml(xmlDocument);

        // Find the "Signature" node and create a new
        // XmlNodeList object.
        XmlNodeList nodeList = xmlDocument.GetElementsByTagName("Signature");

        // Load the signature node.
        signedXml.LoadXml((XmlElement)nodeList[0]);

        // Check the signature and return the result.
        return signedXml.CheckSignature();

    }

    // Create the XML that represents the transform.
    private static XmlDsigXPathTransform CreateXPathTransform(string XPathString)
    {
        // Create a new XMLDocument object.
        XmlDocument doc = new XmlDocument();

        // Create a new XmlElement.
        XmlElement xPathElem = doc.CreateElement("XPath");

        // Set the element text to the value
        // of the XPath string.
        xPathElem.InnerText = XPathString;

        // Create a new XmlDsigXPathTransform object.
        XmlDsigXPathTransform xForm = new XmlDsigXPathTransform();

        // Load the XPath XML from the element. 
        xForm.LoadInnerXml(xPathElem.SelectNodes("."));

        // Return the XML that represents the transform.
        return xForm;
    }

    // Create example data to sign.
    public static void CreateSomeXml(string FileName)
    {
        // Create a new XmlDocument object.
        XmlDocument document = new XmlDocument();

        // Create a new XmlNode object.
        XmlNode node = document.CreateNode(XmlNodeType.Element, "", "MyXML", "Don't_Sign");

        // Append the node to the document.
        document.AppendChild(node);

        // Create a new XmlNode object.
        XmlNode subnode = document.CreateNode(XmlNodeType.Element, "", "TempElement", "Sign");

        // Add some text to the node.
        subnode.InnerText = "Here is some data to sign.";

        // Append the node to the document.
        document.DocumentElement.AppendChild(subnode);

        // Save the XML document to the file name specified.
        XmlTextWriter xmltw = new XmlTextWriter(FileName, new UTF8Encoding(false));
        document.WriteTo(xmltw);
        xmltw.Close();
    }
}
//</SNIPPET1>