// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
       float value1 = 16.5457f;
       float operand = 3.8899982f;
       object value2 = value1 * operand / operand;
       Console.WriteLine($"Comparing {value1} and {value2}: {value1.CompareTo(value2)}\n");
       Console.WriteLine($"Comparing {value1:R} and {value2:R}: {value1.CompareTo(value2)}");
   }
}
// The example displays the following output:
//       Comparing 16.5457 and 16.5457: -1
//       
//       Comparing 16.5457 and 16.545702: -1
// </Snippet2>
