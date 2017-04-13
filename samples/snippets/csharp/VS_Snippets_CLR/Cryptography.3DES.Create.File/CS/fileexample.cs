// <SNIPPET1>
using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

class TripleDESSample
{

    static void Main()
    {
        try
        {
            // Create a new TripleDES object to generate a key
            // and an initialization vector (IV).
            using (TripleDES TripleDESalg = TripleDES.Create())
            {
                // Create a string to encrypt.
                string sData = "Here is some data to encrypt.";
                string FileName = "CText.enc";

                // Encrypt text to a file using the file name, key, and IV.
                EncryptTextToFile(sData, FileName, TripleDESalg.Key, TripleDESalg.IV);

                // Decrypt the text from a file using the file name, key, and IV.
                string Final = DecryptTextFromFile(FileName, TripleDESalg.Key, TripleDESalg.IV);

                // Display the decrypted string to the console.
                Console.WriteLine(Final);
            }
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
            using (FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate))
            {

                // Create a new TripleDES object.
                using (TripleDES tripleDESalg = TripleDES.Create())
                {

                    // Create a CryptoStream using the FileStream 
                    // and the passed key and initialization vector (IV).
                    using (CryptoStream cStream = new CryptoStream(fStream,
                        tripleDESalg.CreateEncryptor(Key, IV),
                        CryptoStreamMode.Write))
                    {

                        // Create a StreamWriter using the CryptoStream.
                        using (StreamWriter sWriter = new StreamWriter(cStream))
                        {

                            // Write the data to the stream 
                            // to encrypt it.
                            sWriter.WriteLine(Data);
                        }
                    }
                }
            }

        }
        catch (CryptographicException e)
        {
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine("A file access error occurred: {0}", e.Message);
        }

    }

    public static string DecryptTextFromFile(String FileName, byte[] Key, byte[] IV)
    {
        try
        {
            string retVal = "";
            // Create or open the specified file. 
            using (FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate))
            {

                // Create a new TripleDES object.
                using (TripleDES tripleDESalg = TripleDES.Create())
                {

                    // Create a CryptoStream using the FileStream 
                    // and the passed key and initialization vector (IV).
                    using (CryptoStream cStream = new CryptoStream(fStream,
                        tripleDESalg.CreateDecryptor(Key, IV),
                        CryptoStreamMode.Read))
                    {

                        // Create a StreamReader using the CryptoStream.
                        using (StreamReader sReader = new StreamReader(cStream))
                        {

                            // Read the data from the stream 
                            // to decrypt it.
                            retVal = sReader.ReadLine();
                        }
                    }
                }

            }
            // Return the string. 
            return retVal;
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            return null;
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine("A file access error occurred: {0}", e.Message);
            return null;
        }
    }
}
// </SNIPPET1>
