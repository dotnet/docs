// <Snippet6>
using System;

public class Example9
{
    public static void Main()
    {
        Single[] values = { 10.01f, 2.88f, 2.88f, 2.88f, 9.0f };
        Single result = 27.65f;
        Single total = 0f;
        foreach (var value in values)
            total += value;

        if (total.Equals(result))
            Console.WriteLine("The sum of the values equals the total.");
        else
            Console.WriteLine($"The sum of the values ({total}) does not equal the total ({result}).");
    }
}

// The example displays the following output on .NET:
//      The sum of the values (27.650002) does not equal the total (27.65).
// The example displays the following output on .NET Framework:
//      The sum of the values (27.65) does not equal the total (27.65).
// </Snippet6>
