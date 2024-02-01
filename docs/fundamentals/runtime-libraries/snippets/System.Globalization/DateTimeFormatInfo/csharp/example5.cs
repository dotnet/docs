// <Snippet14>
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class Example5
{
    public static void Main()
    {
        CultureInfo enUS = CultureInfo.CreateSpecificCulture("en-US");
        DateTimeFormatInfo dtfi = enUS.DateTimeFormat;

        Console.WriteLine("Original Property Values:");
        Console.WriteLine("ShortTimePattern: " + dtfi.ShortTimePattern);
        Console.WriteLine("LongTimePattern: " + dtfi.LongTimePattern);
        Console.WriteLine("FullDateTimePattern: " + dtfi.FullDateTimePattern);
        Console.WriteLine();

        dtfi.LongTimePattern = ReplaceWith24HourClock(dtfi.LongTimePattern);
        dtfi.ShortTimePattern = ReplaceWith24HourClock(dtfi.ShortTimePattern);

        Console.WriteLine("Modififed Property Values:");
        Console.WriteLine("ShortTimePattern: " + dtfi.ShortTimePattern);
        Console.WriteLine("LongTimePattern: " + dtfi.LongTimePattern);
        Console.WriteLine("FullDateTimePattern: " + dtfi.FullDateTimePattern);
    }

    private static string ReplaceWith24HourClock(string fmt)
    {
        string pattern = @"^(?<openAMPM>\s*t+\s*)? " +
                         @"(?(openAMPM) h+(?<nonHours>[^ht]+)$ " +
                         @"| \s*h+(?<nonHours>[^ht]+)\s*t+)";
        return Regex.Replace(fmt, pattern, "HH${nonHours}",
                             RegexOptions.IgnorePatternWhitespace);
    }
}
// The example displays the following output:
//       Original Property Values:
//       ShortTimePattern: h:mm tt
//       LongTimePattern: h:mm:ss tt
//       FullDateTimePattern: dddd, MMMM dd, yyyy h:mm:ss tt
//
//       Modififed Property Values:
//       ShortTimePattern: HH:mm
//       LongTimePattern: HH:mm:ss
//       FullDateTimePattern: dddd, MMMM dd, yyyy HH:mm:ss
// </Snippet14>
