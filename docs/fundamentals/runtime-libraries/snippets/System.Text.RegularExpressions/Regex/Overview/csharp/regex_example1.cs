// <Snippet1>
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class Example
{
    public static void Main()
    {
        // Get the en-US NumberFormatInfo object to build the regular 
        // expression pattern dynamically.
        NumberFormatInfo nfi = CultureInfo.GetCultureInfo("en-US").NumberFormat;

        // Define the regular expression pattern.
        string pattern;
        pattern = @"^\s*[";
        // Get the positive and negative sign symbols.
        pattern += Regex.Escape(nfi.PositiveSign + nfi.NegativeSign) + @"]?\s?";
        // Get the currency symbol.
        pattern += Regex.Escape(nfi.CurrencySymbol) + @"?\s?";
        // Add integral digits to the pattern.
        pattern += @"(\d*";
        // Add the decimal separator.
        pattern += Regex.Escape(nfi.CurrencyDecimalSeparator) + "?";
        // Add the fractional digits.
        pattern += @"(\d{";
        // Determine the number of fractional digits in currency values.
        pattern += nfi.CurrencyDecimalDigits.ToString() + "})?){1}$";

        Console.WriteLine($"Pattern is {pattern}\n");

        Regex rgx = new Regex(pattern);

        // Define some test strings.
        string[] tests = { "-42", "19.99", "0.001", "100 USD",
                         ".34", "0.34", "1,052.21", "$10.62",
                         "+1.43", "-$0.23" };

        // Check each test string against the regular expression.
        foreach (string test in tests)
        {
            if (rgx.IsMatch(test))
                Console.WriteLine($"{test} is a currency value.");
            else
                Console.WriteLine($"{test} is not a currency value.");
        }
    }
}
// The example displays the following output:
//       Pattern is ^\s*[\+-]?\s?\$?\s?(\d*\.?(\d{2})?){1}$
//
//       -42 is a currency value.
//       19.99 is a currency value.
//       0.001 is not a currency value.
//       100 USD is not a currency value.
//       .34 is a currency value.
//       0.34 is a currency value.
//       1,052.21 is not a currency value.
//       $10.62 is a currency value.
//       +1.43 is a currency value.
//       -$0.23 is a currency value.
// </Snippet1>
