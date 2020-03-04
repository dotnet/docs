// <Snippet1>
using System;

public class TipCalculator
{
    private const double tipRate = 0.18;
    public static void Main(string[] args)
    {
        double billTotal;
        if (args.Length == 0 || ! Double.TryParse(args[0], out billTotal))
        {
            Console.WriteLine("usage: TIPCALC total");
            return;
        }
        double tip = billTotal * tipRate;
        Console.WriteLine();
        Console.WriteLine($"Bill total:\t{billTotal,8:c}");
        Console.WriteLine($"Tip total/rate:\t{tip,8:c} ({tipRate:p1})");
        Console.WriteLine(("").PadRight(24, '-'));
        Console.WriteLine($"Grand total:\t{billTotal + tip,8:c}");
    }
}

/*
>tipcalc 52.23

Bill total:       $52.23
Tip total/rate:    $9.40 (18.0 %)
------------------------
Grand total:      $61.63
*/
// </Snippet1>
