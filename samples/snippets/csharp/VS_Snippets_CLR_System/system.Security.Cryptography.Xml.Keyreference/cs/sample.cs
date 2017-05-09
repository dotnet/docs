// <snippet1>

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

        // Create a new RSA key.  This key will encrypt a symmetric key,
        // which will then be imbedded in the XML document.  
        RSA rsaKey = new RSACryptoServiceProvider();


        try
        {
            // Encrypt the "creditcard" element.
            Encrypt(xmlDoc, "creditcard", "EncryptedElement1", rsaKey, "rsaKey");

            // Encrypt the "creditcard2" element.
            Encrypt(xmlDoc, "creditcard2", "EncryptedElement2", rsaKey, "rsaKey");

            // Display the encrypted XML to the console.
            Console.WriteLine("Encrypted XML:");
            Console.WriteLine();
            Console.WriteLine(xmlDoc.OuterXml);

            // Decrypt the "creditcard" element.
            Decrypt(xmlDoc, rsaKey, "rsaKey");

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
        // a new random symmetric key.
        //////////////////////////////////////////////////

        // Create a 256 bit Rijndael key.
        RijndaelManaged sessionKey = new RijndaelManaged();
        sessionKey.KeySize = 256;

        EncryptedXml eXml = new EncryptedXml();

        byte[] encryptedElement = eXml.EncryptData(elementToEncrypt, sessionKey, false);

        ////////////////////////////////////////////////
        // Construct an EncryptedData object and populate
        // it with the desired encryption information.
        ////////////////////////////////////////////////


        EncryptedData edElement = new EncryptedData();
        edElement.Type = EncryptedXml.XmlEncElementUrl;
        edElement.Id = EncryptionElementID;

        // Create an EncryptionMethod element so that the 
        // receiver knows which algorithm to use for decryption.

        edElement.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncAES256Url);

        // Encrypt the session key and add it to an EncryptedKey element.
        EncryptedKey ek = new EncryptedKey();

        ek.Id = "keyID";

        byte[] encryptedKey = EncryptedXml.EncryptKey(sessionKey.Key, Alg, false);

        ek.CipherData = new CipherData(encryptedKey);

        ek.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncRSA15Url);

        // Set the KeyInfo element to specify the
        // name of the RSA key.

        // Create a new KeyInfo element.
        edElement.KeyInfo = new KeyInfo();

        // Create a new KeyInfoName element.
        KeyInfoName kin = new KeyInfoName();

        // Specify a name for the key.
        kin.Value = KeyName;

        // Add the KeyInfoName element to the 
        // EncryptedKey object.
        ek.KeyInfo.AddClause(kin);

        // Create a new KeyReference object.
        // Use the uri of the encrypted key.
        KeyReference kryRef = new KeyReference("#keyID");

        ek.AddReference(kryRef);

        // Create a new DataReference element
        // for the KeyInfo element.  This optional
        // element specifies which EncryptedData 
        // uses this key.  An XML document can have
        // multiple EncryptedData elements that use
        // different keys.
        DataReference dRef = new DataReference();

        // Specify the EncryptedData URI. 
        dRef.Uri = "#" + EncryptionElementID;

        // Add the DataReference to the EncryptedKey.
        ek.AddReference(dRef);

        // Add the encrypted key to the 
        // EncryptedData object.

        edElement.KeyInfo.AddClause(new KeyInfoEncryptedKey(ek));

        // Add the encrypted element data to the 
        // EncryptedData object.
        edElement.CipherData.CipherValue = encryptedElement;

        ////////////////////////////////////////////////////
        // Replace the element from the original XmlDocument
        // object with the EncryptedData element.
        ////////////////////////////////////////////////////

        EncryptedXml.ReplaceElement(elementToEncrypt, edElement, false);

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

// To run this sample, place the following XML
// in a file called test.xml.  Put test.xml
// in the same directory as your compiled program.
// 
//  <root>
//     <creditcard xmlns="myNamespace" Id="tag1">
//         <number>19834209</number>
//         <expiry>02/02/2002</expiry>
//     </creditcard>
//     <creditcard2 xmlns="myNamespace" Id="tag2">
//         <number>19834208</number>
//         <expiry>02/02/2002</expiry>
//     </creditcard2>
// </root>
// </snippet1>
