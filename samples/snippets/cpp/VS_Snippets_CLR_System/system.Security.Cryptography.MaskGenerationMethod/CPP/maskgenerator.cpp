// This sample demonstrates how to derive from 
// the MaskGenerationMethod class.
//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Security::Cryptography;

namespace Contoso
{
    //<Snippet2>
    ref class MaskGenerator: MaskGenerationMethod
    {
    private:
        String^ hashNameValue;

    public:
        // Initialize a mask to encrypt using the SHA1 algorithm.
        MaskGenerator()
        {
            hashNameValue = "SHA1";
        }

        //</Snippet2>
        // Create a mask with the specified seed.
        //<Snippet3>
        virtual array<Byte>^ GenerateMask(array<Byte>^ seed, int maskLength) override
        {
            HashAlgorithm^ hash;
            array<Byte>^ rgbCounter = gcnew array<Byte>(4);
            array<Byte>^ targetRgb = gcnew array<Byte>(maskLength);
            UInt32 counter = 0;
            for (int inc = 0; inc < targetRgb->Length; )
            {
                ConvertIntToByteArray(counter++, rgbCounter);
                hash = (HashAlgorithm^)CryptoConfig::CreateFromName(
                    hashNameValue);
                array<Byte>^ temp = gcnew array<Byte>(
                    4 + seed->Length);
                Buffer::BlockCopy(rgbCounter, 0, temp, 0, 4);
                Buffer::BlockCopy(seed, 0, temp, 4, seed->Length);
                hash->ComputeHash(temp);
                if (targetRgb->Length - inc > hash->HashSize / 8)
                {
                    Buffer::BlockCopy(hash->Hash, 0, targetRgb, inc,
                        hash->Hash->Length);
                }
                else
                {
                    Buffer::BlockCopy(hash->Hash, 0, targetRgb, inc,
                        targetRgb->Length - inc);
                }

                inc += hash->Hash->Length;
            }
            return targetRgb;
        }

    private:
        //</Snippet3>
        // Convert the specified integer to the byte array.
        void ConvertIntToByteArray(UInt32 source,
            array<Byte>^ targetBytes)
        {
            UInt32 remainder;
            int inc = 0;

            // Clear the array prior to filling it.
            Array::Clear(targetBytes, 0, targetBytes->Length);
            while (source > 0)
            {
                remainder = source % 256;
                targetBytes[ 3 - inc ] = (Byte)remainder;
                source = (source - remainder) / 256;
                inc++;
            }
        }
    };

    // This class demonstrates how to create the MaskGenerator class 
    // and call its GenerateMask member.
    ref class MaskGeneratorImpl
    {
    public:
        void static Work()
        {
            array<Byte>^ seed = gcnew array<Byte>(4){
                0x01,0x02,0x03,0x04};
            int length = 16;
            MaskGenerator^ maskGenerator = gcnew MaskGenerator;
            array<Byte>^ mask = maskGenerator->GenerateMask(seed,
                length);
            Console::WriteLine("Generated the following mask:");
            Console::WriteLine(System::Text::Encoding::
                ASCII::get()->GetString(mask));
            Console::WriteLine("This sample completed successfully;"
                " press Enter to exit.");
            Console::ReadLine();
        }
    };
}

void main()
{
    Contoso::MaskGeneratorImpl::Work();
}

//
// This sample produces the following output:
//
// Generated the following mask:
// ?"TFd(?~OtO?
// This sample completed successfully; press Enter to exit.
//</Snippet1>
