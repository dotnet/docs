      ' Declare necessary TimeZoneInfo.AdjustmentRule objects for time zone
      Dim imaginaryTZ As TimeZoneInfo
      Dim delta As New TimeSpan(1, 0, 0)
      Dim adjustment As TimeZoneInfo.AdjustmentRule
      Dim adjustmentList As New List(Of TimeZoneInfo.AdjustmentRule)
      ' Declare transition time variables to hold transition time information
      Dim transitionRuleStart, transitionRuleEnd As TimeZoneInfo.TransitionTime
                            
      ' Define a fictitious new time zone consisting of fixed and floating adjustment rules 
      ' Define fixed rule (for 1900-1955)
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFixedDateRule(#2:00:00AM#, 3, 15)
      transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFixedDateRule(#3:00:00AM#, 11, 15)
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(#1/1/1900#, #12/31/1955#, delta, _
                   transitionRuleStart, transitionRuleEnd)
      adjustmentList.Add(adjustment)
      ' Define floating rule (for 1956- )
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#02:00:00AM#, 3, 5, DayOfWeek.Sunday)
      transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#03:00:00AM#, 10, 4, DayOfWeek.Sunday) 
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(#01/01/1956#, Date.MaxValue.Date, delta, transitionRuleStart, transitionRuleEnd)
      adjustmentList.Add(adjustment) 

      ' Create fictitious time zone   
      imaginaryTZ = TimeZoneInfo.CreateCustomTimeZone("Fictitious Standard Time", New TimeSpan(-9, 0, 0), _
                      "(GMT-09:00) Fictitious Time", "Fictitious Standard Time", _
                      "Fictitious Daylight Time", adjustmentList.ToArray())