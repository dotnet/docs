   Private Sub GetFixedTransitionTimes()
      Dim timeZones As ReadOnlyCollection(Of TimeZoneInfo) = TimeZoneInfo.GetSystemTimeZones()
      For Each zone As TimeZoneInfo In timeZones
         Dim adjustmentRules() As TimeZoneInfo.AdjustmentRule = zone.GetAdjustmentRules()
         For Each adjustmentRule As TimeZoneInfo.AdjustmentRule in adjustmentRules
            Dim daylightStart As TimeZoneInfo.TransitionTime = adjustmentRule.DaylightTransitionStart
            If daylightStart.IsFixedDateRule Then
               Console.WriteLine("For {0}, daylight savings time begins at {1:t} on {2} {3} from {4:d} to {5:d}.", _
                                 zone.StandardName, _
                                 daylightStart.TimeOfDay, _ 
                                 MonthName(daylightStart.Month), _
                                 daylightStart.Day, _
                                 adjustmentRule.DateStart, _
                                 adjustmentRule.DateEnd)
            End If
            Dim daylightEnd As TimeZoneInfo.TransitionTime = adjustmentRule.DaylightTransitionEnd
            If daylightEnd.IsFixedDateRule Then
               Console.WriteLine("For {0}, daylight savings time ends at {1:t} on {2} {3} from {4:d} to {5:d}.", _
                                 zone.StandardName, _
                                 daylightEnd.TimeOfDay, _ 
                                 MonthName(daylightEnd.Month), _
                                 daylightEnd.Day, _
                                 adjustmentRule.DateStart, _
                                 adjustmentRule.DateEnd)
            End If   
         Next
      Next   
   End Sub