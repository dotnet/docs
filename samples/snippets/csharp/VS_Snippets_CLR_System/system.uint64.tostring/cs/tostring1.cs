// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      ulong value = 163249057;
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
//       163249057
//       
//       G format specifier:        163249057
//       C format specifier:  $163,249,057.00
//       D format specifier:        163249057
//       F format specifier:     163249057.00
//       N format specifier:   163,249,057.00
//       X format specifier:          9BAFBA1
// </Snippet1>
