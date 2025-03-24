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
      Console.WriteLine($"{cal.GetMonth(date1)}/{cal.GetDayOfMonth(date1)}/{cal.GetYear(date1)} in Japanese Calendar -> {date1:d} in Gregorian");

      Console.WriteLine("\nDates instantiated with eras:");
      foreach (int era in cal.Eras) {
         DateTime date2 = cal.ToDateTime(year, month, day, 0, 0, 0, 0, era);
         Console.WriteLine($"{cal.GetMonth(date2)}/{cal.GetDayOfMonth(date2)}/{cal.GetYear(date2)} era {cal.GetEra(date2)} in Japanese Calendar -> {date2:d} in Gregorian");
      }
   }
}
