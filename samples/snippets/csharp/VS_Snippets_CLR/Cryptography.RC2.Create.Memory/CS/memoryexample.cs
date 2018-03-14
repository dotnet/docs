// <SNIPPET1>
using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

class RC2Sample
{
    static void Main()
    {
        try
        {
            // Create a new RC2 object to generate a key
            // and initialization vector (IV).
            RC2 RC2alg = RC2.Create();

            // Create a string to encrypt.
            string sData = "Here is some data to encrypt.";

            // Encrypt the string to an in-memory buffer.
            byte[] Data = EncryptTextToMemory(sData, RC2alg.Key, RC2alg.IV);

            // Decrypt the buffer back to a string.
            string Final = DecryptTextFromMemory(Data, RC2alg.Key, RC2alg.IV);
            
            // Display the decrypted string to the console.
            Console.WriteLine(Final);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
       
    }

    public static byte[] EncryptTextToMemory(string Data,  byte[] Key, byte[] IV)
    {
        try
        {
            // Create a MemoryStream.
            MemoryStream mStream = new MemoryStream();

            // Create a new RC2 object.
            RC2 RC2alg = RC2.Create();

            // Create a CryptoStream using the MemoryStream 
            // and the passed key and initialization vector (IV).
            CryptoStream cStream = new CryptoStream(mStream, 
                RC2alg.CreateEncryptor(Key, IV), 
                CryptoStreamMode.Write);

            // Convert the passed string to a byte array.
            byte[] toEncrypt = new ASCIIEncoding().GetBytes(Data);

            // Write the byte array to the crypto stream and flush it.
            cStream.Write(toEncrypt, 0, toEncrypt.Length);
            cStream.FlushFinalBlock();
        
            // Get an array of bytes from the 
            // MemoryStream that holds the 
            // encrypted data.
            byte[] ret = mStream.ToArray();

            // Close the streams.
            cStream.Close();
            mStream.Close();

            // Return the encrypted buffer.
            return ret;
        }
        catch(CryptographicException e)
        {
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            return null;
        }

    }

    public static string DecryptTextFromMemory(byte[] Data,  byte[] Key, byte[] IV)
    {
        try
        {
            // Create a new MemoryStream using the passed 
            // array of encrypted data.
            MemoryStream msDecrypt = new MemoryStream(Data);

            // Create a new RC2 object.
            RC2 RC2alg = RC2.Create();

            // Create a CryptoStream using the MemoryStream 
            // and the passed key and initialization vector (IV).
            CryptoStream csDecrypt = new CryptoStream(msDecrypt, 
                RC2alg.CreateDecryptor(Key, IV), 
                CryptoStreamMode.Read);

            // Create buffer to hold the decrypted data.
            byte[] fromEncrypt = new byte[Data.Length];

            // Read the decrypted data out of the crypto stream
            // and place it into the temporary buffer.
            csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

            //Convert the buffer into a string and return it.
            return new ASCIIEncoding().GetString(fromEncrypt);
        }
        catch(CryptographicException e)
        {
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            return null;
        }
    }
}
// </SNIPPET1>
