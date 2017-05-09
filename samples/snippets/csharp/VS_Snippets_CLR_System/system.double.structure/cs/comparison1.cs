// <Snippet9>
using System;

public class Example
{
   public static void Main()
   {
      double value1 = .333333333333333;
      double value2 = 1.0/3;
      Console.WriteLine("{0:R} = {1:R}: {2}", value1, value2, value1.Equals(value2));
   }
}
// The example displays the following output:
//        0.333333333333333 = 0.33333333333333331: False
// </Snippet9>
