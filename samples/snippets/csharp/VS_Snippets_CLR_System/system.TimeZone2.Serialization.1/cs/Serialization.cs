// <Snippet1>
using System;

public class TimeZoneSerialization
{
   static string serializedEst;
   
   public static void Main()
   {
      // Retrieve Eastern Standard Time zone from registry
      try
      {
         TimeZoneSerialization tzs = new TimeZoneSerialization();
         TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
         // Create custom Eastern Time Zone for historical (pre-1918) conversions
         CreateTimeZone();
         // Call conversion function with one current and one pre-1918 date and time
         Console.WriteLine(ConvertUtcTime(DateTime.UtcNow, est));
         Console.WriteLine(ConvertUtcTime(new DateTime(1900, 11, 15, 9, 32, 00, DateTimeKind.Utc), est));
      }
      catch (TimeZoneNotFoundException)
      {
         Console.WriteLine("The Eastern Standard Time zone is not in the registry.");
      }
      catch (InvalidTimeZoneException)
      {
         Console.WriteLine("Data on the Eastern Standard Time Zone in the registry is corrupted.");
      }   
   }

   private static void CreateTimeZone()
   {
      // Create a simple Eastern Standard time zone 
      // without adjustment rules for 1883-1918
      TimeZoneInfo earlyEstZone = TimeZoneInfo.CreateCustomTimeZone("Eastern Standard Time", 
                                      new TimeSpan(-5, 0, 0), 
                                      " (GMT-05:00) Eastern Time (United States)",  
                                      "Eastern Standard Time");
      serializedEst = earlyEstZone.ToSerializedString();                        
   }
   
   private static DateTime ConvertUtcTime(DateTime utcDate, TimeZoneInfo tz) 
   {
      // Use time zone object from registry 
      if (utcDate.Year > 1917)
      {
         return TimeZoneInfo.ConvertTimeFromUtc(utcDate, tz);
      }   
      // Handle dates before introduction of DST
      else
      {
         // Restore serialized time zone object
         tz = TimeZoneInfo.FromSerializedString(serializedEst);
         return TimeZoneInfo.ConvertTimeFromUtc(utcDate, tz);
      }      
   }
}
// </Snippet1>
