// <Snippet8>
using System;

public struct TimeZoneTime
{
   public TimeZoneInfo TimeZone;
   public DateTime Time;

   public TimeZoneTime(TimeZoneInfo tz, DateTime time)
   {
      if (tz == null)
         throw new ArgumentNullException("The time zone cannot be a null reference.");

      this.TimeZone = tz;
      this.Time = time;
   }

   public TimeZoneTime AddTime(TimeSpan interval)
   {
      // Convert time to UTC
      DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(this.Time, this.TimeZone);
      // Add time interval to time
      utcTime = utcTime.Add(interval);
      // Convert time back to time in time zone
      return new TimeZoneTime(this.TimeZone, TimeZoneInfo.ConvertTime(utcTime,
                              TimeZoneInfo.Utc, this.TimeZone));
   }
}

public class TimeArithmetic
{
   public const string tzName = "Central Standard Time";

   public static void Main()
   {
      try
      {
         TimeZoneTime cstTime1, cstTime2;

         TimeZoneInfo cst = TimeZoneInfo.FindSystemTimeZoneById(tzName);
         DateTime time1 = new DateTime(2008, 3, 9, 1, 30, 0);
         TimeSpan twoAndAHalfHours = new TimeSpan(2, 30, 0);

         cstTime1 = new TimeZoneTime(cst, time1);
         cstTime2 = cstTime1.AddTime(twoAndAHalfHours);
         Console.WriteLine("{0} + {1} hours = {2}", cstTime1.Time,
                                                    twoAndAHalfHours.ToString(),
                                                    cstTime2.Time);
      }
      catch
      {
         Console.WriteLine($"Unable to find {tzName}.");
      }
   }
}
// </Snippet8>
