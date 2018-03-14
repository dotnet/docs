// <Snippet2>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
      DateTime date1 = new DateTime(2011, 1, 1);
      Calendar cal = dfi.Calendar;
      
      Console.WriteLine("{0:d}: Week {1} ({2})", date1, 
                        cal.GetWeekOfYear(date1, dfi.CalendarWeekRule, 
                                          dfi.FirstDayOfWeek),
                        cal.ToString().Substring(cal.ToString().LastIndexOf(".") + 1));       
   }
}
// The example displays the following output:
//       1/1/2011: Week 1 (GregorianCalendar)
// </Snippet2>
