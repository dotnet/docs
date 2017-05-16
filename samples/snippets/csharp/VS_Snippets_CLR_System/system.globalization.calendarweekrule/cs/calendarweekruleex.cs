// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   static Calendar cal = new GregorianCalendar();
   
   public static void Main()
   {
      DateTime date = new DateTime(2013, 1, 5);
      DayOfWeek firstDay = DayOfWeek.Sunday;
      CalendarWeekRule rule;
      
      rule = CalendarWeekRule.FirstFullWeek;
      ShowWeekNumber(date, rule, firstDay);
      
      rule = CalendarWeekRule.FirstFourDayWeek;
      ShowWeekNumber(date, rule, firstDay);
      
      Console.WriteLine();
      date = new DateTime(2010, 1, 3);
      ShowWeekNumber(date, rule, firstDay);
   }

   private static void ShowWeekNumber(DateTime dat, CalendarWeekRule rule, 
                                      DayOfWeek firstDay)
   {                                   
      Console.WriteLine("{0:d} with {1:F} rule and {2:F} as first day of week: week {3}",
                        dat, rule, firstDay, cal.GetWeekOfYear(dat, rule, firstDay));
   }   
}
// The example displays the following output:
//       1/5/2013 with FirstFullWeek rule and Sunday as first day of week: week 53
//       1/5/2013 with FirstFourDayWeek rule and Sunday as first day of week: week 1
//       
//       1/3/2010 with FirstFourDayWeek rule and Sunday as first day of week: week 1
// </Snippet1>