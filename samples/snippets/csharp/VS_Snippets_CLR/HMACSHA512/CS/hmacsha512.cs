//<SNIPPET1>
using System;
using System.IO;
using System.Security.Cryptography;

public class HMACSHA512example
{

    public static void Main(string[] Fileargs)
    {
        string dataFile;
        string signedFile;
        //If no file names are specified, create them.
        if (Fileargs.Length < 2)
        {
            dataFile = @"text.txt";
            signedFile = "signedFile.enc";

            if (!File.Exists(dataFile))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(dataFile))
                {
                    sw.WriteLine("Here is a message to sign");
                }
            }

        }
        else
        {
            dataFile = Fileargs[0];
            signedFile = Fileargs[1];
        }
        try
        {
            // Create a random key using a random number generator. This would be the
            //  secret key shared by sender and receiver.
            byte[] secretkey = new Byte[64];
            //RNGCryptoServiceProvider is an implementation of a random number generator.
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                // The array is now filled with cryptographically strong random bytes.
                rng.GetBytes(secretkey);

                // Use the secret key to sign the message file.
                SignFile(secretkey, dataFile, signedFile);

                // Verify the signed file
                VerifyFile(secretkey, signedFile);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("Error: File not found", e);
        }

    }  //end main
    // Computes a keyed hash for a source file and creates a target file with the keyed hash
    // prepended to the contents of the source file. 
    public static void SignFile(byte[] key, String sourceFile, String destFile)
    {
        // Initialize the keyed hash object.
        using (HMACSHA512 hmac = new HMACSHA512(key))
        {
            using (FileStream inStream = new FileStream(sourceFile, FileMode.Open))
            {
                using (FileStream outStream = new FileStream(destFile, FileMode.Create))
                {
                    // Compute the hash of the input file.
                    byte[] hashValue = hmac.ComputeHash(inStream);
                    // Reset inStream to the beginning of the file.
                    inStream.Position = 0;
                    // Write the computed hash value to the output file.
                    outStream.Write(hashValue, 0, hashValue.Length);
                    // Copy the contents of the sourceFile to the destFile.
                    int bytesRead;
                    // read 1K at a time
                    byte[] buffer = new byte[1024];
                    do
                    {
                        // Read from the wrapping CryptoStream.
                        bytesRead = inStream.Read(buffer, 0, 1024);
                        outStream.Write(buffer, 0, bytesRead);
                    } while (bytesRead > 0);
                }
            }
        }
        return;
    } // end SignFile


    // Compares the key in the source file with a new key created for the data portion of the file. If the keys 
    // compare the data has not been tampered with.
    public static bool VerifyFile(byte[] key, String sourceFile)
    {
        bool err = false;
        // Initialize the keyed hash object. 
        using (HMACSHA512 hmac = new HMACSHA512(key))
        {
            // Create an array to hold the keyed hash value read from the file.
            byte[] storedHash = new byte[hmac.HashSize / 8];
            // Create a FileStream for the source file.
            using (FileStream inStream = new FileStream(sourceFile, FileMode.Open))
            {
                // Read in the storedHash.
                inStream.Read(storedHash, 0, storedHash.Length);
                // Compute the hash of the remaining contents of the file.
                // The stream is properly positioned at the beginning of the content, 
                // immediately after the stored hash value.
                byte[] computedHash = hmac.ComputeHash(inStream);
                // compare the computed hash with the stored value

                for (int i = 0; i < storedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                    {
                        err = true;
                    }
                }
            }
        }
        if (err)
        {
            Console.WriteLine("Hash values differ! Signed file has been tampered with!");
            return false;
        }
        else
        {
            Console.WriteLine("Hash values agree -- no tampering occurred.");
            return true;
        }

    } //end VerifyFile

} //end class
//</SNIPPET1>