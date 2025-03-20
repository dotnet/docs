// <Snippet12>
using System;

public class Example3
{
    public static void Main()
    {
        float one1 = .1f * 10;
        float one2 = 0f;
        for (int ctr = 1; ctr <= 10; ctr++)
            one2 += .1f;

        Console.WriteLine($"{one1:R} = {one2:R}: {one1.Equals(one2)}");
        Console.WriteLine($"{one1:R} is approximately equal to {one2:R}: {IsApproximatelyEqual(one1, one2, .000001f)}");
    }

    static bool IsApproximatelyEqual(float value1, float value2, float epsilon)
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

        return Math.Abs(value1 - value2) / divisor <= epsilon;
    }
}
// The example displays the following output:
//       1 = 1.00000012: False
//       1 is approximately equal to 1.00000012: True
// </Snippet12>
