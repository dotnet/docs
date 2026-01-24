using System;

public class Example8
{
    public static void Main()
    {
        // <Snippet5>
        Double value1 = 1 / 3.0;
        Single sValue2 = 1 / 3.0f;
        Double value2 = (Double)sValue2;
        Console.WriteLine($"{value1:R} = {value2:R}: {value1.Equals(value2)}");

        // The example displays the following output on .NET:
        //        0.3333333333333333 = 0.3333333432674408: False
        // </Snippet5>
    }
}
