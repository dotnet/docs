// <Snippet5>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      var faIR = new CultureInfo("fa-IR");
      var umAlQura = faIR.DateTimeFormat.Calendar;
      var dat = new DateTime(1395, 8, 18, umAlQura);
      Console.WriteLine("Using the Umm-al-Qura calendar:");
      Console.WriteLine("Date: {0}", dat.ToString("d", faIR));
      Console.WriteLine("Day of Week: {0}", umAlQura.GetDayOfWeek(dat));
      Console.WriteLine("Week of year: {0}\n", 
                        umAlQura.GetWeekOfYear(dat, CalendarWeekRule.FirstDay, 
                                               DayOfWeek.Sunday));
      
      var greg = new GregorianCalendar(); 
      Console.WriteLine("Using the Gregorian calendar:");
      Console.WriteLine("Date: {0:d}", dat);
      Console.WriteLine("Day of Week: {0}", dat.DayOfWeek);
      Console.WriteLine("Week of year: {0}", 
                         greg.GetWeekOfYear(dat, CalendarWeekRule.FirstDay, 
                                            DayOfWeek.Sunday));
   }
}
// The example displays the following output:
//       Using the Umm-al-Qura calendar:
//       Date: 18/08/1395
//       Day of Week: Tuesday
//       Week of year: 34
//       
//       Using the Gregorian calendar:
//       Date: 11/8/2016
//       Day of Week: Tuesday
//       Week of year: 46
// </Snippet5>

