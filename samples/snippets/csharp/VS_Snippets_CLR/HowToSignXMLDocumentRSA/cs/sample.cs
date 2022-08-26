// <snippet1>
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Xml;

public class SignXML
{
    public static void Main(String[] args)
    {
        try
        {
            // Create a new CspParameters object to specify
            // a key container.
            // <snippet2>
            CspParameters cspParams = new()
            {
                KeyContainerName = "XML_DSIG_RSA_KEY"
            };
            // </snippet2>

            // Create a new RSA signing key and save it in the container.
            // <snippet3>
            RSACryptoServiceProvider rsaKey = new(cspParams);
            // </snippet3>

            // Create a new XML document.
            // <snippet4>
            XmlDocument xmlDoc = new()
            {
                // Load an XML file into the XmlDocument object.
                PreserveWhitespace = true
            };
            xmlDoc.Load("test.xml");
            // </snippet4>

            // Sign the XML document.
            SignXml(xmlDoc, rsaKey);

            Console.WriteLine("XML file signed.");

            // Save the document.
            // <snippet13>
            xmlDoc.Save("test.xml");
            // </snippet13>
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    // Sign an XML file.
    // This document cannot be verified unless the verifying
    // code has the key with which it was signed.
    public static void SignXml(XmlDocument xmlDoc, RSA rsaKey)
    {
        // Check arguments.
        if (xmlDoc == null)
            throw new ArgumentException(null, nameof(xmlDoc));
        if (rsaKey == null)
            throw new ArgumentException(null, nameof(rsaKey));

        // Create a SignedXml object.
        // <snippet5>
        SignedXml signedXml = new(xmlDoc)
        {
            // </snippet5>

            // Add the key to the SignedXml document.
            // <snippet6>
            SigningKey = rsaKey
        };
        // </snippet6>

        // <snippet7>
        // Create a reference to be signed.
        Reference reference = new()
        {
            Uri = ""
        };
        // </snippet7>

        // Add an enveloped transformation to the reference.
        // <snippet8>
        XmlDsigEnvelopedSignatureTransform env = new();
        reference.AddTransform(env);
        // </snippet8>

        // Add the reference to the SignedXml object.
        // <snippet9>
        signedXml.AddReference(reference);
        // </snippet9>

        // Compute the signature.
        // <snippet10>
        signedXml.ComputeSignature();
        // </snippet10>

        // Get the XML representation of the signature and save
        // it to an XmlElement object.
        // <snippet11>
        XmlElement xmlDigitalSignature = signedXml.GetXml();
        // </snippet11>

        // Append the element to the XML document.
        // <snippet12>
        xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));
        // </snippet12>
    }
}
// </snippet1>
