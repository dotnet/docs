using System;

public class Example15
{
    public static void Main()
    {
        // <Snippet35>
        Decimal pricePerOunce = 17.36m;
        String s = String.Format("The current price is {0} per ounce.",
                                 pricePerOunce);
        Console.WriteLine(s);
        // Result: The current price is 17.36 per ounce.
        // </Snippet35>
        ShowFormatted();
    }

    private static void ShowFormatted()
    {
        // <Snippet36>
        Decimal pricePerOunce = 17.36m;
        String s = String.Format("The current price is {0:C2} per ounce.",
                                 pricePerOunce);
        Console.WriteLine(s);
        // Result if current culture is en-US:
        //      The current price is $17.36 per ounce.
        // </Snippet36>
    }
}
