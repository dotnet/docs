// <Snippet1>
using System;
using System.Globalization;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      string[] hexStrings = { "80", "E293", "F9A2FF", "FFFFFFFF", 
                              "080", "0E293", "0F9A2FF", "0FFFFFFFF",  
                              "0080", "00E293", "00F9A2FF", "00FFFFFFFF" };
      BigInteger number = BigInteger.Zero;
                              
      foreach (string hexString in hexStrings)
      {
         if (BigInteger.TryParse(hexString, NumberStyles.AllowHexSpecifier,
                                 null, out number))
            Console.WriteLine("Converted 0x{0} to {1}.", hexString, number);
         else
            Console.WriteLine("Cannot convert '{0}' to a BigInteger.", hexString);
      }
   }
}
// The example displays the following output:
//       Converted 0x80 to -128.
//       Converted 0xE293 to -7533.
//       Converted 0xF9A2FF to -417025.
//       Converted 0xFFFFFFFF to -1.
//       Converted 0x080 to 128.
//       Converted 0x0E293 to 58003.
//       Converted 0x0F9A2FF to 16360191.
//       Converted 0x0FFFFFFFF to 4294967295.
//       Converted 0x0080 to 128.
//       Converted 0x00E293 to 58003.
//       Converted 0x00F9A2FF to 16360191.
//       Converted 0x00FFFFFFFF to 4294967295.
// </Snippet1>