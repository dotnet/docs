// <snippet1>
using System;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create an XmlDocument object.
            // <snippet7>
            XmlDocument xmlDoc = new XmlDocument();
            // </snippet7>

            // Load an XML file into the XmlDocument object.
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.Load("test.xml");

            // Open the X.509 "Current User" store in read only mode.
            // <snippet2>
            X509Store store = new X509Store(StoreLocation.CurrentUser);
            // </snippet2>
            // <snippet3>
            store.Open(OpenFlags.ReadOnly);
            // </snippet3>

            // Place all certificates in an X509Certificate2Collection object.
            // <snippet4>
            X509Certificate2Collection certCollection = store.Certificates;
            // </snippet4>

            // <snippet5>
            X509Certificate2 cert = null;

            // Loop through each certificate and find the certificate
            // with the appropriate name.
            foreach (X509Certificate2 c in certCollection)
            {
                if (c.Subject == "CN=XML_ENC_TEST_CERT")
                {
                    cert = c;

                    break;
                }
            }
            // </snippet5>

            if (cert == null)
            {
                throw new CryptographicException("The X.509 certificate could not be found.");
            }

            // Close the store.
            // <snippet6>
            store.Close();
            // </snippet6>

            // Encrypt the "creditcard" element.
            Encrypt(xmlDoc, "creditcard", cert);

            // Save the XML document.
            // <snippet11>
            xmlDoc.Save("test.xml");
            // </snippet11>

            // Display the encrypted XML to the console.
            Console.WriteLine("Encrypted XML:");
            Console.WriteLine();
            Console.WriteLine(xmlDoc.OuterXml);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static void Encrypt(XmlDocument Doc, string ElementToEncrypt, X509Certificate2 Cert)
    {
        // Check the arguments.
        if (Doc == null)
            throw new ArgumentNullException("Doc");
        if (ElementToEncrypt == null)
            throw new ArgumentNullException("ElementToEncrypt");
        if (Cert == null)
            throw new ArgumentNullException("Cert");

        ////////////////////////////////////////////////
        // Find the specified element in the XmlDocument
        // object and create a new XmlElement object.
        ////////////////////////////////////////////////

        // <snippet8>
        XmlElement elementToEncrypt = Doc.GetElementsByTagName(ElementToEncrypt)[0] as XmlElement;
        // </snippet8>
        // Throw an XmlException if the element was not found.
        if (elementToEncrypt == null)
        {
            throw new XmlException("The specified element was not found");
        }

        //////////////////////////////////////////////////
        // Create a new instance of the EncryptedXml class
        // and use it to encrypt the XmlElement with the
        // X.509 Certificate.
        //////////////////////////////////////////////////

        // <snippet9>
        EncryptedXml eXml = new EncryptedXml();

        // Encrypt the element.
        EncryptedData edElement = eXml.Encrypt(elementToEncrypt, Cert);
        // </snippet9>

        ////////////////////////////////////////////////////
        // Replace the element from the original XmlDocument
        // object with the EncryptedData element.
        ////////////////////////////////////////////////////
        // <snippet10>
        EncryptedXml.ReplaceElement(elementToEncrypt, edElement, false);
        // </snippet10>
    }
}
// </snippet1>