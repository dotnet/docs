// The following code example determines the number of bytes required to encode a character array,
// encodes the characters, and displays the resulting bytes.

// <Snippet2>
using System;
using System.Text;

public class Example
{
   public static void Main()  
   {
      // Create a character array.
      string gkNumber = Char.ConvertFromUtf32(0x10154);
      char[] chars = new char[] { 'z', 'a', '\u0306', '\u01FD', '\u03B2', 
                                  gkNumber[0], gkNumber[1] };

      // Get UTF-8 and UTF-16 encoders.
      Encoding utf8 = Encoding.UTF8;
      Encoding utf16 = Encoding.Unicode;
      
      // Display the original characters' code units.
      Console.WriteLine("Original UTF-16 code units:");
      byte[] utf16Bytes = utf16.GetBytes(chars);
      foreach (var utf16Byte in utf16Bytes)
         Console.Write("{0:X2} ", utf16Byte);
      Console.WriteLine();
         
      // Display the number of bytes required to encode the array.
      int reqBytes  = utf8.GetByteCount(chars);
      Console.WriteLine("\nExact number of bytes required: {0}", 
                    reqBytes);

      // Display the maximum byte count.
      int maxBytes = utf8.GetMaxByteCount(chars.Length);
      Console.WriteLine("Maximum number of bytes required: {0}\n", 
                        maxBytes);

      // Encode the array of chars.
      byte[] utf8Bytes = utf8.GetBytes(chars);

      // Display all the UTF-8-encoded bytes.
      Console.WriteLine("UTF-8-encoded code units:");
      foreach (var utf8Byte in utf8Bytes)
         Console.Write("{0:X2} ", utf8Byte);
      Console.WriteLine();
   }
}
// The example displays the following output:
//       Original UTF-16 code units:
//       7A 00 61 00 06 03 FD 01 B2 03 00 D8 54 DD
//       
//       Exact number of bytes required: 12
//       Maximum number of bytes required: 24
//       
//       UTF-8-encoded code units:
//       7A 61 CC 86 C7 BD CE B2 F0 90 85 94
// </Snippet2>
