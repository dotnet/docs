// <snippet1>

using System;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Runtime.Versioning;

[SupportedOSPlatform("windows")]
class Program
{
    static void Main(string[] args)
    {
        // <snippet4>
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
        // </snippet4>

        // Create a new CspParameters object to specify
        // a key container.
        // <snippet2>
        CspParameters cspParams = new CspParameters();
        cspParams.KeyContainerName = "XML_ENC_RSA_KEY";
        // </snippet2>

        // Create a new RSA key and save it in the container.  This key will encrypt
        // a symmetric key, which will then be encrypted in the XML document.
        // <snippet3>
        RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(cspParams);
        // </snippet3>

        try
        {
            // Encrypt the "creditcard" element.
            Encrypt(xmlDoc, "creditcard", "EncryptedElement1", rsaKey, "rsaKey");

            // Save the XML document.
            // <snippet16>
            xmlDoc.Save("test.xml");
            // </snippet16>

            // Display the encrypted XML to the console.
            Console.WriteLine("Encrypted XML:");
            Console.WriteLine();
            Console.WriteLine(xmlDoc.OuterXml);
            Decrypt(xmlDoc, rsaKey, "rsaKey");
            xmlDoc.Save("test.xml");
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
            // Clear the RSA key.
            rsaKey.Clear();
        }

        Console.ReadLine();
    }

    public static void Encrypt(XmlDocument Doc, string ElementToEncrypt, string EncryptionElementID, RSA Alg, string KeyName)
    {
        // Check the arguments.
        if (Doc == null)
            throw new ArgumentNullException("Doc");
        if (ElementToEncrypt == null)
            throw new ArgumentNullException("ElementToEncrypt");
        if (EncryptionElementID == null)
            throw new ArgumentNullException("EncryptionElementID");
        if (Alg == null)
            throw new ArgumentNullException("Alg");
        if (KeyName == null)
            throw new ArgumentNullException("KeyName");

        ////////////////////////////////////////////////
        // Find the specified element in the XmlDocument
        // object and create a new XmlElement object.
        ////////////////////////////////////////////////
        // <snippet5>
        XmlElement? elementToEncrypt = Doc.GetElementsByTagName(ElementToEncrypt)[0] as XmlElement;

        // Throw an XmlException if the element was not found.
        if (elementToEncrypt == null)
        {
            throw new XmlException("The specified element was not found");
        }
        // </snippet5>
        Aes? sessionKey = null;

        try
        {
            //////////////////////////////////////////////////
            // Create a new instance of the EncryptedXml class
            // and use it to encrypt the XmlElement with the
            // a new random symmetric key.
            //////////////////////////////////////////////////

            // <snippet6>
            // Create an AES key.
            sessionKey = Aes.Create();
            // </snippet6>

            // <snippet7>
            EncryptedXml eXml = new EncryptedXml();

            byte[] encryptedElement = eXml.EncryptData(elementToEncrypt, sessionKey, false);
            // </snippet7>
            ////////////////////////////////////////////////
            // Construct an EncryptedData object and populate
            // it with the desired encryption information.
            ////////////////////////////////////////////////

            // <snippet8>
            EncryptedData edElement = new EncryptedData();
            edElement.Type = EncryptedXml.XmlEncElementUrl;
            edElement.Id = EncryptionElementID;
            // </snippet8>
            // Create an EncryptionMethod element so that the
            // receiver knows which algorithm to use for decryption.

            // <snippet9>
            edElement.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncAES256Url);
            // </snippet9>
            // Encrypt the session key and add it to an EncryptedKey element.
            // <snippet10>
            EncryptedKey ek = new EncryptedKey();

            byte[] encryptedKey = EncryptedXml.EncryptKey(sessionKey.Key, Alg, false);

            ek.CipherData = new CipherData(encryptedKey);

            ek.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncRSA15Url);
            // </snippet10>

            // Create a new DataReference element
            // for the KeyInfo element.  This optional
            // element specifies which EncryptedData
            // uses this key.  An XML document can have
            // multiple EncryptedData elements that use
            // different keys.
            // <snippet11>
            DataReference dRef = new DataReference();

            // Specify the EncryptedData URI.
            dRef.Uri = "#" + EncryptionElementID;

            // Add the DataReference to the EncryptedKey.
            ek.AddReference(dRef);
            // </snippet11>
            // Add the encrypted key to the
            // EncryptedData object.

            // <snippet12>
            edElement.KeyInfo.AddClause(new KeyInfoEncryptedKey(ek));
            // </snippet12>
            // Set the KeyInfo element to specify the
            // name of the RSA key.

            // <snippet13>

            // Create a new KeyInfoName element.
            KeyInfoName kin = new KeyInfoName();

            // Specify a name for the key.
            kin.Value = KeyName;

            // Add the KeyInfoName element to the
            // EncryptedKey object.
            ek.KeyInfo.AddClause(kin);
            // </snippet13>
            // Add the encrypted element data to the
            // EncryptedData object.
            // <snippet14>
            edElement.CipherData.CipherValue = encryptedElement;
            // </snippet14>
            ////////////////////////////////////////////////////
            // Replace the element from the original XmlDocument
            // object with the EncryptedData element.
            ////////////////////////////////////////////////////
            // <snippet15>
            EncryptedXml.ReplaceElement(elementToEncrypt, edElement, false);
            // </snippet15>
        }
        finally
        {
            sessionKey?.Clear();
        }
    }

    public static void Decrypt(XmlDocument Doc, RSA Alg, string KeyName)
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

        // Add a key-name mapping.
        // This method can only decrypt documents
        // that present the specified key name.
        exml.AddKeyNameMapping(KeyName, Alg);

        // Decrypt the element.
        exml.DecryptDocument();
    }
}

// </Snippet1>
