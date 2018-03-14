//<snippet1>
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

            // Create a new instance of the RC2CryptoServiceProvider class
            // and automatically generate a Key and IV.
            RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider();

            Console.WriteLine("Effective key size is {0} bits.", rc2CSP.EffectiveKeySize);

            // Get the key and IV.
            byte[] key = rc2CSP.Key;
            byte[] IV = rc2CSP.IV;

            // Get an encryptor.
            ICryptoTransform encryptor = rc2CSP.CreateEncryptor(key, IV);

            // Encrypt the data as an array of encrypted bytes in memory.
            MemoryStream msEncrypt = new MemoryStream();
            CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

            // Convert the data to a byte array.
            string original = "Here is some data to encrypt.";
            byte[] toEncrypt = Encoding.ASCII.GetBytes(original);

            // Write all data to the crypto stream and flush it.
            csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
            csEncrypt.FlushFinalBlock();

            // Get the encrypted array of bytes.
            byte[] encrypted = msEncrypt.ToArray();

            ///////////////////////////////////////////////////////
            // This is where the data could be transmitted or saved.          
            ///////////////////////////////////////////////////////

            //Get a decryptor that uses the same key and IV as the encryptor.
            ICryptoTransform decryptor = rc2CSP.CreateDecryptor(key, IV);

            // Now decrypt the previously encrypted message using the decryptor
            // obtained in the above step.
            MemoryStream msDecrypt = new MemoryStream(encrypted);
            CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);

            // Read the decrypted bytes from the decrypting stream
            // and place them in a StringBuilder class.

            StringBuilder roundtrip = new StringBuilder();
            
            int b = 0;

            do
            {
                b = csDecrypt.ReadByte();
                
                if (b != -1)
                {
                    roundtrip.Append((char)b);
                }

            } while (b != -1);
 

            // Display the original data and the decrypted data.
            Console.WriteLine("Original:   {0}", original);
            Console.WriteLine("Round Trip: {0}", roundtrip);

            Console.ReadLine();
        }
    }
}
//</snippet1>
