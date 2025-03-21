// <Snippet10>
using System;

public class Example1
{
    public static void Main()
    {
        float value1 = 10.201438f;
        value1 = (float)Math.Sqrt((float)Math.Pow(value1, 2));
        float value2 = (float)Math.Pow((float)value1 * 3.51f, 2);
        value2 = ((float)Math.Sqrt(value2)) / 3.51f;
        Console.WriteLine($"{value1} = {value2}: {value1.Equals(value2)}");
        Console.WriteLine();
        Console.WriteLine($"{value1:G9} = {value2:G9}");
    }
}
// The example displays the following output:
//       10.20144 = 10.20144: False
//       
//       10.201438 = 10.2014389
// </Snippet10>
