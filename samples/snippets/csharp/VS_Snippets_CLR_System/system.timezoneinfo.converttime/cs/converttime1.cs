// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      // Define times to be converted.
      DateTime[] times = { new DateTime(2010, 1, 1, 0, 1, 0), 
                           new DateTime(2010, 1, 1, 0, 1, 0, DateTimeKind.Utc), 
                           new DateTime(2010, 1, 1, 0, 1, 0, DateTimeKind.Local),                            
                           new DateTime(2010, 11, 6, 23, 30, 0),
                           new DateTime(2010, 11, 7, 2, 30, 0) };
                              
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
      foreach (DateTime timeToConvert in times)
      {
         DateTime targetTime = TimeZoneInfo.ConvertTime(timeToConvert, est);
         Console.WriteLine("Converted {0} {1} to {2}.", timeToConvert, 
                           timeToConvert.Kind, targetTime);
      }                        
   }
}
// The example displays the following output:
//    Local time zone: (GMT-08:00) Pacific Time (US & Canada)
//    
//    Converted 1/1/2010 12:01:00 AM Unspecified to 1/1/2010 3:01:00 AM.
//    Converted 1/1/2010 12:01:00 AM Utc to 12/31/2009 7:01:00 PM.
//    Converted 1/1/2010 12:01:00 AM Local to 1/1/2010 3:01:00 AM.
//    Converted 11/6/2010 11:30:00 PM Unspecified to 11/7/2010 1:30:00 AM.
//    Converted 11/7/2010 2:30:00 AM Unspecified to 11/7/2010 5:30:00 AM.
// </Snippet1>
