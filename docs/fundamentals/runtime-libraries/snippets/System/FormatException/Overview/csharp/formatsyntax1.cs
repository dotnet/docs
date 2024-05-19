using System;

public class Example4
{
    public static void Main()
    {
        // <Snippet12>
        var value = String.Format("{0,-10:C}", 126347.89m);
        Console.WriteLine(value);
        // </Snippet12>
    }
}
