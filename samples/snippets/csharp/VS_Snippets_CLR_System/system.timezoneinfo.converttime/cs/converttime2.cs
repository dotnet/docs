// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      // Define times to be converted.
      DateTime time1 = new DateTime(2010, 1, 1, 12, 1, 0);
      DateTime time2 = new DateTime(2010, 11, 6, 23, 30, 0);
      DateTimeOffset[] times = { new DateTimeOffset(time1, TimeZoneInfo.Local.GetUtcOffset(time1)),
                                 new DateTimeOffset(time1, TimeSpan.Zero),
                                 new DateTimeOffset(time2, TimeZoneInfo.Local.GetUtcOffset(time2)),
                                 new DateTimeOffset(time2.AddHours(3), TimeZoneInfo.Local.GetUtcOffset(time2.AddHours(3))) };
                              
      // Retrieve the time zone for Eastern Standard Time (U.S. and Canada).
      TimeZoneInfo est; 
      try {
         est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
      }
      catch (TimeZoneNotFoundException) {
         Console.WriteLine("Unable to retrieve the Eastern Standard time zone.");
         return;
      }
      catch (InvalidTimeZoneException) {
         Console.WriteLine("Unable to retrieve the Eastern Standard time zone.");
         return;
      }   

      // Display the current time zone name.
      Console.WriteLine("Local time zone: {0}\n", TimeZoneInfo.Local.DisplayName);
      
      // Convert each time in the array.
      foreach (DateTimeOffset timeToConvert in times)
      {
         DateTimeOffset targetTime = TimeZoneInfo.ConvertTime(timeToConvert, est);
         Console.WriteLine("Converted {0} to {1}.", timeToConvert, targetTime);
      }                        
   }
}
// The example displays the following output:
//    Local time zone: (GMT-08:00) Pacific Time (US & Canada)
//    
//    Converted 1/1/2010 12:01:00 AM -08:00 to 1/1/2010 3:01:00 AM -05:00.
//    Converted 1/1/2010 12:01:00 AM +00:00 to 12/31/2009 7:01:00 PM -05:00.
//    Converted 11/6/2010 11:30:00 PM -07:00 to 11/7/2010 1:30:00 AM -05:00.
//    Converted 11/7/2010 2:30:00 AM -08:00 to 11/7/2010 5:30:00 AM -05:00.
// </Snippet2>
