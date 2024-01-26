using System;

public class Example11
{
    public static void Main()
    {
        WillThrow();
        Console.WriteLine();
        WontThrow();
        Console.WriteLine();
        Recommended();
    }

    public static void WillThrow()
    {
        String result;
        int nOpen = 1;
        int nClose = 2;
        try
        {
            // <Snippet23>
            result = String.Format("The text has {0} '{' characters and {1} '}' characters.",
                                   nOpen, nClose);
            // </Snippet23>
            Console.WriteLine(result);
        }
        catch (FormatException)
        {
            Console.WriteLine("FormatException");
        }
    }

    public static void WontThrow()
    {
        // <Snippet24>
        string result;
        int nOpen = 1;
        int nClose = 2;
        result = String.Format("The text has {0} '{{' characters and {1} '}}' characters.",
                               nOpen, nClose);
        Console.WriteLine(result);
        // </Snippet24>
    }

    public static void Recommended()
    {
        // <Snippet25>
        string result;
        int nOpen = 1;
        int nClose = 2;
        result = String.Format("The text has {0} '{1}' characters and {2} '{3}' characters.",
                               nOpen, "{", nClose, "}");
        Console.WriteLine(result);
        // </Snippet25>
    }
}
