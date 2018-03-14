//<SNIPPET1>
using System;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;

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
        }

        // Create a new TripleDES key. 
        TripleDESCryptoServiceProvider tDESkey = new TripleDESCryptoServiceProvider();


        try
        {
            // Encrypt the "creditcard" element.
            Encrypt(xmlDoc, "creditcard", tDESkey, "tDesKey");

            // Display the encrypted XML to the console.
            Console.WriteLine("Encrypted XML:");
            Console.WriteLine();
            Console.WriteLine(xmlDoc.OuterXml);

            // Decrypt the "creditcard" element.
            Decrypt(xmlDoc, tDESkey, "tDesKey");

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
        finally
        {
            // Clear the TripleDES key.
            tDESkey.Clear();
        }

    }

    public static void Encrypt(XmlDocument Doc, string ElementToEncrypt, SymmetricAlgorithm Alg, string KeyName)
    {
        // Check the arguments.  
        if (Doc == null)
            throw new ArgumentNullException("Doc");
        if (ElementToEncrypt == null)
            throw new ArgumentNullException("ElementToEncrypt");
        if (Alg == null)
            throw new ArgumentNullException("Alg");

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
        // symmetric key.
        //////////////////////////////////////////////////

        EncryptedXml eXml = new EncryptedXml();

        // Add the key mapping.
        eXml.AddKeyNameMapping(KeyName, Alg);

        // Encrypt the element.
        EncryptedData edElement = eXml.Encrypt(elementToEncrypt, KeyName);


        ////////////////////////////////////////////////////
        // Replace the element from the original XmlDocument
        // object with the EncryptedData element.
        ////////////////////////////////////////////////////

        EncryptedXml.ReplaceElement(elementToEncrypt, edElement, false);

    }

    public static void Decrypt(XmlDocument Doc, SymmetricAlgorithm Alg, string KeyName)
    {
        // Check the arguments.  
        if (Doc == null)
            throw new ArgumentNullException("Doc");
        if (Alg == null)
            throw new ArgumentNullException("Alg");
        if (KeyName == null)
            throw new ArgumentNullException("KeyName");

        // Create a new EncryptedXml object.
        EncryptedXml exml = new EncryptedXml(Doc);

        // Add the key name mapping.
        exml.AddKeyNameMapping(KeyName, Alg);

        // Decrypt the XML document.
        exml.DecryptDocument();

    }


}
//</SNIPPET1>