// <Snippet3>
using System;
using System.Globalization;

public class InstantiateEx3
{
    public static void Main()
    {
        CultureInfo culture;
        NumberFormatInfo nfi;

        culture = CultureInfo.CurrentCulture;
        nfi = culture.NumberFormat;
        Console.WriteLine($"Culture Name:    {culture.Name}");
        Console.WriteLine($"User Overrides:  {culture.UseUserOverride}");
        Console.WriteLine($"Currency Symbol: {culture.NumberFormat.CurrencySymbol}\n");

        culture = new CultureInfo(CultureInfo.CurrentCulture.Name, false);
        Console.WriteLine($"Culture Name:    {culture.Name}");
        Console.WriteLine($"User Overrides:  {culture.UseUserOverride}");
        Console.WriteLine($"Currency Symbol: {culture.NumberFormat.CurrencySymbol}");
    }
}
// The example displays the following output:
//       Culture Name:    en-US
//       User Overrides:  True
//       Currency Symbol: USD
//
//       Culture Name:    en-US
//       User Overrides:  False
//       Currency Symbol: $
// </Snippet3>
