// <Snippet2>
using System;

public class Example7
{
    public static void Main()
    {
        float value1 = 3.065e35f;
        float value2 = 6.9375e32f;
        float result = value1 * value2;
        Console.WriteLine($"PositiveInfinity: {Single.IsPositiveInfinity(result)}");
        Console.WriteLine($"NegativeInfinity: {Single.IsNegativeInfinity(result)}\n");

        value1 = -value1;
        result = value1 * value2;
        Console.WriteLine($"PositiveInfinity: {Single.IsPositiveInfinity(result)}");
        Console.WriteLine($"NegativeInfinity: {Single.IsNegativeInfinity(result)}");
    }
}

// The example displays the following output:
//       PositiveInfinity: True
//       NegativeInfinity: False
//       
//       PositiveInfinity: False
//       NegativeInfinity: True
// </Snippet2>
