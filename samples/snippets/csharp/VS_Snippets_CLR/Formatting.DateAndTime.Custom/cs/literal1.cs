using System;

public class Example2
{
    public static void Main()
    {
        // <Snippet16>
        DateTime dat1 = new(2009, 6, 15, 13, 45, 0);

        Console.WriteLine($"'{dat1:%h}'");
        Console.WriteLine($"'{dat1: h}'");

        // The example displays the following output:
        //       '1'
        //       ' 1'
        // </Snippet16>
    }
}
