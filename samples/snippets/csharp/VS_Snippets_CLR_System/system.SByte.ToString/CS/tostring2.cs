
// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      sbyte value = -123;
      // Display value using default ToString method.
      Console.WriteLine(value.ToString());            // Displays -123
      // Display value using some standard format specifiers.
      Console.WriteLine(value.ToString("G"));         // Displays -123
      Console.WriteLine(value.ToString("C"));         // Displays ($-123.00)
      Console.WriteLine(value.ToString("D"));         // Displays -123
      Console.WriteLine(value.ToString("F"));         // Displays -123.00
      Console.WriteLine(value.ToString("N"));         // Displays -123.00
      Console.WriteLine(value.ToString("X"));         // Displays 85
   }
}
// </Snippet2>
