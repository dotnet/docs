// <Snippet4>
using System;

public class Example14
{
    public static void Main()
    {
        Double value = 123456789012.34567;
        Double additional = Double.Epsilon * 1e15;
        Console.WriteLine($"{value} + {additional} = {value + additional}");
    }
}
// The example displays the following output:
//    123456789012.346 + 4.94065645841247E-309 = 123456789012.346
// </Snippet4>
