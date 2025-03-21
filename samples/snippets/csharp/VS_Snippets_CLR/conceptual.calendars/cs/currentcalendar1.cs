// <Snippet5>
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      // Change the current culture to zh-TW.
      CultureInfo zhTW = CultureInfo.CreateSpecificCulture("zh-TW");
      Thread.CurrentThread.CurrentCulture = zhTW;
      // Define a date.
      DateTime date1 = new DateTime(2011, 1, 16);

      // Display the date using the default (Gregorian) calendar.
      Console.WriteLine($"Current calendar: {zhTW.DateTimeFormat.Calendar}");
      Console.WriteLine(date1.ToString("d"));

      // Change the current calendar and display the date.
      zhTW.DateTimeFormat.Calendar = new TaiwanCalendar();
      Console.WriteLine($"Current calendar: {zhTW.DateTimeFormat.Calendar}");
      Console.WriteLine(date1.ToString("d"));
   }
}
// The example displays the following output:
//    Current calendar: System.Globalization.GregorianCalendar
//    2011/1/16
//    Current calendar: System.Globalization.TaiwanCalendar
//    100/1/16
// </Snippet5>