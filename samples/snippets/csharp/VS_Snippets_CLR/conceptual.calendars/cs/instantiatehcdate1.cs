// <Snippet4>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      HebrewCalendar hc = new HebrewCalendar();

      DateTime date1 = new DateTime(5771, 6, 1, hc);
      DateTime date2 = hc.ToDateTime(5771, 6, 1, 0, 0, 0, 0);

      Console.WriteLine("{0:d} (Gregorian) = {1:d2}/{2:d2}/{3:d4} ({4}): {5}",
                        date1,
                        hc.GetMonth(date2),
                        hc.GetDayOfMonth(date2),
                        hc.GetYear(date2),
                        GetCalendarName(hc),
                        date1.Equals(date2));
   }

   private static string GetCalendarName(Calendar cal)
   {
      return cal.ToString().Replace("System.Globalization.", "").
                            Replace("Calendar", "");
   }
}
// The example displays the following output:
//    2/5/2011 (Gregorian) = 06/01/5771 (Hebrew): True
// </Snippet4>
