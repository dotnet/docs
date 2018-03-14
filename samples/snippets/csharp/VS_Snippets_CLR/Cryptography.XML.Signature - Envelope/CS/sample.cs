//<SNIPPET1>
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
        // Generate a signing key.
       RSACryptoServiceProvider Key = new RSACryptoServiceProvider();

       try
       {

           // Sign an XML file and save the signature to a 
           // new file.
           SignXmlFile("Test.xml", "SignedExample.xml", Key);
           Console.WriteLine("XML file signed.");

           // Verify the signature of the signed XML.
           Console.WriteLine("Verifying signature...");

           bool result = VerifyXmlFile("SignedExample.xml");

           // Display the results of the signature verification to 
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
           // Clear resources associated with the 
           // RSACryptoServiceProvider.
           Key.Clear();
       }
   }

    // Sign an XML file and save the signature in a new file.
    public static void SignXmlFile(string FileName, string SignedFileName, RSA Key)
    {
        // Check the arguments.  
        if (FileName == null)
            throw new ArgumentNullException("FileName");
        if (SignedFileName == null)
            throw new ArgumentNullException("SignedFileName");
        if (Key == null)
            throw new ArgumentNullException("Key");


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

        // Get the signature object from the SignedXml object.
        Signature XMLSignature = signedXml.Signature;

        // Create a reference to be signed.  Pass "" 
        // to specify that all of the current XML
        // document should be signed.
        Reference reference = new Reference("");

        // Add an enveloped transformation to the reference.
        XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
        reference.AddTransform(env);

        // Add the Reference object to the Signature object.
        XMLSignature.SignedInfo.AddReference(reference);

        // Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate).
        KeyInfo keyInfo = new KeyInfo();
        keyInfo.AddClause(new RSAKeyValue((RSA)Key));

        // Add the KeyInfo object to the Reference object.
        XMLSignature.KeyInfo = keyInfo;

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
    // Verify the signature of an XML file and return the result.
    public static Boolean VerifyXmlFile(String Name)
    {
        // Check the arguments.  
        if (Name == null)
            throw new ArgumentNullException("Name");

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
}
//</SNIPPET1>