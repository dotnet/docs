// <Snippet1>
using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        // Retrieve a writable NumberFormatInfo object.
        CultureInfo enUS = CultureInfo.CreateSpecificCulture("en-US");
        NumberFormatInfo nfi = enUS.NumberFormat;

        // Use the ISO currency symbol instead of the native currency symbol.
        nfi.CurrencySymbol = (new RegionInfo(enUS.Name)).ISOCurrencySymbol;
        // Change the positive currency pattern to <code><space><value>.
        nfi.CurrencyPositivePattern = 2;
        // Change the negative currency pattern to <code><space><sign><value>.
        nfi.CurrencyNegativePattern = 12;

        // Produce the result strings by calling ToString.
        Decimal[] values = { 1065.23m, 19.89m, -.03m, -175902.32m };
        foreach (var value in values)
            Console.WriteLine(value.ToString("C", enUS));

        Console.WriteLine();

        // Produce the result strings by calling a composite formatting method.
        foreach (var value in values)
            Console.WriteLine(String.Format(enUS, "{0:C}", value));
    }
}
// The example displays the following output:
//       USD 1,065.23
//       USD 19.89
//       USD -0.03
//       USD -175,902.32
//
//       USD 1,065.23
//       USD 19.89
//       USD -0.03
//       USD -175,902.32
// </Snippet1>
