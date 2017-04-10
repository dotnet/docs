//<Snippet1>
using System;
using System.Security.Cryptography;
namespace SymmetricAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            AesManaged aes = new AesManaged();
            Console.WriteLine("AesManaged ");
            KeySizes[] ks = aes.LegalKeySizes;
            foreach (KeySizes k in ks)
            {
                Console.WriteLine("\tLegal min key size = " + k.MinSize);
                Console.WriteLine("\tLegal max key size = " + k.MaxSize);
            }
            ks = aes.LegalBlockSizes;
            foreach (KeySizes k in ks)
            {
                Console.WriteLine("\tLegal min block size = " + k.MinSize);
                Console.WriteLine("\tLegal max block size = " + k.MaxSize);
            }
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            Console.WriteLine("DESCryptoServiceProvider ");
            ks = des.LegalKeySizes;
            foreach (KeySizes k in ks)
            {
                Console.WriteLine("\tLegal min key size = " + k.MinSize);
                Console.WriteLine("\tLegal max key size = " + k.MaxSize);
            }
            ks = des.LegalBlockSizes;
            foreach (KeySizes k in ks)
            {
                Console.WriteLine("\tLegal min block size = " + k.MinSize);
                Console.WriteLine("\tLegal max block size = " + k.MaxSize);
            }
            RC2CryptoServiceProvider rc2 = new RC2CryptoServiceProvider();
            Console.WriteLine("RC2CryptoServiceProvider ");
            ks = rc2.LegalKeySizes;
            foreach (KeySizes k in ks)
            {
                Console.WriteLine("\tLegal min key size = " + k.MinSize);
                Console.WriteLine("\tLegal max key size = " + k.MaxSize);
            }
            ks = rc2.LegalBlockSizes;
            foreach (KeySizes k in ks)
            {
                Console.WriteLine("\tLegal min block size = " + k.MinSize);
                Console.WriteLine("\tLegal max block size = " + k.MaxSize);
            }
            RijndaelManaged rij = new RijndaelManaged();
            Console.WriteLine("RijndaelManaged ");
            ks = rij.LegalKeySizes;
            foreach (KeySizes k in ks)
            {
                Console.WriteLine("\tLegal min key size = " + k.MinSize);
                Console.WriteLine("\tLegal max key size = " + k.MaxSize);
            }
            ks = rij.LegalBlockSizes;
            foreach (KeySizes k in ks)
            {
                Console.WriteLine("\tLegal min block size = " + k.MinSize);
                Console.WriteLine("\tLegal max block size = " + k.MaxSize);
            }
            TripleDESCryptoServiceProvider tsp = new TripleDESCryptoServiceProvider();
            Console.WriteLine("TripleDESCryptoServiceProvider ");
            ks = tsp.LegalKeySizes;
            foreach (KeySizes k in ks)
            {
                Console.WriteLine("\tLegal min key size = " + k.MinSize);
                Console.WriteLine("\tLegal max key size = " + k.MaxSize);
            }
            ks = tsp.LegalBlockSizes;
            foreach (KeySizes k in ks)
            {
                Console.WriteLine("\tLegal min block size = " + k.MinSize);
                Console.WriteLine("\tLegal max block size = " + k.MaxSize);
            }
            
        }
    }
}
//This sample produces the following output:
//AesManaged
//        Legal min key size = 128
//        Legal max key size = 256
//        Legal min block size = 128
//        Legal max block size = 128
//DESCryptoServiceProvider
//        Legal min key size = 64
//        Legal max key size = 64
//        Legal min block size = 64
//        Legal max block size = 64
//RC2CryptoServiceProvider
//        Legal min key size = 40
//        Legal max key size = 128
//        Legal min block size = 64
//        Legal max block size = 64
//RijndaelManaged
//        Legal min key size = 128
//        Legal max key size = 256
//        Legal min block size = 128
//        Legal max block size = 256
//TripleDESCryptoServiceProvider
//        Legal min key size = 128
//        Legal max key size = 192
//        Legal min block size = 64
//        Legal max block size = 64
//</Snippet1>

