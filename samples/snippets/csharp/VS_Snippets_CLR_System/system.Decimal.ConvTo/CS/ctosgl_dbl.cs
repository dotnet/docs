// <Snippet5>
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
            double dblValue = (double) value;
            Console.WriteLine("{0} ({1}) --> {2} ({3})", value,
                              value.GetType().Name, dblValue, 
                              dblValue.GetType().Name);
       } 
    }
}
// The example displays the following output:
//    0.0000000000000000000000000001 (Decimal) --> 1E-28 (Double)
//    0.0000000000123456789123456789 (Decimal) --> 1.23456789123457E-11 (Double)
//    123 (Decimal) --> 123 (Double)
//    123.000000 (Decimal) --> 123 (Double)
//    123456789.123456789 (Decimal) --> 123456789.123457 (Double)
//    123456789123456789123456789 (Decimal) --> 1.23456789123457E+26 (Double)
//    -79228162514264337593543950335 (Decimal) --> -7.92281625142643E+28 (Double)
//    79228162514264337593543950335 (Decimal) --> 7.92281625142643E+28 (Double)
// </Snippet5>
