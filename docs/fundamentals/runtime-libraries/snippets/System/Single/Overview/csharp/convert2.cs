﻿// <Snippet21>
using System;

public class Example
{
   public static void Main()
   {
      float[] values = { Single.MinValue, -67890.1234f, -12345.6789f,
                         12345.6789f, 67890.1234f, Single.MaxValue,
                         Single.NaN, Single.PositiveInfinity,
                         Single.NegativeInfinity };
      checked {
         foreach (var value in values) {
            try {
                Int64 lValue = (long) value;
                Console.WriteLine("{0} ({1}) --> {2} (0x{2:X16}) ({3})",
                                  value, value.GetType().Name,
                                  lValue, lValue.GetType().Name);
            }
            catch (OverflowException) {
               Console.WriteLine("Unable to convert {0} to Int64.", value);
            }
            try {
                UInt64 ulValue = (ulong) value;
                Console.WriteLine("{0} ({1}) --> {2} (0x{2:X16}) ({3})",
                                  value, value.GetType().Name,
                                  ulValue, ulValue.GetType().Name);
            }
            catch (OverflowException) {
               Console.WriteLine("Unable to convert {0} to UInt64.", value);
            }
            try {
                Decimal dValue = (decimal) value;
                Console.WriteLine("{0} ({1}) --> {2} ({3})",
                                  value, value.GetType().Name,
                                  dValue, dValue.GetType().Name);
            }
            catch (OverflowException) {
               Console.WriteLine("Unable to convert {0} to Decimal.", value);
            }

            Double dblValue = value;
            Console.WriteLine("{0} ({1}) --> {2} ({3})",
                              value, value.GetType().Name,
                              dblValue, dblValue.GetType().Name);
            Console.WriteLine();
         }
      }
   }
}
// The example displays the following output for conversions performed
// in a checked context:
//       Unable to convert -3.402823E+38 to Int64.
//       Unable to convert -3.402823E+38 to UInt64.
//       Unable to convert -3.402823E+38 to Decimal.
//       -3.402823E+38 (Single) --> -3.40282346638529E+38 (Double)
//
//       -67890.13 (Single) --> -67890 (0xFFFFFFFFFFFEF6CE) (Int64)
//       Unable to convert -67890.13 to UInt64.
//       -67890.13 (Single) --> -67890.12 (Decimal)
//       -67890.13 (Single) --> -67890.125 (Double)
//
//       -12345.68 (Single) --> -12345 (0xFFFFFFFFFFFFCFC7) (Int64)
//       Unable to convert -12345.68 to UInt64.
//       -12345.68 (Single) --> -12345.68 (Decimal)
//       -12345.68 (Single) --> -12345.6787109375 (Double)
//
//       12345.68 (Single) --> 12345 (0x0000000000003039) (Int64)
//       12345.68 (Single) --> 12345 (0x0000000000003039) (UInt64)
//       12345.68 (Single) --> 12345.68 (Decimal)
//       12345.68 (Single) --> 12345.6787109375 (Double)
//
//       67890.13 (Single) --> 67890 (0x0000000000010932) (Int64)
//       67890.13 (Single) --> 67890 (0x0000000000010932) (UInt64)
//       67890.13 (Single) --> 67890.12 (Decimal)
//       67890.13 (Single) --> 67890.125 (Double)
//
//       Unable to convert 3.402823E+38 to Int64.
//       Unable to convert 3.402823E+38 to UInt64.
//       Unable to convert 3.402823E+38 to Decimal.
//       3.402823E+38 (Single) --> 3.40282346638529E+38 (Double)
//
//       Unable to convert NaN to Int64.
//       Unable to convert NaN to UInt64.
//       Unable to convert NaN to Decimal.
//       NaN (Single) --> NaN (Double)
//
//       Unable to convert Infinity to Int64.
//       Unable to convert Infinity to UInt64.
//       Unable to convert Infinity to Decimal.
//       Infinity (Single) --> Infinity (Double)
//
//       Unable to convert -Infinity to Int64.
//       Unable to convert -Infinity to UInt64.
//       Unable to convert -Infinity to Decimal.
//       -Infinity (Single) --> -Infinity (Double)
// The example displays the following output for conversions performed
// in an unchecked context:
//       -3.402823E+38 (Single) --> -9223372036854775808 (0x8000000000000000) (Int64)
//       -3.402823E+38 (Single) --> 9223372036854775808 (0x8000000000000000) (UInt64)
//       Unable to convert -3.402823E+38 to Decimal.
//       -3.402823E+38 (Single) --> -3.40282346638529E+38 (Double)
//
//       -67890.13 (Single) --> -67890 (0xFFFFFFFFFFFEF6CE) (Int64)
//       -67890.13 (Single) --> 18446744073709483726 (0xFFFFFFFFFFFEF6CE) (UInt64)
//       -67890.13 (Single) --> -67890.12 (Decimal)
//       -67890.13 (Single) --> -67890.125 (Double)
//
//       -12345.68 (Single) --> -12345 (0xFFFFFFFFFFFFCFC7) (Int64)
//       -12345.68 (Single) --> 18446744073709539271 (0xFFFFFFFFFFFFCFC7) (UInt64)
//       -12345.68 (Single) --> -12345.68 (Decimal)
//       -12345.68 (Single) --> -12345.6787109375 (Double)
//
//       12345.68 (Single) --> 12345 (0x0000000000003039) (Int64)
//       12345.68 (Single) --> 12345 (0x0000000000003039) (UInt64)
//       12345.68 (Single) --> 12345.68 (Decimal)
//       12345.68 (Single) --> 12345.6787109375 (Double)
//
//       67890.13 (Single) --> 67890 (0x0000000000010932) (Int64)
//       67890.13 (Single) --> 67890 (0x0000000000010932) (UInt64)
//       67890.13 (Single) --> 67890.12 (Decimal)
//       67890.13 (Single) --> 67890.125 (Double)
//
//       3.402823E+38 (Single) --> -9223372036854775808 (0x8000000000000000) (Int64)
//       3.402823E+38 (Single) --> 0 (0x0000000000000000) (UInt64)
//       Unable to convert 3.402823E+38 to Decimal.
//       3.402823E+38 (Single) --> 3.40282346638529E+38 (Double)
//
//       NaN (Single) --> -9223372036854775808 (0x8000000000000000) (Int64)
//       NaN (Single) --> 0 (0x0000000000000000) (UInt64)
//       Unable to convert NaN to Decimal.
//       NaN (Single) --> NaN (Double)
//
//       Infinity (Single) --> -9223372036854775808 (0x8000000000000000) (Int64)
//       Infinity (Single) --> 0 (0x0000000000000000) (UInt64)
//       Unable to convert Infinity to Decimal.
//       Infinity (Single) --> Infinity (Double)
//
//       -Infinity (Single) --> -9223372036854775808 (0x8000000000000000) (Int64)
//       -Infinity (Single) --> 9223372036854775808 (0x8000000000000000) (UInt64)
//       Unable to convert -Infinity to Decimal.
//       -Infinity (Single) --> -Infinity (Double)
// </Snippet21>
