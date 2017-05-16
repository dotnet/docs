// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        // Create parallel arrays of Decimals to use as the dividend and divisor.
        Decimal[] dividends = { 79m, 1000m, -1000m, 123m, 1234567800000m,
                                1234.0123m };
        Decimal[] divisors = { 11m, 7m, 7m, .00123m, 0.12345678m, 1234.5678m };
        
        for (int ctr = 0; ctr < dividends.Length; ctr++) 
        {
           Decimal dividend = dividends[ctr];
           Decimal divisor = divisors[ctr];
           Console.WriteLine("{0:N3} / {1:N3} = {2:N3} Remainder {3:N3}", dividend,
                             divisor, Decimal.Divide(dividend, divisor),
                             Decimal.Remainder(dividend, divisor)); 
        }
    }
} 
// The example displays the following output:
//       79.000 / 11.000 = 7.182 Remainder 2.000
//       1,000.000 / 7.000 = 142.857 Remainder 6.000
//       -1,000.000 / 7.000 = -142.857 Remainder -6.000
//       123.000 / 0.001 = 100,000.000 Remainder 0.000
//       1,234,567,800,000.000 / 0.123 = 10,000,000,000,000.000 Remainder 0.000
//       1,234.012 / 1,234.568 = 1.000 Remainder 1,234.012
// </Snippet1>
