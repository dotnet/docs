' Visual Basic .NET Document
Option Strict On

Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Globalization

<Assembly: CLSCompliant(True)>
Module modMain

   Public Sub Main()
      Console.WriteLine("***CompareForEquality()")
      CompareForEquality()
      Console.WriteLine()
      Console.WriteLine("***CompareTransitionTimesForEquality()")
      CompareTransitionTimesForEquality()
      Console.WriteLine()
      Console.WriteLine("***CreateTransitionRules()")
      CreateTransitionRules()
      Console.WriteLine()
      Console.WriteLine("***GetFixedTransitionTimes()")
      GetFixedTransitionTimes()
      Console.WriteLine()
      Console.WriteLine("***GetFloatingTransitionTimes()")
      GetFloatingTransitionTimes()
      Console.WriteLine()
      Console.WriteLine("***GetTransitionTimes(2006)")
      GetTransitionTimes(2006)
      Dim ae As New AdditionalExamples()
      Console.WriteLine()
      Console.WriteLine("***GetAllTransitionTimes()")
      ae.GetAllTransitionTimes()
   End Sub
   
   Private Sub CompareForEquality()
      ' <Snippet1>
      Dim tt1 As TimeZoneInfo.TransitionTime = TimeZoneInfo.TransitionTime.CreateFixedDateRule(#02:00:00AM#, 11, 03)
      Dim tt2 As TimeZoneInfo.TransitionTime = TimeZoneInfo.TransitionTime.CreateFixedDateRule(#02:00:00AM#, 11, 03)
      Dim tt3 As TimeZoneInfo.TransitionTime = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#02:00:00AM#, 10, 05, DayOfWeek.Sunday)
      Dim tz As TimeZoneInfo = TimeZoneInfo.Local
      Console.WriteLine(tt1.Equals(tz))          ' Returns False (overload with argument of type Object)
      Console.WriteLine(tt1.Equals(tt1))         ' Returns True (an object always equals itself)
      Console.WriteLine(tt1.Equals(tt2))         ' Returns True (identical property values)
      Console.WriteLine(tt1.Equals(tt3))         ' Returns False (different property values)
      ' </Snippet1>
   End Sub
   
   Private Sub CreateTransitionRules()
      ' <Snippet2>
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
      ' </Snippet2>                   
   End Sub
   
   ' <Snippet3>
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
   ' </Snippet3>
   
   ' <Snippet4>
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
   ' </Snippet4>
   
   Private Sub GetTransitionTimes(year As Integer)
      ' Get and iterate time zones on local computer
      Dim timeZones As ReadOnlyCollection(Of TimeZoneInfo) = TimeZoneInfo.GetSystemTimeZones()
      For Each timeZone As TimeZoneInfo In timeZones
         Console.WriteLine("{0}:", timeZone.StandardName)
         Dim adjustments() As TimeZoneInfo.AdjustmentRule = timeZone.GetAdjustmentRules()
         If adjustments.Length = 0 Then
            Console.WriteLine("   No adjustment rules.")
         Else   
            ' Iterate adjustment rules for time zone
            For Each adjustment As TimeZoneInfo.AdjustmentRule In adjustments
               ' Determine if this adjustment rule covers year desired
               If adjustment.DateStart.Year <= year And adjustment.DateEnd.Year >= year Then
                  Dim startTransition, endTransition As TimeZoneInfo.TransitionTime
                  ' Determine if starting transition is fixed 
                  startTransition = adjustment.DaylightTransitionStart
                  ' Determine if starting transition is fixed and display transition info for year
                  If startTransition.IsFixedDateRule Then
                     Console.WriteLine("   Begins on {0} {1} at {2:t}", _
                                       MonthName(startTransition.Month), _
                                       startTransition.Day, _
                                       startTransition.TimeOfDay)
                  Else
                     DisplayTransitionInfo(startTransition, year, "Begins on")
                  End If    
                  ' Determine if ending transition is fixed and display transition info for year
                  endTransition = adjustment.DaylightTransitionEnd
                  If endTransition.IsFixedDateRule Then
                     Console.WriteLine("   Ends on {0} {1} at {2:t}", _
                                       MonthName(endTransition.Month), _
                                       endTransition.Day, _
                                       endTransition.TimeOfDay)
                  Else
                     DisplayTransitionInfo(endTransition, year, "Ends on")
                  End If    
                     
                  Exit For
               End If
            Next
         End If   
      Next 
   End Sub
   
   Private Sub DisplayTransitionInfo(transition As TimeZoneInfo.TransitionTime, year As Integer, label As String)
      ' For non-fixed date rules, get local calendar
      Static cal As Calendar = CultureInfo.CurrentCulture.Calendar

      ' Get first day of week for transition
      ' For example, the 3rd week starts no earlier than the 15th of the month
      Dim startOfWeek As Integer = transition.Week * 7 - 6
      ' What day of the week does the month start on?
      Dim firstDayOfWeek As Integer = cal.GetDayOfWeek(New Date(year, transition.Month, startOfWeek)) 
      ' Determine how much start date has to be adjusted
      Dim transitionDay As Integer 
      Dim changeDayOfWeek As Integer = transition.DayOfWeek

      If firstDayOfWeek <= changeDayOfWeek Then
         transitionDay = startOfWeek + (changeDayOfWeek - firstDayOfWeek)
      Else     
         transitionDay = startOfWeek + (7 - firstDayOfWeek + changeDayOfWeek)
      End If
      ' Adjust for months with no fifth week
      If transitionDay > cal.GetDaysInMonth(year, transition.Month) Then  
         transitionDay -= 7
      End If
      Console.WriteLine("   {0} {1}, {2:d} at {3:t}", _
                        label, _
                        transition.DayOfWeek, _
                        New DateTime(year, transition.Month, transitionDay), _
                        transition.TimeOfDay)   
   End Sub   

   Private Sub CompareTransitionTimesForEquality()
      ' <Snippet7>
      Dim tt1 As TimeZoneInfo.TransitionTime = TimeZoneInfo.TransitionTime.CreateFixedDateRule(#02:00:00AM#, 11, 03)
      Dim tt2 As TimeZoneInfo.TransitionTime = TimeZoneInfo.TransitionTime.CreateFixedDateRule(#02:00:00AM#, 11, 03)
      Dim tt3 As TimeZoneInfo.TransitionTime = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#02:00:00AM#, 10, 05, DayOfWeek.Sunday)
      Console.WriteLine(tt1.Equals(tt1))         ' Returns True (an object always equals itself)
      Console.WriteLine(tt1.Equals(tt2))         ' Returns True (identical property values)
      Console.WriteLine(tt1.Equals(tt3))         ' Returns False (different property values)
      ' </Snippet7>
   End Sub
End Module

Public Class AdditionalExamples
   ' <Snippet6>
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
   ' </Snippet6>
End Class

