// <Snippet1>
using System;

class Example
{
   public static void Main( )
   {
      decimal[] values = { 123m, new Decimal(123000, 0, 0, false, 3),
                           123.999m, 65535.999m, 65536m,             
                           32767.999m, 32768m, -0.999m,              
                           -1m,  -32768.999m, -32769m };

      foreach (var value in values) {
         try {
            short number = Decimal.ToInt16(value);
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
//     123 --> 123
//     123.000 --> 123
//     123.999 --> 123
//     OverflowException: 65535.999
//     OverflowException: 65536
//     32767.999 --> 32767
//     OverflowException: 32768
//     -0.999 --> 0
//     -1 --> -1
//     -32768.999 --> -32768
//     OverflowException: -32769
// </Snippet1>

