// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
       double value1 = 6.185;
       object value2 = value1 * .1 / .1;
       Console.WriteLine("Comparing {0} and {1}: {2}\n",
                         value1, value2, value1.CompareTo(value2));
       Console.WriteLine("Comparing {0:R} and {1:R}: {2}",
                         value1, value2, value1.CompareTo(value2));
   }
}
// The example displays the following output:
//       Comparing 6.185 and 6.185: -1
//       
//       Comparing 6.185 and 6.1850000000000005: -1
// </Snippet2>