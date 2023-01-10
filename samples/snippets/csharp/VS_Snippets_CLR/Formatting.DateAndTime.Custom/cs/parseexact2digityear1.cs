// <Snippet19>
using System;
using System.Globalization;
using System.Threading;

public class Example7
{
    public static void Main()
    {
        string fmt = "dd-MMM-yy";
        string value = "24-Jan-49";

        Calendar cal = (Calendar)CultureInfo.CurrentCulture.Calendar.Clone();
        Console.WriteLine("Two Digit Year Range: {0} - {1}",
                          cal.TwoDigitYearMax - 99, cal.TwoDigitYearMax);

        Console.WriteLine("{0:d}", DateTime.ParseExact(value, fmt, null));
        Console.WriteLine();

        cal.TwoDigitYearMax = 2099;
        CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
        culture.DateTimeFormat.Calendar = cal;
        Thread.CurrentThread.CurrentCulture = culture;

        Console.WriteLine("Two Digit Year Range: {0} - {1}",
                          cal.TwoDigitYearMax - 99, cal.TwoDigitYearMax);
        Console.WriteLine("{0:d}", DateTime.ParseExact(value, fmt, null));
    }
}
// The example displays the following output:
//       Two Digit Year Range: 1930 - 2029
//       1/24/1949
//
//       Two Digit Year Range: 2000 - 2099
//       1/24/2049
// </Snippet19>
