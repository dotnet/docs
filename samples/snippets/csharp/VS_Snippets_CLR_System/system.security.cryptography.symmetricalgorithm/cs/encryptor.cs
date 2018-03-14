//<snippet1>
using System;
using System.Security.Cryptography;
using System.Text;

class EncryptorExample
{
     private static string quote =
         "Things may come to those who wait, but only the " +
         "things left by those who hustle. -- Abraham Lincoln";

     public static void Main()
     {
         AesCryptoServiceProvider aesCSP = new AesCryptoServiceProvider();

         aesCSP.GenerateKey();
         aesCSP.GenerateIV();
         byte[] encQuote = EncryptString(aesCSP, quote);

         Console.WriteLine("Encrypted Quote:\n");
         Console.WriteLine(Convert.ToBase64String(encQuote));

         Console.WriteLine("\nDecrypted Quote:\n");
         Console.WriteLine(DecryptBytes(aesCSP, encQuote));
     }

     //<snippet2>
     public static byte[] EncryptString(SymmetricAlgorithm symAlg, string inString)
     {
         byte[] inBlock = UnicodeEncoding.Unicode.GetBytes(inString);
         ICryptoTransform xfrm = symAlg.CreateEncryptor();
         byte[] outBlock = xfrm.TransformFinalBlock(inBlock, 0, inBlock.Length);

         return outBlock;
     }
     //</snippet2>

     //<snippet3>
     public static string DecryptBytes(SymmetricAlgorithm symAlg, byte[] inBytes)
     {
         ICryptoTransform xfrm = symAlg.CreateDecryptor();
         byte[] outBlock = xfrm.TransformFinalBlock(inBytes, 0, inBytes.Length);

         return UnicodeEncoding.Unicode.GetString(outBlock);
     }
     //</snippet3>
}
//</snippet1>
