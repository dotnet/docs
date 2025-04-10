// <Snippet11>
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      DateTime dat = DateTime.MinValue;

      // Change the current culture to ja-JP with the Japanese Calendar.
      CultureInfo jaJP = CultureInfo.CreateSpecificCulture("ja-JP");
      jaJP.DateTimeFormat.Calendar = new JapaneseCalendar();
      Thread.CurrentThread.CurrentCulture = jaJP;
      Console.WriteLine($"Earliest supported date by {GetCalendarName(jaJP)} calendar: {jaJP.DateTimeFormat.Calendar.MinSupportedDateTime:d}");
      // Attempt to display the date.
      Console.WriteLine(dat.ToString());
      Console.WriteLine();

      // Change the current culture to ar-EG with the Um Al Qura calendar.
      CultureInfo arEG = CultureInfo.CreateSpecificCulture("ar-EG");
      arEG.DateTimeFormat.Calendar = new UmAlQuraCalendar();
      Thread.CurrentThread.CurrentCulture = arEG;
      Console.WriteLine($"Earliest supported date by {GetCalendarName(arEG)} calendar: {arEG.DateTimeFormat.Calendar.MinSupportedDateTime:d}");
      // Attempt to display the date.
      Console.WriteLine(dat.ToString());
      Console.WriteLine();

      // Change the current culture to en-US.
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
      Console.WriteLine(dat.ToString(jaJP));
      Console.WriteLine(dat.ToString(arEG));
      Console.WriteLine(dat.ToString("d"));
   }

   private static string GetCalendarName(CultureInfo culture)
   {
      Calendar cal = culture.DateTimeFormat.Calendar;
      return cal.GetType().Name.Replace("System.Globalization.", "").Replace("Calendar", "");
   }
}
// The example displays the following output:
//       Earliest supported date by Japanese calendar: 明治 1/9/8
//       0001-01-01T00:00:00
//
//       Earliest supported date by UmAlQura calendar: 01/01/18
//       0001-01-01T00:00:00
//
//       0001-01-01T00:00:00
//       0001-01-01T00:00:00
//       1/1/0001
// </Snippet11>
