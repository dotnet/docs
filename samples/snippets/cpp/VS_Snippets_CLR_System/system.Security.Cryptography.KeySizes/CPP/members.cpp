// This sample demonstrates how to use each member of the KeySizes class.
//<Snippet1>

using namespace System;
using namespace System::Security::Cryptography;

namespace CryptographySample
{
    ref class KeySizesMembers
    {
    public:
        static void Work()
        {
            // Initializes a new instance of the KeySizes class 
            // with the specified key values.
            //<Snippet2>
            int minSize = 64;
            int maxSize = 1024;
            int skipSize = 64;
            KeySizes^ keySizes = 
                gcnew KeySizes(minSize, maxSize, skipSize);
            //</Snippet2>

            // Show the values of the keys.
            ShowKeys(gcnew array<KeySizes^>(1) {keySizes},
                "Custom Keys");
                 
            // Create a new symmetric algorithm and display its 
            // key values.
            SymmetricAlgorithm^ symAlg = 
                SymmetricAlgorithm::Create();
            ShowKeys(symAlg->LegalKeySizes, symAlg->ToString());
            Console::WriteLine("rijn.blocksize:{0}", 
                    symAlg->BlockSize);

            // Create a new RSA algorithm and display its key values.
            RSACryptoServiceProvider^ rsaCSP = 
                   gcnew RSACryptoServiceProvider(384);
            ShowKeys(rsaCSP->LegalKeySizes, rsaCSP->ToString());
            Console::WriteLine("RSACryptoServiceProvider KeySize ="
                " {0}",
                    rsaCSP->KeySize);

            Console::WriteLine("This sample completed successfully; " 
                   "press Enter to exit.");
            Console::ReadLine();
        }

    private:
        // Display specified KeySize properties to the console.
        static void ShowKeys(array <KeySizes^>^ keySizes,
            String^ objectName)
        {
            // Retrieve the first KeySizes in the array.
            KeySizes^ firstKeySize = keySizes[0];

            // Retrieve the minimum key size in bits.
            //<Snippet3>
            int minKeySize = firstKeySize->MinSize;
            //</Snippet3>

            // Retrieve the maximum key size in bits.
            //<Snippet4>
            int maxKeySize = firstKeySize->MaxSize;
            //</Snippet4>

            // Retrieve the interval between valid key size in bits.
            //<Snippet5>
            int skipKeySize = firstKeySize->SkipSize;
            //</Snippet5>

            Console::Write("\n KeySizes retrieved from the ");
            Console::WriteLine("{0} object.", objectName);
            Console::WriteLine("Minimum key size bits: {0}", 
                minKeySize);
            Console::WriteLine("Maximum key size bits: {0}", 
                maxKeySize);
            Console::WriteLine("Interval between key size bits: {0}", 
                skipKeySize);            
        }
    };
}

using namespace CryptographySample;

int main()
{
    KeySizesMembers::Work();
}
//
// This sample produces the following output:
//
// KeySizes retrieved from the Custom Keys object.
// Minimum key size bits: 64
// Maximum key size bits: 1024
// Interval between key size bits: 64
// 
// KeySizes retrieved from the 
//  System.Security.Cryptography.RijndaelManaged object.
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