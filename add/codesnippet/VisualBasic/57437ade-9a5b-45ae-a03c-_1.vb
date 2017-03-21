      ' Create alternate Central Standard Time to include historical time zone information
      '
      ' Declare necessary TimeZoneInfo.AdjustmentRule objects for time zone
      Dim delta As New TimeSpan(1, 0, 0)
      Dim adjustment As TimeZoneInfo.AdjustmentRule
      Dim adjustmentList As New List(Of TimeZoneInfo.AdjustmentRule)
      ' Declare transition time variables to hold transition time information
      Dim transitionRuleStart, transitionRuleEnd As TimeZoneInfo.TransitionTime

      ' Define end rule (for 1976-2006)
      transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#02:00:00AM#, 10, 5, DayOfWeek.Sunday)
      ' Define rule (1976-1986)
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#2:00:00AM#, 04, 05, DayOfWeek.Sunday)
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(#01/01/1976#, #12/31/1986#, delta, transitionRuleStart, transitionRuleEnd)
      adjustmentList.Add(adjustment)
      ' Define rule (1987-2006)  
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#2:00:00AM#, 04, 01, DayOfWeek.Sunday)
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(#01/01/1987#, #12/31/2006#, delta, transitionRuleStart, transitionRuleEnd)
      adjustmentList.Add(adjustment)
      ' Define rule (2007- )  
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#2:00:00AM#, 03, 02, DayOfWeek.Sunday)
      transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#2:00:00AM#, 11, 01, DayOfWeek.Sunday)
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(#01/01/2007#, Date.MaxValue.Date, delta, transitionRuleStart, transitionRuleEnd)
      adjustmentList.Add(adjustment)
                    
      ' Create custom U.S. Central Standard Time Zone
      TimeZoneInfo.CreateCustomTimeZone("Central Standard Time", New TimeSpan(-6, 0, 0), _
                      "(GMT-06:00) Central Time (US Only)", "Central Standard Time", _
                      "Central Daylight Time", adjustmentList.ToArray())     