using System;
using System.IO;
using System.Security.Cryptography;

public class DecryptExample
{
    public static void Main(string[] args)
    {
        //Decryption key must be the same value that was used
        //to encrypt the stream.
        byte[] key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

        try
        {
            //Create a file stream.
            using FileStream myStream = new FileStream("TestData.txt", FileMode.Open);

            //Create a new instance of the default Aes implementation class
            using Aes aes = Aes.Create();

            //Reads IV value from beginning of the file.
            byte[] iv = new byte[aes.IV.Length];
            myStream.Read(iv, 0, iv.Length);

            //Create a CryptoStream, pass it the file stream, and decrypt
            //it with the Aes class using the key and IV.
            using CryptoStream cryptStream = new CryptoStream(
               myStream,
               aes.CreateDecryptor(key, iv),
               CryptoStreamMode.Read);

            //Read the stream.
            using StreamReader sReader = new StreamReader(cryptStream);

            //Display the message.
            Console.WriteLine("The decrypted original message: {0}", sReader.ReadToEnd());
        }
        catch
        {
            Console.WriteLine("The decryption failed.");
            throw;
        }
    }
}
