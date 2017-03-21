   Private Enum WeekOfMonth As Integer
      First = 1
      Second = 2
      Third = 3
      Fourth = 4
      Last = 5 
   End Enum
   
   Sub GetAllTransitionTimes()
      Dim timeZones As ReadOnlyCollection(Of TimeZoneInfo) = TimeZoneInfo.GetSystemTimeZones()
      For Each zone As TimeZoneInfo In timeZones
         Console.WriteLine("{0} transition time information:", zone.StandardName)
         Dim adjustmentRules() As TimeZoneInfo.AdjustmentRule = zone.GetAdjustmentRules()
         
         ' Indicate that time zone has no adjustment rules
         If adjustmentRules.Length = 0 Then 
            Console.WriteLine("   No adjustment rules defined.")
         Else
            ' Iterate adjustment rules       
            For Each adjustmentRule As TimeZoneInfo.AdjustmentRule in adjustmentRules
               Console.WriteLine("   Adjustment rule from {0:d} to {1:d}:", _
                                 adjustmentRule.DateStart, _
                                 adjustmentRule.DateEnd)                                 
               
               ' Get start of transition
               Dim daylightStart As TimeZoneInfo.TransitionTime = adjustmentRule.DaylightTransitionStart
               ' Display information on fixed date rule
               If Not daylightStart.IsFixedDateRule Then
                  Console.WriteLine("      Begins at {0:t} on the {1} {2} of {3}.", _
                                 daylightStart.TimeOfDay, _
                                 CType(daylightStart.Week, WeekOfMonth).ToString(), _ 
                                 daylightStart.DayOfWeek.ToString(), _
                                 MonthName(daylightStart.Month))
               ' Display information on floating date rule 
               Else
                  Console.WriteLine("      Begins at {0:t} on the {1} {2} of {3}.", _
                                    daylightStart.TimeOfDay, _
                                    CType(daylightStart.Week, WeekOfMonth).ToString(), _ 
                                    daylightStart.DayOfWeek.ToString(), _
                                    MonthName(daylightStart.Month))
               End If
               
               ' Get end of transition
               Dim daylightEnd As TimeZoneInfo.TransitionTime = adjustmentRule.DaylightTransitionEnd
               ' Display information on fixed date rule
               If Not daylightEnd.IsFixedDateRule Then
                  Console.WriteLine("      Ends at {0:t} on the {1} {2} of {3}.", _
                                 daylightEnd.TimeOfDay, _
                                 CType(daylightEnd.Week, WeekOfMonth).ToString(), _ 
                                 daylightEnd.DayOfWeek.ToString(), _
                                 MonthName(daylightEnd.Month))
               ' Display information on floating date rule
               Else
                  Console.WriteLine("      Ends at {0:t} on the {1} {2} of {3}.", _
                                    daylightStart.TimeOfDay, _
                                    CType(daylightStart.Week, WeekOfMonth).ToString(), _ 
                                    daylightStart.DayOfWeek.ToString(), _
                                    MonthName(daylightStart.Month))
               End If                     
            Next
         End If   
      Next   
   End Sub