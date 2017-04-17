// <Snippet1>
using System;
using System.Xml;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Configuration.Provider;
using System.Collections.Specialized;
using System.Configuration;

namespace Samples.AspNet
{
    // Shows how to create a custom protected configuration
    // provider.
    public class TripleDESProtectedConfigurationProvider :
        ProtectedConfigurationProvider
    {

        private TripleDESCryptoServiceProvider des =
            new TripleDESCryptoServiceProvider();

        private string pKeyFilePath;
        private string pName;

        // Gets the path of the file
        // containing the key used to
        // encryption or decryption.
        public string KeyFilePath
        {
            get { return pKeyFilePath; }
        }


        // Gets the provider name.
        public override string Name
        {
            get { return pName; }
        }


        // Performs provider initialization.
        public override void Initialize(string name,
            NameValueCollection config)
        {
            pName = name;
            pKeyFilePath = config["keyContainerName"];
            ReadKey(KeyFilePath);
        }


        // <Snippet3>
        // Performs encryption.
        public override XmlNode Encrypt(XmlNode node)
        {
            string encryptedData = EncryptString(node.OuterXml);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.LoadXml("<EncryptedData>" +
                encryptedData + "</EncryptedData>");

            return xmlDoc.DocumentElement;
        }
        // </Snippet3>

        // <Snippet2>
        // Performs decryption.
        public override XmlNode Decrypt(XmlNode encryptedNode)
        {
            string decryptedData =
                DecryptString(encryptedNode.InnerText);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.LoadXml(decryptedData);

            return xmlDoc.DocumentElement;
        }
        // </Snippet2>

        // Encrypts a configuration section and returns 
        // the encrypted XML as a string.
        private string EncryptString(string encryptValue)
        {
            byte[] valBytes =
                Encoding.Unicode.GetBytes(encryptValue);

            ICryptoTransform transform = des.CreateEncryptor();

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms,
                transform, CryptoStreamMode.Write);
            cs.Write(valBytes, 0, valBytes.Length);
            cs.FlushFinalBlock();
            byte[] returnBytes = ms.ToArray();
            cs.Close();

            return Convert.ToBase64String(returnBytes);
        }


        // Decrypts an encrypted configuration section and 
        // returns the unencrypted XML as a string.
        private string DecryptString(string encryptedValue)
        {
            byte[] valBytes =
                Convert.FromBase64String(encryptedValue);

            ICryptoTransform transform = des.CreateDecryptor();

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms,
                transform, CryptoStreamMode.Write);
            cs.Write(valBytes, 0, valBytes.Length);
            cs.FlushFinalBlock();
            byte[] returnBytes = ms.ToArray();
            cs.Close();

            return Encoding.Unicode.GetString(returnBytes);
        }

        // Generates a new TripleDES key and vector and 
        // writes them to the supplied file path.
        public void CreateKey(string filePath)
        {
            des.GenerateKey();
            des.GenerateIV();

            StreamWriter sw = new StreamWriter(filePath, false);
            sw.WriteLine(ByteToHex(des.Key));
            sw.WriteLine(ByteToHex(des.IV));
            sw.Close();
        }


        // Reads in the TripleDES key and vector from 
        // the supplied file path and sets the Key 
        // and IV properties of the 
        // TripleDESCryptoServiceProvider.
        private void ReadKey(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            string keyValue = sr.ReadLine();
            string ivValue = sr.ReadLine();
            des.Key = HexToByte(keyValue);
            des.IV = HexToByte(ivValue);
        }


        // Converts a byte array to a hexadecimal string.
        private string ByteToHex(byte[] byteArray)
        {
            string outString = "";

            foreach (Byte b in byteArray)
                outString += b.ToString("X2");

            return outString;
        }

        // Converts a hexadecimal string to a byte array.
        private byte[] HexToByte(string hexString)
        {
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] =
                    Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

    }

}
// </Snippet1>


