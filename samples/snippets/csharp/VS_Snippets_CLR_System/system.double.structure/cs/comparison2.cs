// <Snippet10>
using System;

public class Example
{
   public static void Main()
   {
      double value1 = 100.10142;
      value1 = Math.Sqrt(Math.Pow(value1, 2));
      double value2 = Math.Pow(value1 * 3.51, 2);
      value2 = Math.Sqrt(value2) / 3.51;
      Console.WriteLine("{0} = {1}: {2}\n", 
                        value1, value2, value1.Equals(value2)); 
      Console.WriteLine("{0:R} = {1:R}", value1, value2); 
   }
}
// The example displays the following output:
//    100.10142 = 100.10142: False
//    
//    100.10142 = 100.10141999999999
// </Snippet10>

