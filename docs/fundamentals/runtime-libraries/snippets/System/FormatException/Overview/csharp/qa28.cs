using System;

public class Example9
{
    public static void Main()
    {
        // <Snippet28>
        int value = 16342;
        string result = String.Format("{0,18:00000000} {0,18:00000000.000} {0,18:000,0000,000.0}",
                                      value);
        Console.WriteLine(result);
        // The example displays the following output:
        //           00016342       00016342.000    0,000,016,342.0
        // </Snippet28>
    }
}
