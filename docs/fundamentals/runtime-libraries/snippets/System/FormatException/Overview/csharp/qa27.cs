using System;

public class Example8
{
    public static void Main()
    {
        // <Snippet27>
        decimal value = 16309.5436m;
        string result = String.Format("{0,12:#.00000} {0,12:0,000.00} {0,12:000.00#}",
                                      value);
        Console.WriteLine(result);
        // The example displays the following output:
        //        16309.54360    16,309.54    16309.544
        // </Snippet27>
    }
}
