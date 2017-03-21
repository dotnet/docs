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
      Console.WriteLine("{0} supports DST: {1}", palmer.StandardName, palmer.SupportsDaylightSavingTime);