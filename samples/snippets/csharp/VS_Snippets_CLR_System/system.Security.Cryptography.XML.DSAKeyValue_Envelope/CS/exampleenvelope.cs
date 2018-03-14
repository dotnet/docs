// <Snippet1>
//
// This example signs an XML file using an
// envelope signature. It then verifies the 
// signed XML.
//
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;

public class SignVerifyEnvelope
{

    public static void Main(String[] args)
    {
        try
        {
            // Generate a DSA signing key.
            DSACryptoServiceProvider DSAKey = new DSACryptoServiceProvider();

            // Create an XML file to sign.
            CreateSomeXml("Example.xml");
            Console.WriteLine("New XML file created."); 

            // Sign the XML that was just created and save it in a 
            // new file.
            SignXmlFile("Example.xml", "SignedExample.xml", DSAKey);
            Console.WriteLine("XML file signed."); 

            // Verify the signature of the signed XML.
            Console.WriteLine("Verifying signature...");
            bool result = VerifyXmlFile("SignedExample.xml");

            // Display the results of the signature verification to \
            // the console.
            if(result)
            {
                Console.WriteLine("The XML signature is valid.");
            }
            else
            {
                Console.WriteLine("The XML signature is not valid.");
            }
        }
        catch(CryptographicException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    // <Snippet2>
    // Sign an XML file and save the signature in a new file.
    public static void SignXmlFile(string FileName, string SignedFileName, DSA DSAKey)
    {
        // Create a new XML document.
        XmlDocument doc = new XmlDocument();

        // Format the document to ignore white spaces.
        doc.PreserveWhitespace = false;

        // Load the passed XML file using it's name.
        doc.Load(new XmlTextReader(FileName));

        // Create a SignedXml object.
        SignedXml signedXml = new SignedXml(doc);

        // Add the DSA key to the SignedXml document. 
        signedXml.SigningKey = DSAKey;

        // Create a reference to be signed.
        Reference reference = new Reference();
        reference.Uri = "";

        // Add a transformation to the reference.
        Transform trns = new XmlDsigC14NTransform();
        reference.AddTransform(trns);

        // Add an enveloped transformation to the reference.
        XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
        reference.AddTransform(env);

        // Add the reference to the SignedXml object.
        signedXml.AddReference(reference);

		
        // Add a DSAKeyValue to the KeyInfo (optional; helps recipient find key to validate).
        KeyInfo keyInfo = new KeyInfo();
        keyInfo.AddClause(new DSAKeyValue((DSA)DSAKey));
        signedXml.KeyInfo = keyInfo;

        // Compute the signature.
        signedXml.ComputeSignature();

        // Get the XML representation of the signature and save
        // it to an XmlElement object.
        XmlElement xmlDigitalSignature = signedXml.GetXml();

        // Append the element to the XML document.
        doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));
		
		
        if (doc.FirstChild is XmlDeclaration)  
        {
            doc.RemoveChild(doc.FirstChild);
        }

        // Save the signed XML document to a file specified
        // using the passed string.
        XmlTextWriter xmltw = new XmlTextWriter(SignedFileName, new UTF8Encoding(false));
        doc.WriteTo(xmltw);
        xmltw.Close();
    }
    // </Snippet2>
    // <Snippet3>
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
    // </Snippet3>

    // Create example data to sign.
    public static void CreateSomeXml(string FileName)
    {
        // Create a new XmlDocument object.
        XmlDocument document = new XmlDocument();

        // Create a new XmlNode object.
        XmlNode  node = document.CreateNode(XmlNodeType.Element, "", "MyElement", "samples");
		
        // Add some text to the node.
        node.InnerText = "Example text to be signed.";

        // Append the node to the document.
        document.AppendChild(node);

        // Save the XML document to the file name specified.
        XmlTextWriter xmltw = new XmlTextWriter(FileName, new UTF8Encoding(false));
        document.WriteTo(xmltw);
        xmltw.Close();
    }
}
// </Snippet1>