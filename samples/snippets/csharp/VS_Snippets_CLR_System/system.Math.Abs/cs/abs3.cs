// <Snippet3>
using System;

public class Example
{
   public static void Main()
   {
      short[] values = { Int16.MaxValue, 10328, 0, -1476, Int16.MinValue };
      foreach (short value in values)
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
//       Abs(32767) = 32767
//       Abs(10328) = 10328
//       Abs(0) = 0
//       Abs(-1476) = 1476
//       Unable to calculate the absolute value of -32768.
// </Snippet3>
