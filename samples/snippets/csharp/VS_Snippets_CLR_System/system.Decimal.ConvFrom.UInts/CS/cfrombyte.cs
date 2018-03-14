// <Snippet4>
using System;

class Example
{
    public static void Main()
    {
        // Define an array of byte values.
        byte[] values = { byte.MinValue, byte.MaxValue, 
                          0x3F, 123, 200 };   
        // Convert each value to a Decimal.
        foreach (var value in values) {
           decimal decValue = value;
           Console.WriteLine("{0} ({1}) --> {2} ({3})", value,
                             value.GetType().Name, decValue,
                             decValue.GetType().Name);         
        }
    }
}
// The example displays the following output:
//       0 (Byte) --> 0 (Decimal)
//       255 (Byte) --> 255 (Decimal)
//       63 (Byte) --> 63 (Decimal)
//       123 (Byte) --> 123 (Decimal)
//       200 (Byte) --> 200 (Decimal)
//</Snippet4>
