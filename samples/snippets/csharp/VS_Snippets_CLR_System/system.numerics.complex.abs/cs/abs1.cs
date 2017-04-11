// <Snippet1>
using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      Complex complex1 = new Complex(2.0, 3.0);
      Console.WriteLine("|{0}| = {1:N2}", complex1, Complex.Abs(complex1));
      Console.WriteLine("Equal to Magnitude: {0}", 
                        Complex.Abs(complex1).Equals(complex1.Magnitude)); 
   }
}
// The example displays the following output:
//       |(2, 3)| = 3.60555127546399
//       Equal to Magnitude: True
// </Snippet1>