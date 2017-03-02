// <Snippet4>
using System;

public class Example
{
   public static void Main()
   {
      double number1 = 12.63; 
      if (Math.Ceiling(number1) is double)
         Console.WriteLine("The expression returns a double.");
      else if (Math.Ceiling(number1) is decimal)    
         Console.WriteLine("The expression returns a decimal.");

      decimal number2 = 12.63m; 
      if (Math.Ceiling(number2) is double)
         Console.WriteLine("The expression returns a double.");
      else if (Math.Ceiling(number2) is decimal)    
         Console.WriteLine("The expression returns a decimal.");

   }
}
// The example displays the following output:
//     The expression returns a double.
//     The expression returns a decimal.
// </Snippet4>
