// <Snippet6>
using System;

public class Example
{
    public static void Main()
    {
      sbyte[] values = { SByte.MaxValue, 98, 0, -32, SByte.MinValue };
      foreach (sbyte value in values)
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
//       Abs(127) = 127
//       Abs(98) = 98
//       Abs(0) = 0
//       Abs(-32) = 32
//       Unable to calculate the absolute value of -128.
// </Snippet6>   
