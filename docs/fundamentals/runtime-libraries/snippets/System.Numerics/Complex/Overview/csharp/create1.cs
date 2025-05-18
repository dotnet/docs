// <Snippet2>
using System;
using System.Numerics;

public class CreateEx
{
    public static void Run()
    {
        // Create a complex number by calling its class constructor.
        Complex c1 = new Complex(12, 6);
        Console.WriteLine(c1);

        // Assign a Double to a complex number.
        Complex c2 = 3.14;
        Console.WriteLine(c2);

        // Cast a Decimal to a complex number.
        Complex c3 = (Complex)12.3m;
        Console.WriteLine(c3);

        // Assign the return value of a method to a Complex variable.
        Complex c4 = Complex.Pow(Complex.One, -1);
        Console.WriteLine(c4);

        // Assign the value returned by an operator to a Complex variable.
        Complex c5 = Complex.One + Complex.One;
        Console.WriteLine(c5);

        // Instantiate a complex number from its polar coordinates.
        Complex c6 = Complex.FromPolarCoordinates(10, .524);
        Console.WriteLine(c6);
    }
}
// The example displays the following output:
//       (12, 6)
//       (3.14, 0)
//       (12.3, 0)
//       (1, 0)
//       (2, 0)
//       (8.65824721882145, 5.00347430269914)
// </Snippet2>
