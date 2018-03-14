//<snippet1>
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
            Encrypt(xmlDoc, "creditcard", rsaKey, "rsaKey");

            // Inspect the EncryptedKey element.
            InspectElement(xmlDoc);

            // Decrypt the "creditcard" element.
            Decrypt(xmlDoc, rsaKey, "rsaKey");

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

    }

    public static void Encrypt(XmlDocument Doc, string ElementToEncrypt, RSA Alg, string KeyName)
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

        // Create an EncryptionMethod element so that the 
        // receiver knows which algorithm to use for decryption.

        edElement.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncAES256Url);

        // Encrypt the session key and add it to an EncryptedKey element.
        EncryptedKey ek = new EncryptedKey();

        byte[] encryptedKey = EncryptedXml.EncryptKey(sessionKey.Key, Alg, false);

        ek.CipherData = new CipherData(encryptedKey);

        ek.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncRSA15Url);

        // Save some more information about the key using
        // the EncryptionProperty element.  In this example,
        // we will save the value "LibVersion1".  You can save
        // anything you want here.

        // Create a new "EncryptionProperty" XmlElement object. 
        XmlElement element =  new XmlDocument().CreateElement("EncryptionProperty", EncryptedXml.XmlEncNamespaceUrl);

        // Set the value of the EncryptionProperty" XmlElement object.
        element.InnerText = "LibVersion1";

        // Create the EncryptionProperty object using the XmlElement object. 
        EncryptionProperty encProp = new EncryptionProperty(element);

        // Add the EncryptionProperty object to the EncryptedData object.
        edElement.AddProperty(encProp);

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

    static void InspectElement(XmlDocument Doc)
    {
        // Get the EncryptedData element from the XMLDocument object.
        XmlElement encryptedData = Doc.GetElementsByTagName("EncryptedData")[0] as XmlElement;

        // Create a new EncryptedData object.
        EncryptedData encData = new EncryptedData();

        // Load the XML from the document to
        // initialize the EncryptedData object.
        encData.LoadXml(encryptedData);

        // Display the properties.
        // Most values are Null by default.

        Console.WriteLine("EncryptedData.CipherData: " + encData.CipherData.GetXml().InnerXml);
        Console.WriteLine("EncryptedData.Encoding: " + encData.Encoding);
        Console.WriteLine("EncryptedData.EncryptionMethod: " + encData.EncryptionMethod.GetXml().InnerXml);

        EncryptionPropertyCollection encPropCollection = encData.EncryptionProperties;

        Console.WriteLine("Number of elements in the EncryptionPropertyCollection: " + encPropCollection.Count);
        //encPropCollection.

        foreach(EncryptionProperty encProp in encPropCollection)
        {
                Console.WriteLine("EncryptionProperty.ID: " + encProp.Id);
                Console.WriteLine("EncryptionProperty.PropertyElement: " + encProp.PropertyElement.InnerXml);
                Console.WriteLine("EncryptionProperty.Target: " + encProp.Target);
                 
        }

    

        Console.WriteLine("EncryptedData.Id: " + encData.Id);
        Console.WriteLine("EncryptedData.KeyInfo: " + encData.KeyInfo.GetXml().InnerXml);
        Console.WriteLine("EncryptedData.MimeType: " + encData.MimeType);
    }

}
//</snippet1>