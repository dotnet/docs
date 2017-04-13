// <Snippet1>
using System;

class Example
{
   public static void Main( )
   {
      decimal[] values = { 123m, new Decimal(78000, 0, 0, false, 3),
                           78.999m, 255.999m, 256m,             
                           127.999m, 128m, -0.999m,              
                           -1m,  -128.999m, -129m };

      foreach (var value in values) {
         try {
            sbyte number = Decimal.ToSByte(value);
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
//     78 --> 78
//     78.000 --> 78
//     78.999 --> 78
//     OverflowException: 255.999
//     OverflowException: 256
//     127.999 --> 127
//     OverflowException: 128
//     -0.999 --> 0
//     -1 --> -1
//     -128.999 --> -128
//     OverflowException: -129
// </Snippet1>

