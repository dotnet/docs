// <Snippet9>
using System;

public class Example8
{
   public static void Main8()
   {
      TimeZoneInfo pst = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
      DateTime date1 = DateTime.SpecifyKind(new DateTime(2013, 3, 9, 10, 30, 0),
                                            DateTimeKind.Local);
      DateTime utc1 = date1.ToUniversalTime();
      TimeSpan interval = new TimeSpan(48, 0, 0);
      DateTime utc2 = utc1 + interval;
      DateTime date2 = TimeZoneInfo.ConvertTimeFromUtc(utc2, pst);
      Console.WriteLine("{0:g} + {1:N1} hours = {2:g}",
                        date1, interval.TotalHours, date2);
   }
}
// The example displays the following output:
//        3/9/2013 10:30 AM + 48.0 hours = 3/11/2013 11:30 AM
// </Snippet9>
