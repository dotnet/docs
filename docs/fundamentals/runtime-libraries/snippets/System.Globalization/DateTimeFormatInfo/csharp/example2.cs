// <Snippet13>
using System;
using System.Globalization;

public class Example2
{
    public static void Main()
    {
        DateTime value = new DateTime(2013, 7, 9);
        CultureInfo enUS = CultureInfo.CreateSpecificCulture("en-US");
        DateTimeFormatInfo dtfi = enUS.DateTimeFormat;
        String[] formats = { "D", "F", "f" };

        // Display date before modifying properties.
        foreach (var fmt in formats)
            Console.WriteLine($"{fmt}: {value.ToString(fmt, dtfi)}");

        Console.WriteLine();

        // We don't want to change the FullDateTimePattern, so we need to save it.
        String originalFullDateTimePattern = dtfi.FullDateTimePattern;

        // Modify day name abbreviations and long date pattern.
        dtfi.AbbreviatedDayNames = new String[] { "Su", "M", "Tu", "W", "Th", "F", "Sa" };
        dtfi.LongDatePattern = "ddd dd-MMM-yyyy";
        dtfi.FullDateTimePattern = originalFullDateTimePattern;
        foreach (var fmt in formats)
            Console.WriteLine($"{fmt}: {value.ToString(fmt, dtfi)}");
    }
}
// The example displays the following output:
//       D: Tuesday, July 9, 2013
//       F: Tuesday, July 9, 2013 12:00:00 AM
//       f: Tuesday, July 9, 2013 12:00 AM
//
//       D: Tu 09-Jul-2013
//       F: Tuesday, July 9, 2013 12:00:00 AM
//       f: Tu 09-Jul-2013 12:00 AM
// </Snippet13>
