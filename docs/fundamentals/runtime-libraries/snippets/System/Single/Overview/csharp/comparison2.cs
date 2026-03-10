using System;

public class Example1
{
    public static void Main()
    {
        // <Snippet10>
        float value1 = 10.201438f;
        value1 = (float)Math.Sqrt((float)Math.Pow(value1, 2));
        float value2 = (float)Math.Pow((float)value1 * 3.51f, 2);
        value2 = ((float)Math.Sqrt(value2)) / 3.51f;
        Console.WriteLine($"{value1} = {value2}: {value1.Equals(value2)}");

        // The example displays the following output on .NET:
        //       10.201438 = 10.201439: False
        // The example displays the following output on .NET Framework:
        //       10.20144 = 10.20144: False
        // </Snippet10>
    }
}
