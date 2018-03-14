// <Snippet1>
using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      Complex[] values = { new Complex(1.53, 9.26), 
                           new Complex(2.53, -8.12),
                           new Complex(-2.81, 5.32),
                           new Complex(-1.09, -3.43),
                           new Complex(Double.MinValue/2, Double.MinValue/2) };
      foreach (Complex value in values)
         Console.WriteLine("Exp(Log({0}) = {1}", value, 
                           Complex.Exp(Complex.Log(value)));
   }
}
// The example displays the following output:
//       Exp(Log((1.53, 9.26)) = (1.53, 9.26)
//       Exp(Log((2.53, -8.12)) = (2.53, -8.12)
//       Exp(Log((-2.81, 5.32)) = (-2.81, 5.32)
//       Exp(Log((-1.09, -3.43)) = (-1.09, -3.43)
//       Exp(Log((-8.98846567431158E+307, -8.98846567431158E+307)) = (-8.98846567431161E+307, -8.98846567431161E+307)
// </Snippet1>