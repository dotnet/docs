//<Snippet2>
using System;

class Example
{
   public static void Main()
   {
      // Define an array of Decimal values.
      Decimal[] values = { 1M, 100000000000000M, 10000000000000000000000000000M,
                           100000000000000.00000000000000M, 1.0000000000000000000000000000M,
                           123456789M, 0.123456789M, 0.000000000123456789M,
                           0.000000000000000000123456789M, 4294967295M,
                           18446744073709551615M, Decimal.MaxValue,
                           Decimal.MinValue, -7.9228162514264337593543950335M }; 
      
      Console.WriteLine("{0,31}  {1,10:X8}{2,10:X8}{3,10:X8}{4,10:X8}", 
                        "Argument", "Bits[3]", "Bits[2]", "Bits[1]", 
                        "Bits[0]" );
      Console.WriteLine( "{0,31}  {1,10:X8}{2,10:X8}{3,10:X8}{4,10:X8}", 
                         "--------", "-------", "-------", "-------", 
                         "-------" );

      // Iterate each element and display its binary representation
      foreach (var value in values) {
        int[] bits = decimal.GetBits(value);
        Console.WriteLine("{0,31}  {1,10:X8}{2,10:X8}{3,10:X8}{4,10:X8}", 
                          value, bits[3], bits[2], bits[1], bits[0]);
      }
   }
}
// The example displays the following output:
//                           Argument     Bits[3]   Bits[2]   Bits[1]   Bits[0]
//                           --------     -------   -------   -------   -------
//                                  1    00000000  00000000  00000000  00000001
//                    100000000000000    00000000  00000000  00005AF3  107A4000
//      10000000000000000000000000000    00000000  204FCE5E  3E250261  10000000
//     100000000000000.00000000000000    000E0000  204FCE5E  3E250261  10000000
//     1.0000000000000000000000000000    001C0000  204FCE5E  3E250261  10000000
//                          123456789    00000000  00000000  00000000  075BCD15
//                        0.123456789    00090000  00000000  00000000  075BCD15
//               0.000000000123456789    00120000  00000000  00000000  075BCD15
//      0.000000000000000000123456789    001B0000  00000000  00000000  075BCD15
//                         4294967295    00000000  00000000  00000000  FFFFFFFF
//               18446744073709551615    00000000  00000000  FFFFFFFF  FFFFFFFF
//      79228162514264337593543950335    00000000  FFFFFFFF  FFFFFFFF  FFFFFFFF
//     -79228162514264337593543950335    80000000  FFFFFFFF  FFFFFFFF  FFFFFFFF
//    -7.9228162514264337593543950335    801C0000  FFFFFFFF  FFFFFFFF  FFFFFFFF
//</Snippet2>
