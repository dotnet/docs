using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        var japaneseCal = new JapaneseCalendar();
        var jaJp = new CultureInfo("ja-JP");
        jaJp.DateTimeFormat.Calendar = japaneseCal;

        // We can get the era index by calling DateTimeFormatInfo.GetEraName.
        int eraIndex = 0;

        for (int ctr = 0; ctr < jaJp.DateTimeFormat.Calendar.Eras.Length; ctr++)
           if (jaJp.DateTimeFormat.GetEraName(ctr) == "明治")
              eraIndex = ctr;
        var date1 = japaneseCal.ToDateTime(23, 9, 8, 0, 0, 0, 0, eraIndex);
        Console.WriteLine($"{date1.ToString("d", jaJp)} (Gregorian {date1:d})");

        try {
            var date2 = DateTime.Parse("明治23/9/8", jaJp);
            Console.WriteLine($"{date2.ToString("d", jaJp)} (Gregorian {date2:d})");
        }
        catch (FormatException)
        {
            Console.WriteLine("The parsing operation failed.");
        }

        try {
            var date3 = DateTime.ParseExact("明治23/9/8", "gyy/M/d", jaJp);
            Console.WriteLine($"{date3.ToString("d", jaJp)} (Gregorian {date3:d})");
        }
        catch (FormatException)
        {
            Console.WriteLine("The parsing operation failed.");
        }
    }
}
// The example displays the following output:
//   明治23/9/8 (Gregorian 9/8/1890)
//   明治23/9/8 (Gregorian 9/8/1890)
//   明治23/9/8 (Gregorian 9/8/1890)
