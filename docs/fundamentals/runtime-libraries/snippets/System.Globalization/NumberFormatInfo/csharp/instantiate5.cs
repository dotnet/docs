// <Snippet5>
using System;
using System.Globalization;

public class InstantiateEx5
{
    public static void Main()
    {
        CultureInfo culture;
        NumberFormatInfo nfi;

        nfi = CultureInfo.GetCultureInfo("id-ID").NumberFormat;
        Console.WriteLine($"Read-only: {nfi.IsReadOnly}");

        culture = new CultureInfo("id-ID");
        nfi = NumberFormatInfo.GetInstance(culture);
        Console.WriteLine($"Read-only: {nfi.IsReadOnly}");

        culture = CultureInfo.CreateSpecificCulture("id-ID");
        nfi = culture.NumberFormat;
        Console.WriteLine($"Read-only: {nfi.IsReadOnly}");

        culture = new CultureInfo("id-ID");
        nfi = culture.NumberFormat;
        Console.WriteLine($"Read-only: {nfi.IsReadOnly}");
    }
}
// The example displays the following output:
//       Read-only: True
//       Read-only: False
//       Read-only: False
//       Read-only: False
// </Snippet5>
