using System;

public class Example10
{
    public static void Main()
    {
        // <Snippet29>
        int value = 1326;
        string result = String.Format("{0,10:D6} {0,10:X8}", value);
        Console.WriteLine(result);
        // The example displays the following output:
        //     001326   0000052E
        // </Snippet29>
    }
}
