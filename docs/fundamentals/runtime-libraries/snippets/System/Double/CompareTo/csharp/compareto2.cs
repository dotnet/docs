// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        double value1 = 6.185;
        double value2 = value1 * .1 / .1;
        Console.WriteLine($"Comparing {value1} and {value2}: {value1.CompareTo(value2)}{Environment.NewLine}");
        Console.WriteLine($"Comparing {value1:R} and {value2:R}: {value1.CompareTo(value2)}");
    }
}
// The example displays the following output:
//       Comparing 6.185 and 6.185: -1
//
//       Comparing 6.185 and 6.1850000000000005: -1
// </Snippet1>
