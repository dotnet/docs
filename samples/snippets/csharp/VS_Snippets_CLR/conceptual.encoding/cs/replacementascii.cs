// <Snippet2>
using System;
using System.Text;

public class Example
{
   public static void Main()
   {
      Encoding enc = Encoding.ASCII;

      string str1 = "\u24C8 \u2075 \u221E";
      Console.WriteLine(str1);
      foreach (var ch in str1)
         Console.Write("{0} ", Convert.ToUInt16(ch).ToString("X4"));

      Console.WriteLine("\n");

      // Encode the original string using the ASCII encoder.
      byte[] bytes = enc.GetBytes(str1);
      Console.Write("Encoded bytes: ");
      foreach (var byt in bytes)
         Console.Write("{0:X2} ", byt);
      Console.WriteLine("\n");

      // Decode the ASCII bytes.
      string str2 = enc.GetString(bytes);
      Console.WriteLine($"Round-trip: {str1.Equals(str2)}");
      if (! str1.Equals(str2)) {
         Console.WriteLine(str2);
         foreach (var ch in str2)
            Console.Write("{0} ", Convert.ToUInt16(ch).ToString("X4"));

         Console.WriteLine();
      }
   }
}
// The example displays the following output:
//       Ⓢ ⁵ ∞
//       24C8 0020 2075 0020 221E
//
//       Encoded bytes: 3F 20 3F 20 3F
//
//       Round-trip: False
//       ? ? ?
//       003F 0020 003F 0020 003F
// </Snippet2>
