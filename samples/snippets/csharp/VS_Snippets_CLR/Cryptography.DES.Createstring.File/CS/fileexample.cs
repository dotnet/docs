// <SNIPPET1>
using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

class DESSample
{

    static void Main()
    {
        try
        {
            // Create a new DES object to generate a key 
            // and initialization vector (IV).  Specify one 
            // of the recognized simple names for this 
            // algorithm.
            DES DESalg = DES.Create("DES");

            // Create a string to encrypt.
            string sData = "Here is some data to encrypt.";
            string FileName = "CText.txt";

            // Encrypt text to a file using the file name, key, and IV.
            EncryptTextToFile(sData, FileName, DESalg.Key, DESalg.IV);

            // Decrypt the text from a file using the file name, key, and IV.
            string Final = DecryptTextFromFile(FileName, DESalg.Key, DESalg.IV);
            
            // Display the decrypted string to the console.
            Console.WriteLine(Final);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
       
    }

    public static void EncryptTextToFile(String Data, String FileName, byte[] Key, byte[] IV)
    {
        try
        {
            // Create or open the specified file.
            FileStream fStream = File.Open(FileName,FileMode.OpenOrCreate);

            // Create a new DES object.
            DES DESalg = DES.Create();

            // Create a CryptoStream using the FileStream 
            // and the passed key and initialization vector (IV).
            CryptoStream cStream = new CryptoStream(fStream, 
                DESalg.CreateEncryptor(Key,IV), 
                CryptoStreamMode.Write); 

            // Create a StreamWriter using the CryptoStream.
            StreamWriter sWriter = new StreamWriter(cStream);

            // Write the data to the stream 
            // to encrypt it.
            sWriter.WriteLine(Data);
  
            // Close the streams and
            // close the file.
            sWriter.Close();
            cStream.Close();
            fStream.Close();
        }
        catch(CryptographicException e)
        {
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
        }
        catch(UnauthorizedAccessException  e)
        {
            Console.WriteLine("A file error occurred: {0}", e.Message);
        }

    }

    public static string DecryptTextFromFile(String FileName, byte[] Key, byte[] IV)
    {
        try
        {
            // Create or open the specified file. 
            FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate);

            // Create a new DES object.
            DES DESalg = DES.Create();
  
            // Create a CryptoStream using the FileStream 
            // and the passed key and initialization vector (IV).
            CryptoStream cStream = new CryptoStream(fStream, 
                DESalg.CreateDecryptor(Key,IV), 
                CryptoStreamMode.Read); 

            // Create a StreamReader using the CryptoStream.
            StreamReader sReader = new StreamReader(cStream);

            // Read the data from the stream 
            // to decrypt it.
            string val = sReader.ReadLine();
    
            // Close the streams and
            // close the file.
            sReader.Close();
            cStream.Close();
            fStream.Close();

            // Return the string. 
            return val;
        }
        catch(CryptographicException e)
        {
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            return null;
        }
        catch(UnauthorizedAccessException  e)
        {
            Console.WriteLine("A file error occurred: {0}", e.Message);
            return null;
        }
    }
}
// </SNIPPET1>