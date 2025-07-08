// <Snippet12>
using System;
using System.Globalization;

public class Example3
{
    public static void Main()
    {
        DateTime dateValue = new DateTime(2013, 08, 28);
        CultureInfo frFR = CultureInfo.CreateSpecificCulture("fr-FR");
        DateTimeFormatInfo dtfi = frFR.DateTimeFormat;

        Console.WriteLine($"Before modifying DateSeparator property: {dateValue.ToString("g", frFR)}");

        // Modify the date separator.
        dtfi.DateSeparator = "-";
        Console.WriteLine($"After modifying the DateSeparator property: {dateValue.ToString("g", frFR)}");
    }
}
// The example displays the following output:
//       Before modifying DateSeparator property: 28/08/2013 00:00
//       After modifying the DateSeparator property: 28-08-2013 00:00
// </Snippet12>
