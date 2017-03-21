   Private Enum WeekOfMonth As Integer
      First = 1
      Second = 2
      Third = 3
      Fourth = 4
      Last = 5 
   End Enum
   
   Private Sub GetFloatingTransitionTimes()
      Dim timeZones As ReadOnlyCollection(Of TimeZoneInfo) = TimeZoneInfo.GetSystemTimeZones()
      For Each zone As TimeZoneInfo In timeZones
         Dim adjustmentRules() As TimeZoneInfo.AdjustmentRule = zone.GetAdjustmentRules()
         For Each adjustmentRule As TimeZoneInfo.AdjustmentRule in adjustmentRules
            Dim daylightStart As TimeZoneInfo.TransitionTime = adjustmentRule.DaylightTransitionStart
            If Not daylightStart.IsFixedDateRule Then
               Console.WriteLine("{0}, {1:d}-{2:d}: Begins at {3:t} on the {4} {5} of {6}.", _
                                 zone.StandardName, _
                                 adjustmentRule.DateStart, _
                                 adjustmentRule.DateEnd, _                                 
                                 daylightStart.TimeOfDay, _
                                 CType(daylightStart.Week, WeekOfMonth).ToString(), _ 
                                 daylightStart.DayOfWeek.ToString(), _
                                 MonthName(daylightStart.Month))
            End If
            Dim daylightEnd As TimeZoneInfo.TransitionTime = adjustmentRule.DaylightTransitionEnd
            If Not daylightEnd.IsFixedDateRule Then
               Console.WriteLine("{0}, {1:d}-{2:d}: Ends at {3:t} on the {4} {5} of {6}.", _
                                 zone.StandardName, _
                                 adjustmentRule.DateStart, _
                                 adjustmentRule.DateEnd, _                                 
                                 daylightEnd.TimeOfDay, _
                                 CType(daylightEnd.Week, WeekOfMonth).ToString(), _ 
                                 daylightEnd.DayOfWeek.ToString(), _
                                 MonthName(daylightEnd.Month))
            End If   
         Next
      Next   
   End Sub