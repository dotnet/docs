// <Snippet3>
using System;
using System.Numerics;

public class NaNEx
{
    public static void Run()
    {
        Complex c1 = new Complex(Double.MaxValue / 2, Double.MaxValue / 2);

        Complex c2 = c1 / Complex.Zero;
        Console.WriteLine(c2.ToString());
        c2 = c2 * new Complex(1.5, 1.5);
        Console.WriteLine(c2.ToString());
        Console.WriteLine();

        Complex c3 = c1 * new Complex(2.5, 3.5);
        Console.WriteLine(c3.ToString());
        c3 = c3 + new Complex(Double.MinValue / 2, Double.MaxValue / 2);
        Console.WriteLine(c3);
    }
}
// The example displays the following output:
//       (NaN, NaN)
//       (NaN, NaN)
//       (NaN, Infinity)
//       (NaN, Infinity)
// </Snippet3>
