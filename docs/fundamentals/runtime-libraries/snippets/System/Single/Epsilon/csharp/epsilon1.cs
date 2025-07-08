// <Snippet6>
using System;

public class Example2
{
   public static void Main()
   {
      float[] values = { 0.0f, Single.Epsilon };
      foreach (var value in values) {
         Console.WriteLine(GetComponentParts(value));
         Console.WriteLine();
      }   
   }

   private static string GetComponentParts(float value)
   {
      string result = String.Format("{0:R}: ", value);
      int indent = result.Length;

      // Convert the single to a 4-byte array.
      byte[] bytes = BitConverter.GetBytes(value);
      int formattedSingle = BitConverter.ToInt32(bytes, 0);
      
      // Get the sign bit (byte 3, bit 7).
      result += String.Format("Sign: {0}\n", 
                              (formattedSingle >> 31) != 0 ? "1 (-)" : "0 (+)");

      // Get the exponent (byte 2 bit 7 to byte 3, bits 6)
      int exponent =  (formattedSingle >> 23) & 0x000000FF;
      int adjustment = (exponent != 0) ? 127 : 126;
      result += String.Format("{0}Exponent: 0x{1:X4} ({1})\n", new String(' ', indent), exponent - adjustment);

      // Get the significand (bits 0-22)
      long significand = exponent != 0 ? 
                         ((formattedSingle & 0x007FFFFF) | 0x800000) : 
                         (formattedSingle & 0x007FFFFF); 
      result += String.Format("{0}Mantissa: 0x{1:X13}\n", new String(' ', indent), significand);    
      return result;   
   }
}
//       // The example displays the following output:
//       0: Sign: 0 (+)
//          Exponent: 0xFFFFFF82 (-126)
//          Mantissa: 0x0000000000000
//       
//       
//       1.401298E-45: Sign: 0 (+)
//                     Exponent: 0xFFFFFF82 (-126)
//                     Mantissa: 0x0000000000001
// </Snippet6>                       
