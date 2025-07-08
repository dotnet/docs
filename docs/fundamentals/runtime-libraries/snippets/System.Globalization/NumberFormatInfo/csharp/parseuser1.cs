// <Snippet5>
using System;
using System.Globalization;

public class ParseUserEx
{
    public static void Main()
    {
        CultureInfo stdCulture = CultureInfo.GetCultureInfo("en-US");
        CultureInfo custCulture = CultureInfo.CreateSpecificCulture("en-US");

        String value = "310,16";
        try
        {
            Console.WriteLine($"{stdCulture.Name} culture reflects user overrides: {stdCulture.UseUserOverride}");
            Decimal amount = Decimal.Parse(value, stdCulture);
            Console.WriteLine($"'{value}' --> {amount.ToString(CultureInfo.InvariantCulture)}");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{value}'");
        }
        Console.WriteLine();

        try
        {
            Console.WriteLine($"{custCulture.Name} culture reflects user overrides: {custCulture.UseUserOverride}");
            Decimal amount = Decimal.Parse(value, custCulture);
            Console.WriteLine($"'{value}' --> {amount.ToString(CultureInfo.InvariantCulture)}");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{value}'");
        }
    }
}
// The example displays the following output:
//       en-US culture reflects user overrides: False
//       '310,16' --> 31016
//
//       en-US culture reflects user overrides: True
//       '310,16' --> 310.16
// </Snippet5>
