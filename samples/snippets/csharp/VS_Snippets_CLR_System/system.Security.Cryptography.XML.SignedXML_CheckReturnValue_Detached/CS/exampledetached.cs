// <Snippet1>
//
// This example signs a file specified by a URI 
// using a detached signature. It then verifies  
// the signed XML.
//

using System;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;



class XMLDSIGDetached
{

    [STAThread]
    static void Main(string[] args)
    {
        WebRequest request = WebRequest.Create("http://www.microsoft.com");
        // If required by the server, set the credentials.
        //request.Credentials = CredentialCache.DefaultCredentials;
        // Get the response.
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        // Display the status.
        Console.WriteLine(response.StatusDescription);
        // Get the stream containing content returned by the server.
        Stream dataStream = response.GetResponseStream();
        // Open the stream using a StreamReader for easy access.
        StreamReader reader = new StreamReader(dataStream);
        // Read the content.
        string responseFromServer = reader.ReadToEnd();
        StreamWriter sw = File.CreateText("C:\\temp\\mscom.htm");
        sw.Write(responseFromServer);
        sw.Close();
        // Cleanup the streams and the response.
        reader.Close();
        dataStream.Close();
        response.Close();

        // The URI to sign.
        string resourceToSign = "file://C:/temp/mscom.htm";

        // The name of the file to which to save the XML signature.
        string XmlFileName = "xmldsig.xml";

        try
        {

            // Generate a DSA signing key.
            DSACryptoServiceProvider DSAKey = new DSACryptoServiceProvider();

            Console.WriteLine("Signing: {0}", resourceToSign);

            // Sign the detached resourceand save the signature in an XML file.
            SignDetachedResource(resourceToSign, XmlFileName, DSAKey);

            Console.WriteLine("XML signature was succesfully computed and saved to {0}.", XmlFileName);

            // Verify the signature of the signed XML.
            Console.WriteLine("Verifying signature...");

            //Verify the XML signature in the XML file.
            bool result = VerifyDetachedSignature(XmlFileName);

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

    }

    // <Snippet2>
    // Sign an XML file and save the signature in a new file.
    public static void SignDetachedResource(string URIString, string XmlSigFileName, DSA DSAKey)
    {
        // Create a SignedXml object.
        SignedXml signedXml = new SignedXml();

        // Assign the DSA key to the SignedXml object.
        signedXml.SigningKey = DSAKey;

        // Create a reference to be signed.
        Reference reference = new Reference();

        // Add the passed URI to the reference object.
        reference.Uri = URIString;

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

        // Save the signed XML document to a file specified
        // using the passed string.
        XmlTextWriter xmltw = new XmlTextWriter(XmlSigFileName, new UTF8Encoding(false));
        xmlDigitalSignature.WriteTo(xmltw);
        xmltw.Close();
    }
    // </Snippet2>
    // <Snippet3>
    // Verify the signature of an XML file and return the result.
    public static Boolean VerifyDetachedSignature(string XmlSigFileName)
    {
        // Create a new XML document.
        XmlDocument xmlDocument = new XmlDocument();

        // Load the passed XML file into the document.
        xmlDocument.Load(XmlSigFileName);

        // Create a new SignedXMl object.
        SignedXml signedXml = new SignedXml();

        // Find the "Signature" node and create a new
        // XmlNodeList object.
        XmlNodeList nodeList = xmlDocument.GetElementsByTagName("Signature");

        // Load the signature node.
        signedXml.LoadXml((XmlElement)nodeList[0]);

        // Check the signature and return the result.
        return signedXml.CheckSignature();
    }
    // </Snippet3>
}
// </Snippet1>