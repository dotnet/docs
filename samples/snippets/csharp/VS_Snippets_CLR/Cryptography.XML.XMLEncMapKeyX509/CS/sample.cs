//<SNIPPET1>
using System;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {

        // Create an XmlDocument object.
        XmlDocument xmlDoc = new XmlDocument();

        // Load an XML file into the XmlDocument object.
        try
        {
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.Load("test.xml");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        // Create a new X509Certificate2 object by loading
        // an X.509 certificate file.  To use XML encryption 
        // with an X.509 certificate, use an X509Certificate2 
        // object to encrypt, but use a certificate in a certificate
        // store to decrypt.

        // You can create a new test certificate file using the 
        // makecert.exe tool.

        // Create an X509Certificate2 object for encryption.
        X509Certificate2 cert = new X509Certificate2("test.pfx");

        // Put the certificate in certificate store for decryption.  
        X509Store store = new X509Store(StoreLocation.CurrentUser);

        store.Open(OpenFlags.ReadWrite);

        store.Add(cert);

        store.Close();


        try
        {
            // Encrypt the "creditcard" element.
            Encrypt(xmlDoc, "creditcard", cert);

            // Display the encrypted XML to the console.
            Console.WriteLine("Encrypted XML:");
            Console.WriteLine();
            Console.WriteLine(xmlDoc.OuterXml);

            // Decrypt the "creditcard" element.
            Decrypt(xmlDoc);

            // Display the encrypted XML to the console.
            Console.WriteLine();
            Console.WriteLine("Decrypted XML:");
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
        // object and create a new XmlElemnt object.
        ////////////////////////////////////////////////

        XmlElement elementToEncrypt = Doc.GetElementsByTagName(ElementToEncrypt)[0] as XmlElement;

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

        EncryptedXml eXml = new EncryptedXml();

        // Encrypt the element.
        EncryptedData edElement = eXml.Encrypt(elementToEncrypt, Cert);


        ////////////////////////////////////////////////////
        // Replace the element from the original XmlDocument
        // object with the EncryptedData element.
        ////////////////////////////////////////////////////

        EncryptedXml.ReplaceElement(elementToEncrypt, edElement, false);

    }

    public static void Decrypt(XmlDocument Doc)
    {
        // Check the arguments.  
        if (Doc == null)
            throw new ArgumentNullException("Doc");

        // Create a new EncryptedXml object.
        EncryptedXml exml = new EncryptedXml(Doc);

        // Decrypt the XML document.
        exml.DecryptDocument();

    }


}
//</SNIPPET1>