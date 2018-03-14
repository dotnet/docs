// <Snippet11>
using System;

public class Example
{
   public static void Main()
   {
      double value1 = .333333333333333;
      double value2 = 1.0/3;
      int precision = 7;
      value1 = Math.Round(value1, precision);
      value2 = Math.Round(value2, precision);
      Console.WriteLine("{0:R} = {1:R}: {2}", value1, value2, value1.Equals(value2));
   }
}
// The example displays the following output:
//        0.3333333 = 0.3333333: True
// </Snippet11>
