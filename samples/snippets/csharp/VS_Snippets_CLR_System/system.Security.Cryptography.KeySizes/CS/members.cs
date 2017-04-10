// This sample demonstrates how to use each member of the KeySizes class.
//<Snippet1>
using System;
using System.Security.Cryptography;

namespace Contoso
{
    class KeySizesMembers
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Initializes a new instance of the KeySizes class with the
            // specified key values.
            //<Snippet2>
            int minSize = 64;
            int maxSize = 1024;
            int skipSize = 64;
            KeySizes keySizes = new KeySizes(minSize, maxSize, skipSize);
            //</Snippet2>

            // Show the values of the keys.
            ShowKeys(new KeySizes[1]{keySizes}, "Custom Keys");

            // Create a new symmetric algorithm and display its key values.
            SymmetricAlgorithm rijn = SymmetricAlgorithm.Create();
            ShowKeys(rijn.LegalKeySizes, rijn.ToString());
            Console.WriteLine("rijn.blocksize:" + rijn.BlockSize);

            // Create a new RSA algorithm and display its key values.
            RSACryptoServiceProvider rsaCSP = 
                new RSACryptoServiceProvider(384);
            ShowKeys(rsaCSP.LegalKeySizes, rsaCSP.ToString());
            Console.WriteLine("RSACryptoServiceProvider KeySize = " + 
                rsaCSP.KeySize);

            Console.WriteLine("This sample completed successfully; " +
                "press Enter to exit.");
            Console.ReadLine();
        }

        // Display specified KeySize properties to the console.
        private static void ShowKeys(KeySizes[] keySizes, string objectName)
        {
            // Retrieve the first KeySizes in the array.
            KeySizes firstKeySize = keySizes[0];

            // Retrieve the minimum key size in bits.
            //<Snippet3>
            int minKeySize = firstKeySize.MinSize;
            //</Snippet3>
                
            // Retrieve the maximum key size in bits.
            //<Snippet4>
            int maxKeySize = firstKeySize.MaxSize;
            //</Snippet4>
                
            // Retrieve the interval between valid key size in bits.
            //<Snippet5>
            int skipKeySize = firstKeySize.SkipSize;
            //</Snippet5>

            Console.Write("\n KeySizes retrieved from the ");
            Console.WriteLine(objectName + " object.");
            Console.WriteLine("Minimum key size bits: " + minKeySize);
            Console.WriteLine("Maximum key size bits: " + maxKeySize);
            Console.WriteLine("Interval between key size bits: " + 
                skipKeySize);
        }
	}
}
//
// This sample produces the following output:
//
// KeySizes retrieved from the Custom Keys object.
// Minimum key size bits: 64
// Maximum key size bits: 1024
// Interval between key size bits: 64
// 
// KeySizes retrieved from the System.Security.Cryptography.RijndaelManaged
// object.
// Minimum key size bits: 128
// Maximum key size bits: 256
// Interval between key size bits: 64
// rijn.blocksize:128
// 
// KeySizes retrieved from the
// System.Security.Cryptography.RSACryptoServiceProvider object.
// Minimum key size bits: 384
// Maximum key size bits: 16384
// Interval between key size bits: 8
// RSACryptoServiceProvider KeySize = 384
// This sample completed successfully; press Enter to exit.
//</Snippet1>