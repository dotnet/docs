﻿// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
       float value1 = 16.5457f;
       float operand = 3.8899982f;
       object value2 = value1 * operand / operand;
       Console.WriteLine("Comparing {0} and {1}: {2}\n",
                         value1, value2, value1.CompareTo(value2));
       Console.WriteLine("Comparing {0:R} and {1:R}: {2}",
                         value1, value2, value1.CompareTo(value2));
   }
}
// The example displays the following output:
//       Comparing 16.5457 and 16.5457: -1
//       
//       Comparing 16.5457 and 16.545702: -1
// </Snippet2>
