
// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      ushort value = 16324;
      // Display value using default ToString method.
      Console.WriteLine(value.ToString());      
      Console.WriteLine();
      
      // Define an array of format specifiers.
      string[] formats = { "G", "C", "D", "F", "N", "X" };
      // Display value using the standard format specifiers.
      foreach (string format in formats)
         Console.WriteLine("{0} format specifier: {1,12}", 
                           format, value.ToString(format));         
   }
}
// The example displays the following output:
//       16324
//
//       G format specifier:        16324
//       C format specifier:   $16,324.00
//       D format specifier:        16324
//       F format specifier:     16324.00
//       N format specifier:    16,324.00
//       X format specifier:         3FC4
// </Snippet1>
