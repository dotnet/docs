// <Snippet1>
 using System;
 using System.Text;
 public class dec
 {
     public static void Main()
     {
         // These bytes in UTF-8 correspond to 3 different Unicode
         // characters: space (U+0020), # (U+0023), and the biohazard
         // symbol (U+2623).  Note the biohazard symbol requires 3 bytes
         // in UTF-8 (hexadecimal e2, 98, a3).  Decoders store state across
         // multiple calls to GetChars, handling the case when one char
         // is in multiple byte arrays.
         byte[] bytes1 = { 0x20, 0x23, 0xe2 };
         byte[] bytes2 = { 0x98, 0xa3 };
         char[] chars = new char[3];

         Decoder d = Encoding.UTF8.GetDecoder();
         int charLen = d.GetChars(bytes1, 0, bytes1.Length, chars, 0);
         // The value of charLen should be 2 now.
         charLen += d.GetChars(bytes2, 0, bytes2.Length, chars, charLen);
         foreach(char c in chars)
             Console.Write("U+{0:X4}  ", (ushort)c);
     }
 }
// </Snippet1>

