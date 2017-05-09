// <Snippet1>
using System;

class Example
{
   public static void Main( )
   {
      decimal[] values = { 123m, new Decimal(123000, 0, 0, false, 3), 
                           123.999m, 18446744073709551615.999m, 
                           18446744073709551616m, 9223372036854775807.999m, 
                           9223372036854775808m, -0.999m, -1m, 
                           -9223372036854775808.999m, 
                           -9223372036854775809m };
                     
      foreach (var value in values) {
         try {             
            long number = Decimal.ToInt64(value);
            Console.WriteLine("{0} --> {1}", value, number);       
         }
         catch (OverflowException e)
         {
             Console.WriteLine("{0}: {1}", e.GetType().Name, value);
         }   
      }
   }
}
// The example displays the following output:
//   123 --> 123
//   123.000 --> 123
//   123.999 --> 123
//   OverflowException: 18446744073709551615.999
//   OverflowException: 18446744073709551616
//   9223372036854775807.999 --> 9223372036854775807
//   OverflowException: 9223372036854775808
//   -0.999 --> 0
//   -1 --> -1
//   -9223372036854775808.999 --> -9223372036854775808
//   OverflowException: -9223372036854775809
// </Snippet1>
