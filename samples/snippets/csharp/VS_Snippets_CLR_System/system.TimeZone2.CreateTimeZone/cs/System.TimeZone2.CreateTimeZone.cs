using System;
using System.IO;
// <Snippet6>
using System.Collections.Generic;
using System.Collections.ObjectModel;
// </Snippet6>

public class TimeZoneCreation
{
   public static void Main()
   {
      Console.WriteLine("First Overload of CreateCustomTimeZone: ");
      TimeZoneCreation tzc = new TimeZoneCreation();
      tzc.DefineMawsonTime();
      Console.WriteLine();
      Console.WriteLine("Second Overload of CreateCustomTimeZone: ");
      tzc.DefinePalmerTime();
      Console.WriteLine();
      tzc.DefineNonDSTTime();
      Console.WriteLine("About to create Antarctic/South Pole time zone");
      // Define Time Zone for Serialization
      TimeZoneInfo southPole = tzc.InitializeTimeZone();
      tzc.TestCST();
   }

   private void TestCST()
   {
      Console.WriteLine();
      Console.WriteLine("Testing new Central Standard Time zone...");
      Console.WriteLine();
      TimeZoneInfo cst = CreateNewCentralStandardTimeZone();
      // <Snippet7>
      TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

      DateTime pastDate1 = new DateTime(1942, 2, 11);
      Console.WriteLine("Is {0} daylight saving time: {1}", pastDate1,
                        cst.IsDaylightSavingTime(pastDate1));

      DateTime pastDate2 = new DateTime(1967, 10, 29, 1, 30, 00);
      Console.WriteLine("Is {0} ambiguous: {1}", pastDate2,
                        cst.IsAmbiguousTime(pastDate2));

      DateTime pastDate3 = new DateTime(1974, 1, 7, 2, 59, 00);
      Console.WriteLine("{0} {1} is {2} {3}", pastDate3,
                        est.IsDaylightSavingTime(pastDate3) ?
                            est.DaylightName : est.StandardName,
                        TimeZoneInfo.ConvertTime(pastDate3, est, cst),
                        cst.IsDaylightSavingTime(TimeZoneInfo.ConvertTime(pastDate3, est, cst)) ?
                            cst.DaylightName : cst.StandardName);
      //
      // This code produces the following output to the console:
      //
      //    Is 2/11/1942 12:00:00 AM daylight saving time: True
      //    Is 10/29/1967 1:30:00 AM ambiguous: True
      //    1/7/1974 2:59:00 AM Eastern Standard Time is 1/7/1974 2:59:00 AM Central Daylight Time
      // </Snippet7>
   }

