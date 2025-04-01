using System;
using System.Numerics;

public class PrecisionEx
{
    public static void Main()
    {
        // <Snippet5>
        Complex value = new Complex(Double.MinValue / 2, Double.MinValue / 2);
        Complex value2 = Complex.Exp(Complex.Log(value));
        Console.WriteLine($"{value} \n{value2} \nEqual: {value == value2}");
        // The example displays the following output:
        //    (-8.98846567431158E+307, -8.98846567431158E+307)
        //    (-8.98846567431161E+307, -8.98846567431161E+307)
        //    Equal: False
        // </Snippet5>

        Console.WriteLine();
        ShowPlatform();
    }

    private static void ShowPlatform()
    {
        // <Snippet6>
        Complex minusOne = new Complex(-1, 0);
        Console.WriteLine(Complex.Sqrt(minusOne));
        // The example displays the following output:
        //    (6.12303176911189E-17, 1) on 32-bit systems.
        //    (6.12323399573677E-17,1) on IA64 systems.
        // </Snippet6>
    }
}

// Complex minusOne = new Complex(-1,0);
// Complex.Sqrt(minusOne) returns Complex(6.12303176911189E-17, 1) where as it returns Complex on IA64.
