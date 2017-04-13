// <Snippet1>
using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      Complex number1 = new Complex(8.3, 17.5);
      Complex[] numbers = { new Complex(1.4, 6.3), 
                            new Complex(-2.7, 1.8), 
                            new Complex(3.1, -2.1) };
      foreach (Complex number2 in numbers)
         Console.WriteLine("{0} x {1} = {2}", number1, number2, 
                           Complex.Multiply(number1, number2));
   }
}
// The example displays the following output:
//       (8.3, 17.5) x (1.4, 6.3) = (-98.63, 76.79)
//       (8.3, 17.5) x (-2.7, 1.8) = (-53.91, -32.31)
//       (8.3, 17.5) x (3.1, -2.1) = (62.48, 36.82)
// </Snippet1>