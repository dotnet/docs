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
            return;
        }

        // Create a new TripleDES key. 
        TripleDESCryptoServiceProvider tDESkey = new TripleDESCryptoServiceProvider();


        try
        {
            // Encrypt the "creditcard" element.
            Encrypt(xmlDoc, "creditcard", tDESkey);

            // Display the encrypted XML to the console.
            Console.WriteLine("Encrypted XML:");
            Console.WriteLine();
            Console.WriteLine(xmlDoc.OuterXml);

            // Decrypt the "creditcard" element.
            Decrypt(xmlDoc, tDESkey);

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

    public static void Encrypt(XmlDocument Doc, string ElementToEncrypt, SymmetricAlgorithm Alg)
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

        byte[] encryptedElement = eXml.EncryptData(elementToEncrypt, Alg, false);

        ////////////////////////////////////////////////
        // Construct an EncryptedData object and populate
        // it with the desired encryption information.
        ////////////////////////////////////////////////


        EncryptedData edElement = new EncryptedData();
        edElement.Type = EncryptedXml.XmlEncElementUrl;

        // Create an EncryptionMethod element so that the 
        // receiver knows which algorithm to use for decryption.
        // Determine what kind of algorithm is being used and
        // supply the appropriate URL to the EncryptionMethod element.

        string encryptionMethod = null;

        if (Alg is TripleDES)
        {
            encryptionMethod = EncryptedXml.XmlEncTripleDESUrl;
        }
        else if (Alg is DES)
        {
            encryptionMethod = EncryptedXml.XmlEncDESUrl;
        }
        else if (Alg is Rijndael)
        {
            switch (Alg.KeySize)
            {
                case 128:
                    encryptionMethod = EncryptedXml.XmlEncAES128Url;
                    break;
                case 192:
                    encryptionMethod = EncryptedXml.XmlEncAES192Url;
                    break;
                case 256:
                    encryptionMethod = EncryptedXml.XmlEncAES256Url;
                    break;
            }
        }
        else
        {
            // Throw an exception if the transform is not in the previous categories
            throw new CryptographicException("The specified algorithm is not supported for XML Encryption.");
        }

        edElement.EncryptionMethod = new EncryptionMethod(encryptionMethod);

        // Add the encrypted element data to the 
        // EncryptedData object.
        edElement.CipherData.CipherValue = encryptedElement;

        ////////////////////////////////////////////////////
        // Replace the element from the original XmlDocument
        // object with the EncryptedData element.
        ////////////////////////////////////////////////////

        EncryptedXml.ReplaceElement(elementToEncrypt, edElement, false);

    }

    public static void Decrypt(XmlDocument Doc, SymmetricAlgorithm Alg)
    {
        // Check the arguments.  
        if (Doc == null)
            throw new ArgumentNullException("Doc");
        if (Alg == null)
            throw new ArgumentNullException("Alg");

        // Find the EncryptedData element in the XmlDocument.
        XmlElement encryptedElement = Doc.GetElementsByTagName("EncryptedData")[0] as XmlElement;

        // If the EncryptedData element was not found, throw an exception.
        if (encryptedElement == null)
        {
            throw new XmlException("The EncryptedData element was not found.");
        }

        // Create an EncryptedData object and populate it.
        EncryptedData edElement = new EncryptedData();
        edElement.LoadXml(encryptedElement);

        // Create a new EncryptedXml object.
        EncryptedXml exml = new EncryptedXml();

        // Decrypt the element using the symmetric key.
        byte[] rgbOutput = exml.DecryptData(edElement, Alg);

        // Replace the encryptedData element with the plaintext XML element.
        exml.ReplaceData(encryptedElement, rgbOutput);

    }


}
//</SNIPPET1>