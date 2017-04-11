// <Snippet6>
using System;
using System.Globalization;
using System.IO;
using System.Collections.ObjectModel;

public class Example
{
   public static void Main()
   {
      const string OUTPUTFILENAME = @"C:\Temp\TimeZoneInfo.txt";
   
      DateTimeFormatInfo dateFormats = CultureInfo.CurrentCulture.DateTimeFormat;
      ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones(); 
      StreamWriter sw = new StreamWriter(OUTPUTFILENAME, false);
   
      foreach (TimeZoneInfo timeZone in timeZones)
      {
         bool hasDST = timeZone.SupportsDaylightSavingTime;
         TimeSpan offsetFromUtc = timeZone.BaseUtcOffset;
         TimeZoneInfo.AdjustmentRule[] adjustRules;
         string offsetString;
      
         sw.WriteLine("ID: {0}", timeZone.Id);
         sw.WriteLine("   Display Name: {0, 40}", timeZone.DisplayName);
         sw.WriteLine("   Standard Name: {0, 39}", timeZone.StandardName);
         sw.Write("   Daylight Name: {0, 39}", timeZone.DaylightName);
         sw.Write(hasDST ? "   ***Has " : "   ***Does Not Have ");
         sw.WriteLine("Daylight Saving Time***");
         offsetString = String.Format("{0} hours, {1} minutes", offsetFromUtc.Hours, offsetFromUtc.Minutes);
         sw.WriteLine("   Offset from UTC: {0, 40}", offsetString);
         adjustRules = timeZone.GetAdjustmentRules();
         sw.WriteLine("   Number of adjustment rules: {0, 26}", adjustRules.Length);  
         if (adjustRules.Length > 0)
         {
            sw.WriteLine("   Adjustment Rules:");
            foreach (TimeZoneInfo.AdjustmentRule rule in adjustRules)
            {
               TimeZoneInfo.TransitionTime transTimeStart = rule.DaylightTransitionStart;
               TimeZoneInfo.TransitionTime transTimeEnd = rule.DaylightTransitionEnd; 
            
               sw.WriteLine("      From {0} to {1}", rule.DateStart, rule.DateEnd);
               sw.WriteLine("      Delta: {0}", rule.DaylightDelta);
               if (! transTimeStart.IsFixedDateRule)
               {
                  sw.WriteLine("      Begins at {0:t} on {1} of week {2} of {3}", transTimeStart.TimeOfDay, 
                                                                                transTimeStart.DayOfWeek,                                                                                 
                                                                                transTimeStart.Week, 
                                                                                dateFormats.MonthNames[transTimeStart.Month - 1]);
                  sw.WriteLine("      Ends at {0:t} on {1} of week {2} of {3}", transTimeEnd.TimeOfDay,
                                                                                transTimeEnd.DayOfWeek, 
                                                                                transTimeEnd.Week,
                                                                                dateFormats.MonthNames[transTimeEnd.Month - 1]);
               }
               else
               {
                  sw.WriteLine("      Begins at {0:t} on {1} {2}", transTimeStart.TimeOfDay, 
                                                                 transTimeStart.Day, 
                                                                 dateFormats.MonthNames[transTimeStart.Month - 1]);
                  sw.WriteLine("      Ends at {0:t} on {1} {2}", transTimeEnd.TimeOfDay, 
                                                               transTimeEnd.Day, 
                                                               dateFormats.MonthNames[transTimeEnd.Month - 1]);
               }
            }
         }            
      }
      sw.Close();
   }
}
// </Snippet6>
      
