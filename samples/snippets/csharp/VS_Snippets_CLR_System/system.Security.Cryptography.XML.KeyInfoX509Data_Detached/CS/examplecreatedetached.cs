// <Snippet1>
//
// This example signs a file specified by a URI 
// using a detached signature. It then verifies  
// the signed XML.
//

using System;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;



class XMLDSIGDetached
{
	
    [STAThread]
    static void Main(string[] args)
    {
        // The URI to sign.
        string resourceToSign = "http://www.microsoft.com";
		
        // The name of the file to which to save the XML signature.
        string XmlFileName = "xmldsig.xml";

        // The name of the X509 certificate
        string Certificate = "microsoft.cer";

        try
        {

            // Generate a signing key. This key should match the certificate.
            RSACryptoServiceProvider Key = new RSACryptoServiceProvider();

            Console.WriteLine("Signing: {0}", resourceToSign);

            // Sign the detached resourceand save the signature in an XML file.
            SignDetachedResource(resourceToSign, XmlFileName, Key, Certificate);

            Console.WriteLine("XML signature was succesfully computed and saved to {0}.", XmlFileName);

        }
        catch(CryptographicException e)
        {
            Console.WriteLine(e.Message);

        }
		
    }

    // <Snippet2>
    // Sign an XML file and save the signature in a new file.
    public static void SignDetachedResource(string URIString, string XmlSigFileName, RSA Key, string Certificate)
    {
        // Create a SignedXml object.
        SignedXml signedXml = new SignedXml();

        // Assign the key to the SignedXml object.
        signedXml.SigningKey = Key;

        // Create a reference to be signed.
        Reference reference = new Reference();

        // Add the passed URI to the reference object.
        reference.Uri = URIString;
		
        // Add the reference to the SignedXml object.
        signedXml.AddReference(reference);

        // Create a new KeyInfo object.
        KeyInfo keyInfo = new KeyInfo();

        // Load the X509 certificate.
        X509Certificate MSCert = X509Certificate.CreateFromCertFile(Certificate);
 
        // Load the certificate into a KeyInfoX509Data object
        // and add it to the KeyInfo object.
        keyInfo.AddClause(new KeyInfoX509Data(MSCert));
  
        // Add the KeyInfo object to the SignedXml object.
        signedXml.KeyInfo = keyInfo;

        // Compute the signature.
        signedXml.ComputeSignature();

        // Get the XML representation of the signature and save
        // it to an XmlElement object.
        XmlElement xmlDigitalSignature = signedXml.GetXml();

        // Save the signed XML document to a file specified
        // using the passed string.
        XmlTextWriter xmltw = new XmlTextWriter(XmlSigFileName, new UTF8Encoding(false));
        xmlDigitalSignature.WriteTo(xmltw);
        xmltw.Close();

    }
    // </Snippet2>
}
// </Snippet1>