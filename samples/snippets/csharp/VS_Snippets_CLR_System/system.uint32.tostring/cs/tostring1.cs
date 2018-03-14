
// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      uint value = 1632490;
      // Display value using default ToString method.
      Console.WriteLine(value.ToString());      
      Console.WriteLine();
      
      // Define an array of format specifiers.
      string[] formats = { "G", "C", "D", "F", "N", "X" };
      // Display value using the standard format specifiers.
      foreach (string format in formats)
         Console.WriteLine("{0} format specifier: {1,16}", 
                           format, value.ToString(format));         
   }
}
// The example displays the following output:
//       1632490
//       
//       G format specifier:          1632490
//       C format specifier:    $1,632,490.00
//       D format specifier:          1632490
//       F format specifier:       1632490.00
//       N format specifier:     1,632,490.00
//       X format specifier:           18E8EA
// </Snippet1>
