// <Snippet1>
using System;

public class TipCalculator {
    private const double tipRate = 0.18;
    public static int Main(string[] args) {
        double billTotal;
        if (args.Length == 0) {
            Console.WriteLine("usage: TIPCALC total");
            return 1;
        }
        else {
            if (! Double.TryParse(args[0], out billTotal)) {
                Console.WriteLine("usage: TIPCALC total");
                return 1;
            }
            double tip = billTotal * tipRate;
            Console.WriteLine();
            Console.WriteLine("Bill total:\t{0,8:c}", billTotal);
            Console.WriteLine("Tip total/rate:\t{0,8:c} ({1:p1})", tip, tipRate);
            Console.WriteLine(("").PadRight(24, '-'));
            Console.WriteLine("Grand total:\t{0,8:c}", billTotal + tip);
            return 0;
        }
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