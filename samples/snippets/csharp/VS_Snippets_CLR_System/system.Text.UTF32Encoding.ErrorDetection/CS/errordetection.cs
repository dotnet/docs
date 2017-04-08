// <Snippet1>
using System;
using System.Text;

public class Example
{
   public static void Main()
   {
     // Create a UTF32Encoding object with error detection enabled.
      var encExc = new UTF32Encoding(! BitConverter.IsLittleEndian, true, true);
      // Create a UTF32Encoding object with error detection disabled.
      var encRepl = new UTF32Encoding(! BitConverter.IsLittleEndian, true, false);

      // Create a byte arrays from a string, and add an invalid surrogate pair, as follows.
      //    Latin Small Letter Z (U+007A)
      //    Latin Small Letter A (U+0061)
      //    Combining Breve (U+0306)
      //    Latin Small Letter AE With Acute (U+01FD)
      //    Greek Small Letter Beta (U+03B2)
      //    a high-surrogate value (U+D8FF)
      //    an invalid low surrogate (U+01FF)
      String s = "za\u0306\u01FD\u03B2";

      // Encode the string using little-endian byte order.
      int index = encExc.GetByteCount(s);
      Byte[] bytes = new Byte[index + 4];
      encExc.GetBytes(s, 0, s.Length, bytes, 0);
      bytes[index] = 0xFF;
      bytes[index + 1] = 0xD8;
      bytes[index + 2] = 0xFF;
      bytes[index + 3] = 0x01;

      // Decode the byte array with error detection.
      Console.WriteLine("Decoding with error detection:");
      PrintDecodedString(bytes, encExc);

      // Decode the byte array without error detection.
      Console.WriteLine("Decoding without error detection:");
      PrintDecodedString(bytes, encRepl);
   }

   // Decode the bytes and display the string.
   public static void PrintDecodedString(Byte[] bytes, Encoding enc)
   {
      try {
         Console.WriteLine("   Decoded string: {0}", enc.GetString(bytes, 0, bytes.Length));
      }
      catch (DecoderFallbackException e) {
         Console.WriteLine(e.ToString());
      }
      Console.WriteLine();
   }
}
// The example displays the following output:
//    Decoding with error detection:
//    System.Text.DecoderFallbackException: Unable to translate bytes [FF][D8][FF][01] at index
//    20 from specified code page to Unicode.
//       at System.Text.DecoderExceptionFallbackBuffer.Throw(Byte[] bytesUnknown, Int32 index)
//       at System.Text.DecoderExceptionFallbackBuffer.Fallback(Byte[] bytesUnknown, Int32 index
//    )
//       at System.Text.DecoderFallbackBuffer.InternalFallback(Byte[] bytes, Byte* pBytes)
//       at System.Text.UTF32Encoding.GetCharCount(Byte* bytes, Int32 count, DecoderNLS baseDeco
//    der)
//       at System.Text.UTF32Encoding.GetString(Byte[] bytes, Int32 index, Int32 count)
//       at Example.PrintDecodedString(Byte[] bytes, Encoding enc)
//
//    Decoding without error detection:
//       Decoded string: zăǽβ�
// </Snippet1>