//<Snippet3>
using System;

class Example
{
    public static void Main()
    {
        // Define an array of 16-bit unsigned integer values.
        ushort[] values = { ushort.MinValue, ushort.MaxValue,     
                            0xFFF, 12345, 40000 };
        // Convert each value to a Decimal.
        foreach (var value in values) {
           Decimal decValue = value;
           Console.WriteLine("{0} ({1}) --> {2} ({3})", value,
                             value.GetType().Name, decValue,
                             decValue.GetType().Name);         
        }
    }
}
// The example displays the following output:
//       0 (UInt16) --> 0 (Decimal)
//       65535 (UInt16) --> 65535 (Decimal)
//       4095 (UInt16) --> 4095 (Decimal)
//       12345 (UInt16) --> 12345 (Decimal)
//       40000 (UInt16) --> 40000 (Decimal)
// </Snippet3>

