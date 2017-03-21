      // Declare necessary TimeZoneInfo.AdjustmentRule objects for time zone
      TimeZoneInfo imaginaryTZ;
      TimeSpan delta = new TimeSpan(1, 0, 0);
      TimeZoneInfo.AdjustmentRule adjustment;
      List<TimeZoneInfo.AdjustmentRule> adjustmentList = new List<TimeZoneInfo.AdjustmentRule>();
      // Declare transition time variables to hold transition time information
      TimeZoneInfo.TransitionTime transitionRuleStart, transitionRuleEnd;
                            
      // Define a fictitious new time zone consisting of fixed and floating adjustment rules 
      // Define fixed rule (for 1900-1955)
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFixedDateRule(new DateTime(1, 1, 1, 2, 0, 0), 3, 15);
      transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFixedDateRule(new DateTime(1, 1, 1, 3, 0, 0), 11, 15);
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(1900, 1, 1), new DateTime(1955, 12, 31), 
                   delta, transitionRuleStart, transitionRuleEnd);
      adjustmentList.Add(adjustment);
      // Define floating rule (for 1956- )
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 3, 5, DayOfWeek.Sunday);
      transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 3, 0, 0), 10, 4, DayOfWeek.Sunday); 
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(1956, 1, 1), DateTime.MaxValue.Date, delta, transitionRuleStart, transitionRuleEnd);
      adjustmentList.Add(adjustment); 

      // Create fictitious time zone   
      imaginaryTZ = TimeZoneInfo.CreateCustomTimeZone("Fictitious Standard Time", new TimeSpan(-9, 0, 0), 
                      "(GMT-09:00) Fictitious Time", "Fictitious Standard Time", 
                      "Fictitious Daylight Time", adjustmentList.ToArray());