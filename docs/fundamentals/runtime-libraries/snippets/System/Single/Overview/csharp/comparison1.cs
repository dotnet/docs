// <Snippet9>
using System;

public class Example
{
   public static void Main()
   {
      float value1 = .3333333f;
      float value2 = 1.0f/3;
      Console.WriteLine($"{value1:R} = {value2:R}: {value1.Equals(value2)}");
   }
}
// The example displays the following output:
//        0.3333333 = 0.333333343: False
// </Snippet9>
