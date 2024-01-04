﻿// <Snippet11>
using System;

public class Example
{
   public static void Main()
   {
      float value1 = .3333333f;
      float value2 = 1.0f/3;
      int precision = 7;
      value1 = (float) Math.Round(value1, precision);
      value2 = (float) Math.Round(value2, precision);
      Console.WriteLine("{0:R} = {1:R}: {2}", value1, value2, value1.Equals(value2));
   }
}
// The example displays the following output:
//        0.3333333 = 0.3333333: True
// </Snippet11>
