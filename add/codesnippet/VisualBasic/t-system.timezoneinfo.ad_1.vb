   Private Enum WeekOfMonth As Integer
      First = 1
      Second = 2
      Third = 3
      Fourth = 4
      Last = 5
   End Enum
   
   Private Sub ShowStartAndEndDates()
      ' Get all time zones from system
      Dim timeZones As ReadOnlyCollection(Of TimeZoneInfo) = TimeZoneInfo.GetSystemTimeZones()
      ' Get each time zone
      For Each timeZone As TimeZoneInfo In timeZones
         Dim adjustments() As TimeZoneInfo.AdjustmentRule = timeZone.GetAdjustmentRules()
         ' Display message for time zones with no adjustments
         If adjustments.Length = 0 Then
            Console.WriteLine("{0} has no adjustment rules", timeZone.StandardName)
         Else
            ' Handle time zones with 1 or 2+ adjustments differently
            Dim showCount As Boolean = False
            Dim ctr As Integer = 0
            Dim spacer As String = ""
            
            Console.WriteLine("{0} Adjustment rules", timeZone.StandardName)
            If adjustments.Length > 1 Then showCount = True : spacer = "   "  
            ' Iterate adjustment rules
            For Each adjustment As TimeZoneInfo.AdjustmentRule in adjustments
               If showCount Then 
                  Console.WriteLine("   Adjustment rule #{0}", ctr+1)
                  ctr += 1
               End If
               ' Display general adjustment information
               Console.WriteLine("{0}   Start Date: {1:D}", spacer, adjustment.DateStart)
               Console.WriteLine("{0}   End Date: {1:D}", spacer, adjustment.DateEnd)
               Console.WriteLine("{0}   Time Change: {1}:{2:00} hours", spacer, _
                                 adjustment.DaylightDelta.Hours, adjustment.DaylightDelta.Minutes)
               ' Get transition start information
               Dim transitionStart As TimeZoneInfo.TransitionTime = adjustment.DaylightTransitionStart
               Console.Write("{0}   Annual Start: ", spacer)
               If transitionStart.IsFixedDateRule Then
                  Console.WriteLine("On {0} {1} at {2:t}", _
                                    MonthName(transitionStart.Month), _
                                    transitionStart.Day, _
                                    transitionStart.TimeOfDay)
               Else
                  Console.WriteLine("The {0} {1} of {2} at {3:t}", _
                                    CType(transitionStart.Week, WeekOfMonth).ToString(), _
                                    transitionStart.DayOfWeek.ToString(), _
                                    MonthName(transitionStart.Month), _
                                    transitionStart.TimeOfDay)
               End If
               ' Get transition end information
               Dim transitionEnd As TimeZoneInfo.TransitionTime = adjustment.DaylightTransitionEnd
                                 
               Console.Write("{0}   Annual End: ", spacer)
               If transitionEnd.IsFixedDateRule Then
                  Console.WriteLine("On {0} {1} at {2:t}", _
                                    MonthName(transitionEnd.Month), _
                                    transitionEnd.Day, _
                                    transitionEnd.TimeOfDay)
               Else
                  Console.WriteLine("The {0} {1} of {2} at {3:t}", _
                                    CType(transitionEnd.Week, WeekOfMonth).ToString(), _
                                    transitionEnd.DayOfWeek.ToString(), _
                                    MonthName(transitionEnd.Month), _
                                    transitionEnd.TimeOfDay)
               End If
            Next
         End If   
         Console.WriteLine()
      Next 
   End Sub