// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      // Define several positive and negative dividends.
      int[] dividends = { Int32.MaxValue, 13952, 0, -14032,
                                     Int32.MinValue };
      // Define one positive and one negative divisor.
      int[] divisors = { 2000, -2000 };
      
      foreach (int divisor in divisors)
      {
         foreach (int dividend in dividends)
         {
            int remainder; 
            int quotient = Math.DivRem(dividend, divisor, out remainder);
            Console.WriteLine(@"{0:N0} \ {1:N0} = {2:N0}, remainder {3:N0}", 
                              dividend, divisor, quotient, remainder);
         }
      }                                
   }
}
// The example displays the following output:
//       2,147,483,647 \ 2,000 = 1,073,741, remainder 1,647
//       13,952 \ 2,000 = 6, remainder 1,952
//       0 \ 2,000 = 0, remainder 0
//       -14,032 \ 2,000 = -7, remainder -32
//       -2,147,483,648 \ 2,000 = -1,073,741, remainder -1,648
//       2,147,483,647 \ -2,000 = -1,073,741, remainder 1,647
//       13,952 \ -2,000 = -6, remainder 1,952
//       0 \ -2,000 = 0, remainder 0
//       -14,032 \ -2,000 = 7, remainder -32
//       -2,147,483,648 \ -2,000 = 1,073,741, remainder -1,648
// </Snippet1>
