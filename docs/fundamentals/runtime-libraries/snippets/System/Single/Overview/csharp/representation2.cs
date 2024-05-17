// <Snippet4>
using System;

public class Example13
{
    public static void Main()
    {
        Single value = 123.456f;
        Single additional = Single.Epsilon * 1e15f;
        Console.WriteLine($"{value} + {additional} = {value + additional}");
    }
}
// The example displays the following output:
//    123.456 + 1.401298E-30 = 123.456
// </Snippet4>
