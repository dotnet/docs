using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        var japaneseCal = new JapaneseCalendar();
        var jaJp = new CultureInfo("ja-JP");
        jaJp.DateTimeFormat.Calendar = japaneseCal;

        var date = new DateTime(2, 1, 1, japaneseCal);
        Console.WriteLine($"Gregorian calendar date: {date:d}");
        Console.WriteLine($"Japanese calendar date: {date.ToString("d", jaJp)}");
    }
}
