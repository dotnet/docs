// <Snippet2>
using System;

class Example
{
    public static void Main( )
    {
        // Define an array of decimal values.
        decimal[] values = { 0.0000000000000000000000000001M, 
                             0.0000000000123456789123456789M,
                             123M, new decimal(123000000, 0, 0, false, 6),
                             123456789.123456789M, 
                             123456789123456789123456789M, 
                             decimal.MinValue, decimal.MaxValue };
        // Convert each value to a double.
        foreach (var value in values) {
            float dblValue = (float) value;
            Console.WriteLine("{0} ({1}) --> {2} ({3})", value,
                              value.GetType().Name, dblValue, 
                              dblValue.GetType().Name);
       } 
    }
}
// The example displays the following output:
//    0.0000000000000000000000000001 (Decimal) --> 1E-28 (Single)
//    0.0000000000123456789123456789 (Decimal) --> 1.234568E-11 (Single)
//    123 (Decimal) --> 123 (Single)
//    123.000000 (Decimal) --> 123 (Single)
//    123456789.123456789 (Decimal) --> 1.234568E+08 (Single)
//    123456789123456789123456789 (Decimal) --> 1.234568E+26 (Single)
//    -79228162514264337593543950335 (Decimal) --> -7.922816E+28 (Single)
//    79228162514264337593543950335 (Decimal) --> 7.922816E+28 (Single)
// </Snippet2>
