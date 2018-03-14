using System;

[assembly:CLSCompliant(true)]

namespace TimeZoneInfoCode
{
public class TimeOffsets
{
   public static void Main()
   {
      TimeOffsets to = new TimeOffsets();
      to.Start();
   }
   
   private void Start()
   {
      // <Snippet2>
      Console.WriteLine();
      ShowPossibleUtcTimes(new DateTime(2007, 11, 4, 1, 0, 0), 
                           TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
      Console.WriteLine();
      ShowPossibleUtcTimes(new DateTime(2007, 11, 4, 01, 00, 00, DateTimeKind.Local), 
                           TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
      Console.WriteLine();
      ShowPossibleUtcTimes(new DateTime(2007, 11, 4, 00, 00, 00, DateTimeKind.Local), 
                           TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
      Console.WriteLine();                     
      ShowPossibleUtcTimes(new DateTime(2007, 11, 4, 01, 00, 00, DateTimeKind.Unspecified), 
                           TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
      Console.WriteLine();
      ShowPossibleUtcTimes(new DateTime(2007, 11, 4, 07, 00, 00, DateTimeKind.Utc), 
                           TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
      // 
      // This example produces the following output if run in the Pacific time zone:
      //
      //    11/4/2007 1:00:00 AM (GMT-06:00) Central Time (US & Canada) maps to the following possible times:
      //    If 11/4/2007 1:00:00 AM is Central Standard Time, 11/4/2007 7:00:00 AM UTC
      //    If 11/4/2007 1:00:00 AM is Central Daylight Time, 11/4/2007 6:00:00 AM UTC
      //       
      //    11/4/2007 1:00:00 AM Pacific Standard Time is not ambiguous in time zone (GMT-06:00) Central Time (US & Canada).
      //     
      //    11/4/2007 12:00:00 AM local time maps to the following possible times:
      //    If 11/4/2007 1:00:00 AM is Central Standard Time, 11/4/2007 7:00:00 AM UTC
      //    If 11/4/2007 1:00:00 AM is Central Daylight Time, 11/4/2007 6:00:00 AM UTC
      //    
      //    11/4/2007 1:00:00 AM (GMT-06:00) Central Time (US & Canada) maps to the following possible times:
      //    If 11/4/2007 1:00:00 AM is Central Standard Time, 11/4/2007 7:00:00 AM UTC
      //    If 11/4/2007 1:00:00 AM is Central Daylight Time, 11/4/2007 6:00:00 AM UTC
      //       
      //    11/4/2007 7:00:00 AM UTC maps to the following possible times:
      //    If 11/4/2007 1:00:00 AM is Central Standard Time, 11/4/2007 7:00:00 AM UTC
      //    If 11/4/2007 1:00:00 AM is Central Daylight Time, 11/4/2007 6:00:00 AM UTC
      //
      // </Snippet2>                     
   }
   
   // <Snippet1>
   private void ShowPossibleUtcTimes(DateTime ambiguousTime, TimeZoneInfo timeZone)
   {
      // Determine if time is ambiguous in target time zone
      if (! timeZone.IsAmbiguousTime(ambiguousTime))
      {
         Console.WriteLine("{0} is not ambiguous in time zone {1}.", 
                           ambiguousTime, 
                           timeZone.DisplayName);
      }
      else
      {
         // Display time and its time zone (local, UTC, or indicated by timeZone argument)
         string originalTimeZoneName; 
         if (ambiguousTime.Kind == DateTimeKind.Utc)
            originalTimeZoneName = "UTC";
         else if (ambiguousTime.Kind == DateTimeKind.Local)
            originalTimeZoneName = "local time";
         else
            originalTimeZoneName = timeZone.DisplayName;

         Console.WriteLine("{0} {1} maps to the following possible times:", 
                           ambiguousTime, originalTimeZoneName);
         // Get ambiguous offsets 
         TimeSpan[] offsets = timeZone.GetAmbiguousTimeOffsets(ambiguousTime);
         // Handle times not in time zone of timeZone argument
         // Local time where timeZone is not local zone
         if ((ambiguousTime.Kind == DateTimeKind.Local) && ! timeZone.Equals(TimeZoneInfo.Local)) 
            ambiguousTime = TimeZoneInfo.ConvertTime(ambiguousTime, TimeZoneInfo.Local, timeZone);
         // UTC time where timeZone is not UTC zone   
         else if ((ambiguousTime.Kind == DateTimeKind.Utc) && ! timeZone.Equals(TimeZoneInfo.Utc))
            ambiguousTime = TimeZoneInfo.ConvertTime(ambiguousTime, TimeZoneInfo.Utc, timeZone);

         // Display each offset and its mapping to UTC
         foreach (TimeSpan offset in offsets)
         {
            if (offset.Equals(timeZone.BaseUtcOffset))
               Console.WriteLine("If {0} is {1}, {2} UTC", ambiguousTime, timeZone.StandardName, ambiguousTime - offset);
            else
               Console.WriteLine("If {0} is {1}, {2} UTC", ambiguousTime, timeZone.DaylightName, ambiguousTime - offset);
         }
      }            
   }
   // </Snippet1>
}
} // end namespace
