// <Snippet3>
using System;

public class Example12
{
    public static void Main()
    {
        Single value = .2f;
        Single result1 = value * 10f;
        Single result2 = 0f;
        for (int ctr = 1; ctr <= 10; ctr++)
            result2 += value;

        Console.WriteLine($".2 * 10:           {result1:R}");
        Console.WriteLine($".2 Added 10 times: {result2:R}");
    }
}
// The example displays the following output:
//       .2 * 10:           2
//       .2 Added 10 times: 2.00000024
// </Snippet3>
