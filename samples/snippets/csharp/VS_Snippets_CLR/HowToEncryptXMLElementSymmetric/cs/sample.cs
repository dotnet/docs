//<snippet1>
using System;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;

namespace CSCrypto
{
    class Program
    {
        static void Main(string[] args)
        {
            //<snippet2>
            Aes? key = null;

            try
            {
                // Create a new AES key.
                key = Aes.Create();
                //</snippet2>
                //<snippet3>
                // Load an XML document.
                XmlDocument xmlDoc = new()
                {
                    PreserveWhitespace = true
                };
                xmlDoc.Load("test.xml");
                //</snippet3>

                // Encrypt the "creditcard" element.
                Encrypt(xmlDoc, "creditcard", key);

                Console.WriteLine("The element was encrypted");

                Console.WriteLine(xmlDoc.InnerXml);

                Decrypt(xmlDoc, key);

                Console.WriteLine("The element was decrypted");

                Console.WriteLine(xmlDoc.InnerXml);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                key?.Clear();
            }
        }

        public static void Encrypt(XmlDocument Doc, string ElementName, SymmetricAlgorithm Key)
        {
            // Check the arguments.
            ArgumentNullException.ThrowIfNull(Doc);
            ArgumentNullException.ThrowIfNull(ElementName);
            ArgumentNullException.ThrowIfNull(Key);

            ////////////////////////////////////////////////
            // Find the specified element in the XmlDocument
            // object and create a new XmlElement object.
            ////////////////////////////////////////////////
            //<snippet4>
            XmlElement? elementToEncrypt = Doc.GetElementsByTagName(ElementName)[0] as XmlElement;
            //</snippet4>
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

            //<snippet5>
            EncryptedXml eXml = new();

            byte[] encryptedElement = eXml.EncryptData(elementToEncrypt, Key, false);
            //</snippet5>
            ////////////////////////////////////////////////
            // Construct an EncryptedData object and populate
            // it with the desired encryption information.
            ////////////////////////////////////////////////

            //<snippet6>
            EncryptedData edElement = new()
            {
                Type = EncryptedXml.XmlEncElementUrl
            };
            //</snippet6>

            // Create an EncryptionMethod element so that the
            // receiver knows which algorithm to use for decryption.
            // Determine what kind of algorithm is being used and
            // supply the appropriate URL to the EncryptionMethod element.

            //<snippet7>
            string? encryptionMethod;
            if (Key is Aes)
            {
                encryptionMethod = EncryptedXml.XmlEncAES256Url;
            }
            else
            {
                // Throw an exception if the transform is not AES
                throw new CryptographicException("The specified algorithm is not supported or not recommended for XML Encryption.");
            }

            edElement.EncryptionMethod = new EncryptionMethod(encryptionMethod);
            //</snippet7>

            // Add the encrypted element data to the
            // EncryptedData object.
            //<snippet8>
            edElement.CipherData.CipherValue = encryptedElement;
            //</snippet8>

            ////////////////////////////////////////////////////
            // Replace the element from the original XmlDocument
            // object with the EncryptedData element.
            ////////////////////////////////////////////////////
            //<snippet9>
            EncryptedXml.ReplaceElement(elementToEncrypt, edElement, false);
            //</snippet9>
        }

        public static void Decrypt(XmlDocument Doc, SymmetricAlgorithm Alg)
        {
            // Check the arguments.
            ArgumentNullException.ThrowIfNull(Doc);
            ArgumentNullException.ThrowIfNull(Alg);

            // Find the EncryptedData element in the XmlDocument.
            // <snippet10>
            XmlElement? encryptedElement = Doc.GetElementsByTagName("EncryptedData")[0] as XmlElement;
            // </snippet10>

            // If the EncryptedData element was not found, throw an exception.
            if (encryptedElement == null)
            {
                throw new XmlException("The EncryptedData element was not found.");
            }

            // Create an EncryptedData object and populate it.
            // <snippet11>
            EncryptedData edElement = new();
            edElement.LoadXml(encryptedElement);
            // </snippet11>

            // Create a new EncryptedXml object.
            // <snippet12>
            EncryptedXml exml = new();

            // Decrypt the element using the symmetric key.
            byte[] rgbOutput = exml.DecryptData(edElement, Alg);
            // </snippet12>

            // Replace the encryptedData element with the plaintext XML element.
            // <snippet13>
            exml.ReplaceData(encryptedElement, rgbOutput);
            // </snippet13>
        }
    }
}
//</snippet1>
