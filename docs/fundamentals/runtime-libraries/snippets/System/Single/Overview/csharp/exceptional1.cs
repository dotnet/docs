// <Snippet1>
using System;

public class Example6
{
    public static void Main()
    {
        float value1 = 1.163287e-36f;
        float value2 = 9.164234e-25f;
        float result = value1 * value2;
        Console.WriteLine($"{value1} * {value2} = {result}");
        Console.WriteLine("{0} = 0: {1}", result, result.Equals(0.0f));
    }
}
// The example displays the following output:
//       1.163287E-36 * 9.164234E-25 = 0
//       0 = 0: True
// </Snippet1>
