// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      // Create an Integer from a 4-byte array.
      Byte[] bytes1 = { 0xEC, 0x00, 0x00, 0x00 };
      Console.WriteLine("{0}--> 0x{1:X4} ({1:N0})", FormatBytes(bytes1),
                                      BitConverter.ToInt32(bytes1, 0));
      // Create an Integer from the upper four bytes of a byte array.
      Byte[] bytes2 = BitConverter.GetBytes(Int64.MaxValue / 2);
      Console.WriteLine("{0}--> 0x{1:X4} ({1:N0})", FormatBytes(bytes2),
                                      BitConverter.ToInt32(bytes2, 4));
      
      // Round-trip an integer value.
      int original = (int) Math.Pow(16, 3);
      Byte[] bytes3 = BitConverter.GetBytes(original);
      int restored = BitConverter.ToInt32(bytes3, 0);
      Console.WriteLine("0x{0:X4} ({0:N0}) --> {1} --> 0x{2:X4} ({2:N0})", original, 
                        FormatBytes(bytes3), restored);
   }

   private static string FormatBytes(Byte[] bytes)
   {
       string value = "";
       foreach (var byt in bytes)
          value += String.Format("{0:X2} ", byt);

       return value;
   }
}
// The example displays the following output:
//       EC 00 00 00 --> 0x00EC (236)
//       FF FF FF FF FF FF FF 3F --> 0x3FFFFFFF (1,073,741,823)
//       0x1000 (4,096) --> 00 10 00 00  --> 0x1000 (4,096)
// </Snippet1>
