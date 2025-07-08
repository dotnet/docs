// <Snippet12>
using System;

public class Example3
{
    public static void Main()
    {
        double one1 = .1 * 10;
        double one2 = 0;
        for (int ctr = 1; ctr <= 10; ctr++)
            one2 += .1;

        Console.WriteLine($"{one1:R} = {one2:R}: {one1.Equals(one2)}");
        Console.WriteLine($"{one1:R} is approximately equal to {one2:R}: {IsApproximatelyEqual(one1, one2, .000000001)}");
    }

    static bool IsApproximatelyEqual(double value1, double value2, double epsilon)
    {
        // If they are equal anyway, just return True.
        if (value1.Equals(value2))
            return true;

        // Handle NaN, Infinity.
        if (Double.IsInfinity(value1) | Double.IsNaN(value1))
            return value1.Equals(value2);
        else if (Double.IsInfinity(value2) | Double.IsNaN(value2))
            return value1.Equals(value2);

        // Handle zero to avoid division by zero
        double divisor = Math.Max(value1, value2);
        if (divisor.Equals(0))
            divisor = Math.Min(value1, value2);

        return Math.Abs((value1 - value2) / divisor) <= epsilon;
    }
}
// The example displays the following output:
//       1 = 0.99999999999999989: False
//       1 is approximately equal to 0.99999999999999989: True
// </Snippet12>
