// <Snippet4>
using System;
using System.Globalization;

public class ParseEx1
{
    public static void Main()
    {
        String[] values = { "1,034,562.91", "9 532 978,07" };
        String[] cultureNames = { "en-US", "fr-FR", "" };

        foreach (var value in values)
        {
            foreach (var cultureName in cultureNames)
            {
                CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
                String name = culture.Name == "" ? "Invariant" : culture.Name;
                try
                {
                    Decimal amount = Decimal.Parse(value, culture);
                    Console.WriteLine($"'{value}' --> {amount} ({name})");
                }
                catch (FormatException)
                {
                    Console.WriteLine($"'{value}': FormatException ({name})");
                }
            }
            Console.WriteLine();
        }
    }
}
// The example displays the following output:
//       '1,034,562.91' --> 1034562.91 (en-US)
//       '1,034,562.91': FormatException (fr-FR)
//       '1,034,562.91' --> 1034562.91 (Invariant)
//
//       '9 532 978,07': FormatException (en-US)
//       '9 532 978,07' --> 9532978.07 (fr-FR)
//       '9 532 978,07': FormatException (Invariant)
// </Snippet4>
