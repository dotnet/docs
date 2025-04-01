using System;

public class Example1
{
    public static void Main()
    {
        // <Snippet2>
        object[] values = { "word", true, 120, 136.34, 'a' };
        foreach (var value in values)
            Console.WriteLine($"{value} - type {value.GetType().Name}");

        // The example displays the following output:
        //       word - type String
        //       True - type Boolean
        //       120 - type Int32
        //       136.34 - type Double
        //       a - type Char
        // </Snippet2>
    }
}
