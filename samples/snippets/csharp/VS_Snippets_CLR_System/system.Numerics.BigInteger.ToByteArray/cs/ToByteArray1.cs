// <Snippet1>
using System;
using System.Numerics;

public class Example
{
   static byte[] bytes;
   
   public static void Main()
   {
      BigInteger[] numbers = { BigInteger.MinusOne, BigInteger.One, 
                               BigInteger.Zero, 120, 128, 255, 1024, 
                               Int64.MinValue, Int64.MaxValue, 
                               BigInteger.Parse("90123123981293054321") };
      foreach (BigInteger number in numbers)
      {
         bytes = number.ToByteArray();
         Console.Write("{0} ({1}) -> ", number, number.ToString(GetSpecifier()));
         Console.Write("{0} bytes: ", bytes.Length);
         foreach (byte byteValue in bytes)
            Console.Write("{0:X2} ", byteValue);

         Console.WriteLine();
      }   
   }

   private static string GetSpecifier()
   {
      return "X" + (bytes.Length * 2).ToString();
   }
}
// The example displays the following output:
//    -1 (FF) -> 1 bytes: FF
//    1 (01) -> 1 bytes: 01
//    0 (00) -> 1 bytes: 00
//    120 (78) -> 1 bytes: 78
//    128 (0080) -> 2 bytes: 80 00
//    255 (00FF) -> 2 bytes: FF 00
//    1024 (0400) -> 2 bytes: 00 04
//    -9223372036854775808 (8000000000000000) -> 8 bytes: 00 00 00 00 00 00 00 80
//    9223372036854775807 (7FFFFFFFFFFFFFFF) -> 8 bytes: FF FF FF FF FF FF FF 7F
//    90123123981293054321 (04E2B5A7C4A975E971) -> 9 bytes: 71 E9 75 A9 C4 A7 B5 E2 04
// </Snippet1>