using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        var japaneseCal = new JapaneseCalendar();
        var jaJp = new CultureInfo("ja-JP");
        jaJp.DateTimeFormat.Calendar = japaneseCal;

        var date = new DateTime(1905, 2, 12);
        Console.WriteLine($"Gregorian calendar date: {date:d}");

        // Call the ToString(IFormatProvider) method.
        Console.WriteLine($"Japanese calendar date: {date.ToString("d", jaJp)}");

        // Use a FormattableString object.
        FormattableString fmt = $"{date:d}";
        Console.WriteLine($"Japanese calendar date: {fmt.ToString(jaJp)}");

        // Use the JapaneseCalendar object.
        Console.WriteLine($"Japanese calendar date: {jaJp.DateTimeFormat.GetEraName(japaneseCal.GetEra(date))}" +
                          $"{japaneseCal.GetYear(date)}/{japaneseCal.GetMonth(date)}/{japaneseCal.GetDayOfMonth(date)}");

        // Use the current culture.
        CultureInfo.CurrentCulture = jaJp;
        Console.WriteLine($"Japanese calendar date: {date:d}");
    }
}
// The example displays the following output:
//   Gregorian calendar date: 2/12/1905
//   Japanese calendar date: 明治38/2/12
//   Japanese calendar date: 明治38/2/12
//   Japanese calendar date: 明治38/2/12
//   Japanese calendar date: 明治38/2/12
