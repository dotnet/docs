//<SNIPPET1>
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace RC2CryptoServiceProvider_Examples
{
    class MyMainClass
    {
        public static void Main()
        {
            byte[] originalBytes = ASCIIEncoding.ASCII.GetBytes("Here is some data.");

	    //Create a new RC2CryptoServiceProvider.
            RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider();

            rc2CSP.UseSalt = true;

            rc2CSP.GenerateKey();
            rc2CSP.GenerateIV();

            //Encrypt the data.
            MemoryStream msEncrypt = new MemoryStream();
            CryptoStream csEncrypt = new CryptoStream(msEncrypt, rc2CSP.CreateEncryptor(rc2CSP.Key, rc2CSP.IV), CryptoStreamMode.Write);

            //Write all data to the crypto stream and flush it.
            csEncrypt.Write(originalBytes, 0, originalBytes.Length);
            csEncrypt.FlushFinalBlock();

            //Get encrypted array of bytes.
            byte[] encryptedBytes = msEncrypt.ToArray();            

            //Decrypt the previously encrypted message.
            MemoryStream msDecrypt = new MemoryStream(encryptedBytes);
            CryptoStream csDecrypt = new CryptoStream(msDecrypt, rc2CSP.CreateDecryptor(rc2CSP.Key, rc2CSP.IV), CryptoStreamMode.Read);

            byte[] unencryptedBytes = new byte[originalBytes.Length];

            //Read the data out of the crypto stream.
            csDecrypt.Read(unencryptedBytes, 0, unencryptedBytes.Length);

            //Convert the byte array back into a string.
            string plaintext = ASCIIEncoding.ASCII.GetString(unencryptedBytes);

            //Display the results.
            Console.WriteLine("Unencrypted text: {0}", plaintext);

            Console.ReadLine();
        }
    }
}
//</SNIPPET1>