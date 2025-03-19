// <Snippet1>
using System;

public class Example6
{
    public static void Main()
    {
        Double value1 = 1.1632875981534209e-225;
        Double value2 = 9.1642346778e-175;
        Double result = value1 * value2;
        Console.WriteLine($"{value1} * {value2} = {result}");
        Console.WriteLine("{0} = 0: {1}", result, result.Equals(0.0));
    }
}
// The example displays the following output:
//       1.16328759815342E-225 * 9.1642346778E-175 = 0
//       0 = 0: True
// </Snippet1>
