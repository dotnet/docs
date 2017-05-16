// <Snippet1>
//
// This example signs an XML file using an
// envelope signature. It then verifies the 
// signed XML.
//
// You must have a certificate with a subject name
// of "CN=XMLDSIG_Test" in the "My" certificate store. 
//
// Run the following command to create a certificate
// and place it in the store.
// makecert -r -pe -n "CN=XMLDSIG_Test" -b 01/01/2005 -e 01/01/2010 -sky signing -ss my

using System;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

public class SignVerifyEnvelope
{

    public static void Main(String[] args)
    {

        string Certificate = "CN=XMLDSIG_Test";

        try
        {

            // Create an XML file to sign.
            CreateSomeXml("Example.xml");
            Console.WriteLine("New XML file created.");

            // Sign the XML that was just created and save it in a 
            // new file.
            SignXmlFile("Example.xml", "SignedExample.xml", Certificate);
            Console.WriteLine("XML file signed.");

            if (VerifyXmlFile("SignedExample.xml", Certificate))
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
    }

    // <Snippet2>
    // Sign an XML file and save the signature in a new file.
    public static void SignXmlFile(string FileName, string SignedFileName, string SubjectName)
    {
        if (null == FileName)
            throw new ArgumentNullException("FileName");
        if (null == SignedFileName)
            throw new ArgumentNullException("SignedFileName");
        if (null == SubjectName)
            throw new ArgumentNullException("SubjectName");

        // Load the certificate from the certificate store.
        X509Certificate2 cert = GetCertificateBySubject(SubjectName);

        // Create a new XML document.
        XmlDocument doc = new XmlDocument();

        // Format the document to ignore white spaces.
        doc.PreserveWhitespace = false;

        // Load the passed XML file using it's name.
        doc.Load(new XmlTextReader(FileName));

        // Create a SignedXml object.
        SignedXml signedXml = new SignedXml(doc);

        // Add the key to the SignedXml document. 
        signedXml.SigningKey = cert.PrivateKey;

        // Create a reference to be signed.
        Reference reference = new Reference();
        reference.Uri = "";

        // Add an enveloped transformation to the reference.
        XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
        reference.AddTransform(env);

        // Add the reference to the SignedXml object.
        signedXml.AddReference(reference);

        // Create a new KeyInfo object.
        KeyInfo keyInfo = new KeyInfo();

        // Load the certificate into a KeyInfoX509Data object
        // and add it to the KeyInfo object.
        keyInfo.AddClause(new KeyInfoX509Data(cert));

        // Add the KeyInfo object to the SignedXml object.
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
        using (XmlTextWriter xmltw = new XmlTextWriter(SignedFileName, new UTF8Encoding(false)))
        {
            doc.WriteTo(xmltw);
            xmltw.Close();
        }

    }
    // </Snippet2>

    // Verify the signature of an XML file against an asymetric 
    // algorithm and return the result.
    public static Boolean VerifyXmlFile(String FileName, String CertificateSubject)
    {
        // Check the args.
        if (null == FileName)
            throw new ArgumentNullException("FileName");
        if (null == CertificateSubject)
            throw new ArgumentNullException("CertificateSubject");

        // Load the certificate from the store.
        X509Certificate2 cert = GetCertificateBySubject(CertificateSubject);

        // Create a new XML document.
        XmlDocument xmlDocument = new XmlDocument();

        // Load the passed XML file into the document. 
        xmlDocument.Load(FileName);

        // Create a new SignedXml object and pass it
        // the XML document class.
        SignedXml signedXml = new SignedXml(xmlDocument);

        // Find the "Signature" node and create a new
        // XmlNodeList object.
        XmlNodeList nodeList = xmlDocument.GetElementsByTagName("Signature");

        // Load the signature node.
        signedXml.LoadXml((XmlElement)nodeList[0]);

        // Check the signature and return the result.
        return signedXml.CheckSignature(cert, true);

    }


    public static X509Certificate2 GetCertificateBySubject(string CertificateSubject)
    {
        // Check the args.
        if (null == CertificateSubject)
            throw new ArgumentNullException("CertificateSubject");


        // Load the certificate from the certificate store.
        X509Certificate2 cert = null;

        X509Store store = new X509Store("My", StoreLocation.CurrentUser);

        try
        {
            // Open the store.
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

            // Get the certs from the store.
            X509Certificate2Collection CertCol = store.Certificates;

            // Find the certificate with the specified subject.
            foreach (X509Certificate2 c in CertCol)
            {
                if (c.Subject == CertificateSubject)
                {
                    cert = c;
                    break;
                }
            }

            // Throw an exception of the certificate was not found.
            if (cert == null)
            {
                throw new CryptographicException("The certificate could not be found.");
            }
        }
        finally
        {
            // Close the store even if an exception was thrown.
            store.Close();
        }
        
        return cert;
    }

    // Create example data to sign.
    public static void CreateSomeXml(string FileName)
    {
        // Check the args.
        if (null == FileName)
            throw new ArgumentNullException("FileName");

        // Create a new XmlDocument object.
        XmlDocument document = new XmlDocument();

        // Create a new XmlNode object.
        XmlNode node = document.CreateNode(XmlNodeType.Element, "", "MyElement", "samples");

        // Add some text to the node.
        node.InnerText = "Example text to be signed.";

        // Append the node to the document.
        document.AppendChild(node);

        // Save the XML document to the file name specified.
        using (XmlTextWriter xmltw = new XmlTextWriter(FileName, new UTF8Encoding(false)))
        {
            document.WriteTo(xmltw);

            xmltw.Close();
        }
    }
}
// This code example displays the following to the console:
//
// New XML file created.
// XML file signed.
// The XML signature is valid.
// </Snippet1>