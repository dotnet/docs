// <Snippet1>
using System;

class Example
{
   public static void Main( )
   {
      decimal[] values = { 123m, new decimal(123000, 0, 0, false, 3), 
                           123.999m, 4294967295.999m, 4294967296m,
                           4294967296m, 2147483647.999m, 2147483648m, 
                           -0.999m, -1m, -2147483648.999m, -2147483649m };

      foreach (var value in values) {
         try {
            int number = Decimal.ToInt32(value);
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
//      123 --> 123
//      123.000 --> 123
//      123.999 --> 123
//      OverflowException: 4294967295.999
//      OverflowException: 4294967296
//      OverflowException: 4294967296
//      2147483647.999 --> 2147483647
//      OverflowException: 2147483648
//      -0.999 --> 0
//      -1 --> -1
//      -2147483648.999 --> -2147483648
//      OverflowException: -2147483649
// </Snippet1>
