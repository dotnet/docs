// <Snippet1>
using System;
using System.Collections.Generic;

public class TimeZoneApplication
{
   // Define collection of custom time zones
   private Dictionary<string, string> customTimeZones = new Dictionary<string, string>();
   private TimeZoneInfo cst;

   public TimeZoneApplication()
   {
      // Create custom Central Standard Time
      //
      // Declare necessary TimeZoneInfo.AdjustmentRule objects for time zone
      TimeZoneInfo customTimeZone;
      TimeSpan delta = new TimeSpan(1, 0, 0);
      TimeZoneInfo.AdjustmentRule adjustment;
      List<TimeZoneInfo.AdjustmentRule> adjustmentList = new List<TimeZoneInfo.AdjustmentRule>();
      // Declare transition time variables to hold transition time information
      TimeZoneInfo.TransitionTime transitionRuleStart, transitionRuleEnd;

      // Define end rule (for 1976-2006)
      transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 10, 5, DayOfWeek.Sunday);
      // Define rule (1976-1986)
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 04, 05, DayOfWeek.Sunday);
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(1976, 1, 1), new DateTime(1986, 12, 31), delta, transitionRuleStart, transitionRuleEnd);
      adjustmentList.Add(adjustment);
      // Define rule (1987-2006)
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 04, 01, DayOfWeek.Sunday);
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(1987, 1, 1), new DateTime(2006, 12, 31), delta, transitionRuleStart, transitionRuleEnd);
      adjustmentList.Add(adjustment);
      // Define rule (2007- )
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 03, 02, DayOfWeek.Sunday);
      transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 11, 01, DayOfWeek.Sunday);
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(2007, 01, 01), DateTime.MaxValue.Date, delta, transitionRuleStart, transitionRuleEnd);
      adjustmentList.Add(adjustment);

      // Create custom U.S. Central Standard Time zone
      customTimeZone = TimeZoneInfo.CreateCustomTimeZone("Central Standard Time",
                      new TimeSpan(-6, 0, 0),
                      "(GMT-06:00) Central Time (US Only)", "Central Standard Time",
                      "Central Daylight Time", adjustmentList.ToArray());
      // Add time zone to collection
      customTimeZones.Add(customTimeZone.Id, customTimeZone.ToSerializedString());

      // Create any other required time zones
   }

   public static void Main()
   {
      TimeZoneApplication tza = new TimeZoneApplication();
      tza.AppEntryPoint();
   }

   private void AppEntryPoint()
   {
      try
      {
         cst = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
      }
      catch (TimeZoneNotFoundException)
      {
         if (customTimeZones.ContainsKey("Central Standard Time"))
            HandleTimeZoneException("Central Standard Time");
      }
      catch (InvalidTimeZoneException)
      {
         if (customTimeZones.ContainsKey("Central Standard Time"))
            HandleTimeZoneException("Central Standard Time");
      }
      if (cst == null)
      {
         Console.WriteLine("Unable to load Central Standard Time zone.");
         return;
      }
      DateTime currentTime = DateTime.Now;
      Console.WriteLine($"The current {TimeZoneInfo.Local.IsDaylightSavingTime(currentTime) ?
                            TimeZoneInfo.Local.StandardName :
                            TimeZoneInfo.Local.DaylightName} time is {currentTime.ToString("f")}.");
      Console.WriteLine($"The current {cst.IsDaylightSavingTime(currentTime) ?
                            cst.StandardName :
                            cst.DaylightName} time is {TimeZoneInfo.ConvertTime(currentTime, TimeZoneInfo.Local, cst).ToString("f")}.");
   }

   private void HandleTimeZoneException(string timeZoneName)
   {
      string tzString = customTimeZones[timeZoneName];
      cst = TimeZoneInfo.FromSerializedString(tzString);
   }
}
// </Snippet1>
