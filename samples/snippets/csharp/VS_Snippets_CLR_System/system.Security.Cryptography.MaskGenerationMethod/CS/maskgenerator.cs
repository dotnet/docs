// This sample demonstrates how to derive from the MaskGenerationMethod class.
//<Snippet1>
using System;
using System.Security.Cryptography;

namespace Contoso
{
    //<Snippet2>
    class MaskGenerator : System.Security.Cryptography.MaskGenerationMethod
    {
        private String HashNameValue;

        // Initialize a mask to encrypt using the SHA1 algorithm.
        public MaskGenerator() 
        {
            HashNameValue = "SHA1";
        }
        //</Snippet2>

        // Create a mask with the specified seed.
        //<Snippet3>
        override public byte[] GenerateMask(byte[] seed, int maskLength)
        {
            HashAlgorithm hash;
            byte[] rgbCounter = new byte[4];
            byte[] targetRgb = new byte[maskLength];
            uint counter = 0;

            for (int inc = 0; inc < targetRgb.Length; )
            {
                ConvertIntToByteArray(counter++, ref rgbCounter);
                hash = (HashAlgorithm)
                    CryptoConfig.CreateFromName(HashNameValue);

                byte[] temp = new byte[4 + seed.Length];
                Buffer.BlockCopy(rgbCounter, 0, temp, 0, 4);
                Buffer.BlockCopy(seed, 0, temp, 4, seed.Length);
                hash.ComputeHash(temp);

                if (targetRgb.Length - inc > hash.HashSize/8) 
                {
                    Buffer.BlockCopy(
                        hash.Hash,
                        0,
                        targetRgb,
                        inc,
                        hash.Hash.Length);
                }
                else
                {
                    Buffer.BlockCopy(
                        hash.Hash,
                        0,
                        targetRgb,
                        inc,
                        targetRgb.Length - inc);
                }
                inc += hash.Hash.Length;
            }
            return targetRgb;
        }
        //</Snippet3>

        // Convert the specified integer to the byte array.
        private void ConvertIntToByteArray(
            uint sourceInt,
            ref byte[] targetBytes)
        {
            uint remainder;
            int inc = 0;

            // Clear the array prior to filling it.
            Array.Clear(targetBytes, 0, targetBytes.Length);

            while (sourceInt > 0) 
            {
                remainder = sourceInt % 256;
                targetBytes[3 - inc] = (byte) remainder;
                sourceInt = (sourceInt - remainder)/256;
                inc++;
            }
        }
    }
// This class demonstrates how to create the MaskGenerator class 
// and call its GenerateMask member.
    class MaskGeneratorImpl
    {
      public static void Main(string[] args)
      {
          byte[] seed = new byte[] {0x01, 0x02, 0x03, 0x04};
          int length = 16;
          MaskGenerator maskGenerator = new MaskGenerator();
          byte[] mask = maskGenerator.GenerateMask(seed, length);
          Console.WriteLine("Generated the following mask:");
          Console.WriteLine(System.Text.Encoding.ASCII.GetString(mask));

          Console.WriteLine("This sample completed successfully; " +
                "press Enter to exit.");
          Console.ReadLine();
      }
  }
}
//
// This sample produces the following output:
//
// Generated the following mask:
// ?"TFd(?~OtO?
// This sample completed successfully; press Enter to exit.
//</Snippet1>