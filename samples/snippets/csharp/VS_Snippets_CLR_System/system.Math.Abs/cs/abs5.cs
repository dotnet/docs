// <Snippet5>
using System;

public class Example
{
   public static void Main()
   {
      long[] values = { Int64.MaxValue, 109013, 0, -6871982, Int64.MinValue };
      foreach (long value in values)
      {
         try {
            Console.WriteLine("Abs({0}) = {1}", value, Math.Abs(value));
         }   
         catch (OverflowException) {
            Console.WriteLine("Unable to calculate the absolute value of {0}.", 
                              value);
         }
      }
   }
}
// The example displays the following output:
//       Abs(9223372036854775807) = 9223372036854775807
//       Abs(109013) = 109013
//       Abs(0) = 0
//       Abs(-6871982) = 6871982
//       Unable to calculate the absolute value of -9223372036854775808.
// </Snippet5>   
