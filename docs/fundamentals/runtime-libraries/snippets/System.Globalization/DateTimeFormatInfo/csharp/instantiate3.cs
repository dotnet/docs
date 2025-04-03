// <Snippet8>
using System;
using System.Globalization;

public class InstantiateEx3
{
    public static void Main()
    {
        CultureInfo culture;
        DateTimeFormatInfo dtfi;

        culture = CultureInfo.CurrentCulture;
        dtfi = culture.DateTimeFormat;
        Console.WriteLine($"Culture Name:      {culture.Name}");
        Console.WriteLine($"User Overrides:    {culture.UseUserOverride}");
        Console.WriteLine($"Long Time Pattern: {culture.DateTimeFormat.LongTimePattern}\n");

        culture = new CultureInfo(CultureInfo.CurrentCulture.Name, false);
        Console.WriteLine($"Culture Name:      {culture.Name}");
        Console.WriteLine($"User Overrides:    {culture.UseUserOverride}");
        Console.WriteLine($"Long Time Pattern: {culture.DateTimeFormat.LongTimePattern}\n");
    }
}
// The example displays the following output:
//       Culture Name:      en-US
//       User Overrides:    True
//       Long Time Pattern: HH:mm:ss
//
//       Culture Name:      en-US
//       User Overrides:    False
//       Long Time Pattern: h:mm:ss tt
// </Snippet8>
