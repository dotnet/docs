//<Snippet2>
using System;

class Example
{
    public static void Main()
    {
        // Define an array of 32-bit integer values.
        int[] values = { int.MinValue, int.MaxValue, 0xFFFFFF,
                         123456789, -1000000000 };
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
//    -2147483648 (Int32) --> -2147483648 (Decimal)
//    2147483647 (Int32) --> 2147483647 (Decimal)
//    16777215 (Int32) --> 16777215 (Decimal)
//    123456789 (Int32) --> 123456789 (Decimal)
//    -1000000000 (Int32) --> -1000000000 (Decimal)
//</Snippet2>