   private void DefineMawsonTime()
   {
      // <Snippet1>
      string displayName = "(GMT+06:00) Antarctica/Mawson Time";
      string standardName = "Mawson Time";
      TimeSpan offset = new TimeSpan(06, 00, 00);
      TimeZoneInfo mawson = TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName);
      Console.WriteLine("The current time is {0} {1}",
                        TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, mawson),
                        mawson.StandardName);
      // </Snippet1>
   }

   private void DefinePalmerTime()
   {
      // <Snippet2>
      // Define transition times to/from DST
      TimeZoneInfo.TransitionTime startTransition, endTransition;
      startTransition = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 4, 0, 0),
                                                                        10, 2, DayOfWeek.Sunday);
      endTransition = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 3, 0, 0),
                                                                      3, 2, DayOfWeek.Sunday);
      // Define adjustment rule
      TimeSpan delta = new TimeSpan(1, 0, 0);
      TimeZoneInfo.AdjustmentRule adjustment;
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(1999, 10, 1), DateTime.MaxValue.Date, delta, startTransition, endTransition);
      // Create array for adjustment rules
      TimeZoneInfo.AdjustmentRule[] adjustments = {adjustment};
      // Define other custom time zone arguments
      string displayName = "(GMT-04:00) Antarctica/Palmer Time";
      string standardName = "Palmer Time";
      string daylightName = "Palmer Daylight Time";
      TimeSpan offset = new TimeSpan(-4, 0, 0);
      TimeZoneInfo palmer = TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName, daylightName, adjustments);
      Console.WriteLine("The current time is {0} {1}",
                        TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, palmer),
                        palmer.StandardName);
      // </Snippet2>
   }

   private void DefineNonDSTTime()
   {
      // <Snippet3>
      // Define transition times to/from DST
      TimeZoneInfo.TransitionTime startTransition, endTransition;
      startTransition = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 4, 0, 0),
                                                                        10, 2, DayOfWeek.Sunday);
      endTransition = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1,3, 0, 0),
                                                                      3, 2, DayOfWeek.Sunday);
      // Define adjustment rule
      TimeSpan delta = new TimeSpan(1, 0, 0);
      TimeZoneInfo.AdjustmentRule adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(1999, 10, 1),
                                            DateTime.MaxValue.Date, delta, startTransition, endTransition);
      // Create array for adjustment rules
      TimeZoneInfo.AdjustmentRule[] adjustments = {adjustment};
      // Define other custom time zone arguments
      string displayName = "(GMT-04:00) Antarctica/Palmer Time";
      string standardName = "Palmer Standard Time";
      string daylightName = "Palmer Daylight Time";
      TimeSpan offset = new TimeSpan(-4, 0, 0);
      // Create custom time zone without copying DST information
      TimeZoneInfo palmer = TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName,
                                                        daylightName, adjustments, true);
      // Indicate whether new time zone//s adjustment rules are present
      Console.WriteLine("{0} {1}has {2} adjustment rules.",
                        palmer.StandardName,
                        ! (string.IsNullOrEmpty(palmer.DaylightName)) ?  "(" + palmer.DaylightName + ") ": "" ,
                        palmer.GetAdjustmentRules().Length);
      // Indicate whether new time zone supports DST
      Console.WriteLine($"{palmer.StandardName} supports DST: {palmer.SupportsDaylightSavingTime}");
      // </Snippet3>
   }

   // <Snippet4>
   private TimeZoneInfo InitializeTimeZone()
   {
      TimeZoneInfo southPole = null;
      // Determine if South Pole time zone is defined in system
      try
      {
         southPole = TimeZoneInfo.FindSystemTimeZoneById("Antarctica/South Pole Standard Time");
      }
      // Time zone does not exist; create it, store it in a text file, and return it
      catch
      {
         const string filename = @".\TimeZoneInfo.txt";
         bool found = false;

         if (File.Exists(filename))
         {
            StreamReader reader = new StreamReader(filename);
            string timeZoneInfo;
            while (reader.Peek() >= 0)
            {
               timeZoneInfo = reader.ReadLine();
               if (timeZoneInfo.Contains("Antarctica/South Pole"))
               {
                  southPole = TimeZoneInfo.FromSerializedString(timeZoneInfo);
                  reader.Close();
                  found = true;
                  break;
               }
            }
         }
         if (! found)
         {
            // Define transition times to/from DST
            TimeZoneInfo.TransitionTime startTransition = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 10, 1, DayOfWeek.Sunday);
            TimeZoneInfo.TransitionTime endTransition = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 3, 3, DayOfWeek.Sunday);
            // Define adjustment rule
            TimeSpan delta = new TimeSpan(1, 0, 0);
            TimeZoneInfo.AdjustmentRule adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(1989, 10, 1), DateTime.MaxValue.Date, delta, startTransition, endTransition);
            // Create array for adjustment rules
            TimeZoneInfo.AdjustmentRule[] adjustments = {adjustment};
            // Define other custom time zone arguments
            string displayName = "(GMT+12:00) Antarctica/South Pole";
            string standardName = "Antarctica/South Pole Standard Time";
            string daylightName = "Antarctica/South Pole Daylight Time";
            TimeSpan offset = new TimeSpan(12, 0, 0);
            southPole = TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName, daylightName, adjustments);
            // Write time zone to the file
            StreamWriter writer = new StreamWriter(filename, true);
            writer.WriteLine(southPole.ToSerializedString());
            writer.Close();
         }
      }
      return southPole;
   }
   // </Snippet4>

   private TimeZoneInfo CreateNewCentralStandardTimeZone()
   {
      // <Snippet5>
      TimeZoneInfo cst;
      // Declare necessary TimeZoneInfo.AdjustmentRule objects for time zone
      TimeSpan delta = new TimeSpan(1, 0, 0);
      TimeZoneInfo.AdjustmentRule adjustment;
      List<TimeZoneInfo.AdjustmentRule> adjustmentList = new List<TimeZoneInfo.AdjustmentRule>();
      // Declare transition time variables to hold transition time information
      TimeZoneInfo.TransitionTime transitionRuleStart, transitionRuleEnd;

      // Define new Central Standard Time zone 6 hours earlier than UTC
      // Define rule 1 (for 1918-1919)
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 03, 05, DayOfWeek.Sunday);
      transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 10, 05, DayOfWeek.Sunday);
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(1918, 1, 1), new DateTime(1919, 12, 31), delta,
                                                                 transitionRuleStart, transitionRuleEnd);
      adjustmentList.Add(adjustment);
      // Define rule 2 (for 1942)
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFixedDateRule(new DateTime(1, 1, 1, 2, 0, 0), 02, 09);
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(1942, 1, 1), new DateTime(1942, 12, 31),
                                                                 delta, transitionRuleStart, transitionRuleEnd);
      adjustmentList.Add(adjustment);
      // Define rule 3 (for 1945)
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFixedDateRule(new DateTime(1, 1, 1, 23, 0, 0), 08, 14);
      transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFixedDateRule(new DateTime(1, 1, 1, 2, 0, 0), 09, 30);
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(1945, 1, 1), new DateTime(1945, 12, 31),
                                                                 delta, transitionRuleStart, transitionRuleEnd);
      adjustmentList.Add(adjustment);
      // Define end rule (for 1967-2006)
      transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 10, 5, DayOfWeek.Sunday);
      // Define rule 4 (for 1967-73)
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 04, 05, DayOfWeek.Sunday);
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(1967, 1, 1), new DateTime(1973, 12, 31),
                                                                 delta, transitionRuleStart, transitionRuleEnd);
      adjustmentList.Add(adjustment);
      // Define rule 5 (for 1974 only)
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFixedDateRule(new DateTime(1, 1, 1, 2, 0, 0), 01, 06);
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(1974, 1, 1), new DateTime(1974, 12, 31),
                                                                 delta, transitionRuleStart, transitionRuleEnd);
      adjustmentList.Add(adjustment);
      // Define rule 6 (for 1975 only)
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFixedDateRule(new DateTime(1, 1, 1, 2, 0, 0), 02, 23);
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(1975, 1, 1), new DateTime(1975, 12, 31),
                                                                 delta, transitionRuleStart, transitionRuleEnd);
      adjustmentList.Add(adjustment);
      // Define rule 7 (1976-1986)
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 04, 05, DayOfWeek.Sunday);
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(1976, 1, 1), new DateTime(1986, 12, 31),
                                                                 delta, transitionRuleStart, transitionRuleEnd);
      adjustmentList.Add(adjustment);
      // Define rule 8 (1987-2006)
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 04, 01, DayOfWeek.Sunday);
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(1987, 1, 1), new DateTime(2006, 12, 31),
                                                                 delta, transitionRuleStart, transitionRuleEnd);
      adjustmentList.Add(adjustment);
      // Define rule 9 (2007- )
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 03, 02, DayOfWeek.Sunday);
      transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 11, 01, DayOfWeek.Sunday);
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(2007, 1, 1), DateTime.MaxValue.Date,
                                                                 delta, transitionRuleStart, transitionRuleEnd);
      adjustmentList.Add(adjustment);

      // Convert list of adjustment rules to an array
      TimeZoneInfo.AdjustmentRule[] adjustments = new TimeZoneInfo.AdjustmentRule[adjustmentList.Count];
      adjustmentList.CopyTo(adjustments);

      cst = TimeZoneInfo.CreateCustomTimeZone("Central Standard Time", new TimeSpan(-6, 0, 0),
            "(GMT-06:00) Central Time (US Only)", "Central Standard Time",
            "Central Daylight Time", adjustments);
      // </Snippet5>
      return cst;
   }
}
