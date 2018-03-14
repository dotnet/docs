// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      // Define several positive and negative dividends.
      long[] dividends = { Int64.MaxValue, 13952, 0, -14032,
                           Int64.MinValue };
      // Define one positive and one negative divisor.
      long[] divisors = { 2000, -2000 };
      
      foreach (long divisor in divisors)
      {
         foreach (long dividend in dividends)
         {
            long remainder; 
            long quotient = Math.DivRem(dividend, divisor, out remainder);
            Console.WriteLine(@"{0:N0} \ {1:N0} = {2:N0}, remainder {3:N0}", 
                              dividend, divisor, quotient, remainder);
         }
      }                                
   }
}
// The example displays the following output:
//    9,223,372,036,854,775,807 \ 2,000 = 4,611,686,018,427,387, remainder 1,807
//    13,952 \ 2,000 = 6, remainder 1,952
//    0 \ 2,000 = 0, remainder 0
//    -14,032 \ 2,000 = -7, remainder -32
//    -9,223,372,036,854,775,808 \ 2,000 = -4,611,686,018,427,387, remainder -1,808
//    9,223,372,036,854,775,807 \ -2,000 = -4,611,686,018,427,387, remainder 1,807
//    13,952 \ -2,000 = -6, remainder 1,952
//    0 \ -2,000 = 0, remainder 0
//    -14,032 \ -2,000 = 7, remainder -32
//    -9,223,372,036,854,775,808 \ -2,000 = 4,611,686,018,427,387, remainder -1,808
// </Snippet2>
