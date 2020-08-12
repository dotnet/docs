using System;
using System.IO;
using System.Security.Cryptography;

public class main
{
    public static void Main(string[] args)
    {
        try
        {
            //Create a file stream
            FileStream myStream = new FileStream("TestData.txt", FileMode.OpenOrCreate);

            //Create a new instance of the default Aes implementation class  
            // and encrypt the stream.  
            Aes aes = Aes.Create();

            byte[] key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
            byte[] iv = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

            //Create a CryptoStream, pass it the FileStream, and encrypt
            //it with the Aes class.  
            CryptoStream cryptStream = new CryptoStream(
                myStream, 
                aes.CreateEncryptor(key, iv),
                CryptoStreamMode.Write);

            //Create a StreamWriter for easy writing to the
            //file stream.  
            StreamWriter sWriter = new StreamWriter(cryptStream);

            //Write to the stream.  
            sWriter.WriteLine("Hello World!");

            //Close all the connections.  
            sWriter.Close();
            cryptStream.Close();
            myStream.Close();

            //Inform the user that the message was written  
            //to the stream.  
            Console.WriteLine("The file was encrypted.");
        }
        catch
        {
            //Inform the user that an exception was raised.  
            Console.WriteLine("The encryption failed.");
            throw;
        }
    }
}
