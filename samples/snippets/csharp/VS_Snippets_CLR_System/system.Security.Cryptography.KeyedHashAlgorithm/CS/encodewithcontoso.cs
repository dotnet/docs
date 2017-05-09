// This sample class demonstrates how to use the ContosoKeyedHash class to
// compute Hash
//<Snippet21>
using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Security.Cryptography;

namespace Contoso
{
    class EncodeWithContoso
    {
        [STAThread]
        static void Main(string[] args)
        {
            EncodeMessage();
            EncodeStream();

            Console.WriteLine("This sample completed successfully; " + 
                "press Enter to exit");
            Console.ReadLine();
        }

        // Compute the hash for a ContosoKeyedHash that has transformed a
        // file stream.
        private static void EncodeStream()
        {
            //<Snippet4>
            byte[] keyData = new byte[24];
            RandomNumberGenerator.Create().GetBytes(keyData);
            ContosoKeyedHash localCrypto = new ContosoKeyedHash(keyData);
            //</Snippet4>

            string filePath = (System.IO.Directory.GetCurrentDirectory() +
                "\\members.txt");
            try
            {
                //<Snippet14>
                FileStream fileStream =
                    new FileStream(filePath, FileMode.Open, FileAccess.Read);

                localCrypto.ComputeHash(fileStream);
                //</Snippet14>

                SummarizeMAC(localCrypto, 
                    "ContosoKeyedHash after encoding a file stream.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The specified path was not found: " +
                    filePath);
            }
        }

        // Compute the hash for a ContosoKeyedHash that has transformed
        // a byte array.
        private static void EncodeMessage()
        {
            byte[] keyData = new byte[24];
            RandomNumberGenerator.Create().GetBytes(keyData);
            ContosoKeyedHash localCrypto = new ContosoKeyedHash(keyData);

            //<Snippet13>
            string message = "Hello World.";
            byte[] encodedMessage = 
                EncodeBytes(Encoding.ASCII.GetBytes(message));

            localCrypto.ComputeHash(encodedMessage);
            //</Snippet13>

            SummarizeMAC(localCrypto, 
                "ContosoKeyedHash after encoding a message.");
        }
        
        // Transform the byte array using ContosoKeyedHash,
        // then summarize its properties.
        private static byte[] EncodeBytes(byte[] sourceBytes)
        {
            int currentPosition = 0;
            byte[] targetBytes = new byte[1024];
            int sourceByteLength = sourceBytes.Length;

            // Create an encryptor with a random key and the
            // KeyedHashAlgorithm class name.
            byte[] key = new byte[24];
            RandomNumberGenerator.Create().GetBytes(key);
            string keyedHashName = 
                "System.Security.Cryptography.KeyedHashAlgorithm";
            ContosoKeyedHash localCrypto = 
                new ContosoKeyedHash(keyedHashName, key);

            // Retrieve the block size to read the bytes.
            //<Snippet9>
            int inputBlockSize = localCrypto.InputBlockSize;
            //</Snippet9>

            try
            {
                // Determine if multiple blocks can be transformed.
                //<Snippet6>
                if (localCrypto.CanTransformMultipleBlocks)
                    //</Snippet6>
                {
                    int numBytesRead = 0;
                    while (sourceByteLength - currentPosition >= 
                        inputBlockSize)
                    {
                        // Transform the bytes from the currentposition in the
                        // sourceBytes array, writing the bytes to the 
                        // targetBytes array.
                        //<Snippet18>
                        numBytesRead = localCrypto.TransformBlock(
                            sourceBytes,
                            currentPosition,
                            inputBlockSize,
                            targetBytes,
                            currentPosition);
                        //</Snippet18>

                        // Advance the current position in the source array.
                        currentPosition += numBytesRead;
                    }

                    // Transform the final block of bytes.
                    //<Snippet19>
                    byte[] finalBytes = localCrypto.TransformFinalBlock(
                        sourceBytes,
                        currentPosition,
                        sourceByteLength - currentPosition);
                    //</Snippet19>

                    // Copy the contents of the finalBytes array to the
                    // targetBytes array.
                    finalBytes.CopyTo(targetBytes,currentPosition);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Caught unexpected exception:" + 
                    ex.ToString());
            }

            // Find the length of valid bytes (those without zeros).
            //<Snippet15>
            IEnumerator enum1 = targetBytes.GetEnumerator();
            int i = 0;
            while (enum1.MoveNext())
            {
                if (enum1.Current.ToString().Equals("0"))
                {
                    break;
                } 
                i++;
            }

            // Compute the hash based on the valid bytes in the array.
            localCrypto.ComputeHash(targetBytes,0,i);
            //</Snippet15>

            SummarizeMAC(localCrypto, "ContosoKeyedHash after computing " +
                "hash for specified region of byte array");

            //<Snippet5>
            // Determine if the current transform can be reused.
            if (!localCrypto.CanReuseTransform)
                //</Snippet5>
            {
                // Free up any used resources.
                //<Snippet12>
                localCrypto.Clear();
                //</Snippet12>

                //<Snippet16>
                localCrypto.Initialize();
                //</Snippet16>
            }

            // Create a new array with the number of valid bytes.
            byte[] returnedArray = new byte[i];
            for (int j=0; j<i; j++) 
            {
                returnedArray[j] = targetBytes[j];
            }

            return returnedArray;
        }
        
        // Write a summary of the specified ContosoKeyedHash to the
        // console window.
        private static void SummarizeMAC(
            ContosoKeyedHash localCrypto,
            string description)
        {
            //<Snippet20>
            string classDescription = localCrypto.ToString();
            //</Snippet20>

            //<Snippet7>
            byte[] computedHash = localCrypto.Hash;
            //</Snippet7>

            //<Snippet8>
            int hashSize = localCrypto.HashSize;
            //</Snippet8>

            //<Snippet11>
            int outputBlockSize = localCrypto.OutputBlockSize;
            //</Snippet11>

            // Retrieve the key used in the hash algorithm.
            //<Snippet10>
            byte[] key = localCrypto.Key;
            //</Snippet10>

            Console.WriteLine("\n**********************************");
            Console.WriteLine(classDescription);
            Console.WriteLine(description);
            Console.WriteLine("----------------------------------");
            Console.WriteLine("The size of the computed hash : " + hashSize);
            Console.WriteLine("The key used in the hash algorithm : " + 
                Encoding.ASCII.GetString(key));
            Console.WriteLine("The value of the computed hash : " + 
                Encoding.ASCII.GetString(computedHash));
        }
    }
}
//</Snippet21>