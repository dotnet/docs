//<SNIPPET1>
using System;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;

namespace XMLDSIGExample
{
    class XmlLicenseTransformExample
    {
        public static void Main()
        {

        }
        //<SNIPPET2>
        public static void CheckSignatureWithEncryptedGrant(string fileName, IRelDecryptor decryptor)
        {
            // Create a new XML document.
            XmlDocument xmlDocument = new XmlDocument();
            XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlDocument.NameTable);

            // Format using whitespaces.
            xmlDocument.PreserveWhitespace = true;

            // Load the passed XML file into the document. 
            xmlDocument.Load(fileName);
            nsManager.AddNamespace("dsig", SignedXml.XmlDsigNamespaceUrl);

            // Find the "Signature" node and create a new XmlNodeList object.
            XmlNodeList nodeList = xmlDocument.SelectNodes("//dsig:Signature", nsManager);

            for (int i = 0, count = nodeList.Count; i < count; i++)
            {
                XmlDocument clone = xmlDocument.Clone() as XmlDocument;
                XmlNodeList signatures = clone.SelectNodes("//dsig:Signature", nsManager);

                // Create a new SignedXml object and pass into it the XML document clone.
                SignedXml signedXml = new SignedXml(clone);

                // Load the signature node.
                signedXml.LoadXml((XmlElement)signatures[i]);

                // Set the context for license transform
                Transform trans = ((Reference)signedXml.SignedInfo.References[0]).TransformChain[0];

                if (trans is XmlLicenseTransform)
                {

                    // Decryptor is used to decrypt encryptedGrant elements.
                    if (decryptor != null)
                        (trans as XmlLicenseTransform).Decryptor = decryptor;
                }

                // Check the signature and display the result.
                bool result = signedXml.CheckSignature();

                if (result)
                    Console.WriteLine("SUCCESS: CheckSignatureWithEncryptedGrant - issuer index #" +
                                                    i.ToString());
                else
                    Console.WriteLine("FAILURE: CheckSignatureWithEncryptedGrant - issuer index #" +
                                                    i.ToString());
            }

        }
        //</SNIPPET2>
    }
}

//</SNIPPET1>