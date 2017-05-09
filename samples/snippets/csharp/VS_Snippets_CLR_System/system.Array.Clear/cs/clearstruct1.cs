// <Snippet2>
using System;

public struct TimeZoneTime
{
   private DateTimeOffset dt;
   private TimeZoneInfo tz;
   
   public TimeZoneTime(DateTimeOffset dateTime, TimeZoneInfo timeZone)
   {
      dt = dateTime;
      tz = timeZone;
   }

   public DateTimeOffset DateTime 
   { get { return dt; } }
   
   public TimeZoneInfo TimeZone 
   { get { return tz; } }
}

public class Example
{
   public static void Main()
   {
      // Declare an array with two elements.
      TimeZoneTime[] timeZoneTimes = { new TimeZoneTime(DateTime.Now, TimeZoneInfo.Local),
                                       new TimeZoneTime(DateTime.Now, TimeZoneInfo.Utc) };   
      foreach (var timeZoneTime in timeZoneTimes)
         Console.WriteLine("{0}: {1:G}", 
                           timeZoneTime.TimeZone == null ? "<null>" : timeZoneTime.TimeZone.ToString(), 
                           timeZoneTime.DateTime);
      Console.WriteLine();
      
      Array.Clear(timeZoneTimes, 1, 1);
      foreach (var timeZoneTime in timeZoneTimes)
         Console.WriteLine("{0}: {1:G}", 
                           timeZoneTime.TimeZone == null ? "<null>" : timeZoneTime.TimeZone.ToString(), 
                           timeZoneTime.DateTime);
   }
}
// The example displays the following output:
//       (UTC-08:00) Pacific Time (US & Canada): 1/20/2014 12:11:00 PM
//       UTC: 1/20/2014 12:11:00 PM
//       
//       (UTC-08:00) Pacific Time (US & Canada): 1/20/2014 12:11:00 PM
//       <null>: 1/1/0001 12:00:00 AM
// </Snippet2>