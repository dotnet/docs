using System;

public class Example2
{
    public static void Main()
    {
        // <Snippet16>
        DateTime dat1 = new DateTime(2009, 6, 15, 13, 45, 0);

        Console.WriteLine($"'{0:%h}'");
        Console.WriteLine($"'{0: h}'");
        Console.WriteLine($"'{0:h }'");
        // The example displays the following output:
        //       '1'
        //       ' 1'
        //       '1 '
        // </Snippet16>
    }
}
