using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      int year = 2;
      int month = 1;
      int day = 1;
      Calendar cal = new JapaneseCalendar();

      Console.WriteLine("\nDate instantiated without an era:");
      DateTime date1 = new DateTime(year, month, day, 0, 0, 0, 0, cal);
      Console.WriteLine("{0}/{1}/{2} in Japanese Calendar -> {3:d} in Gregorian",
                        cal.GetMonth(date1), cal.GetDayOfMonth(date1),
                        cal.GetYear(date1), date1);

      Console.WriteLine("\nDates instantiated with eras:");
      foreach (int era in cal.Eras) {
         DateTime date2 = cal.ToDateTime(year, month, day, 0, 0, 0, 0, era);
         Console.WriteLine("{0}/{1}/{2} era {3} in Japanese Calendar -> {4:d} in Gregorian",
                           cal.GetMonth(date2), cal.GetDayOfMonth(date2),
                           cal.GetYear(date2), cal.GetEra(date2), date2);
      }
   }
}
