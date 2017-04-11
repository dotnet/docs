' Visual Basic .NET Document
Option Strict On

Imports System.Collections.Generic
Imports System.Collections.ObjectModel

Module Example

   Public Sub Main()
      CreateCustomTimeZone()
      CompareRulesForEquality()
      ShowStartAndEndDates()
   End Sub
   
   Private Sub CreateCustomTimeZone()
   ' <Snippet1>
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
      ' </Snippet1>
   End Sub
   
   Private Sub CompareRulesForEquality()
      ' <Snippet2>
      Dim timeZoneName As String = String.Empty
      ' Get CST, Canadian CST, and Mexican CST adjustment rules
      Dim usCstAdjustments(), canCstAdjustments(), mexCstAdjustments() As TimeZoneInfo.AdjustmentRule
      Try
         timeZoneName = "Central Standard Time"
         usCstAdjustments = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName).GetAdjustmentRules
      Catch e As TimeZoneNotFoundException
         Console.WriteLine("The {0} time zone is not defined in the registry.", timeZoneName)
      Catch e As InvalidTimeZoneException
         Console.WriteLine("Data for the {0} time zone is invalid.", timeZoneName)
      End Try
      Try
         timeZoneName = "Canada Central Standard Time"
         canCstAdjustments = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName).GetAdjustmentRules
      Catch e As TimeZoneNotFoundException
         Console.WriteLine("The {0} time zone is not defined in the registry.", timeZoneName)
      Catch e As InvalidTimeZoneException
         Console.WriteLine("Data for the {0} time zone is invalid.", timeZoneName)
      End Try
      Try
         timeZoneName = "Central Standard Time (Mexico)"
         mexCstAdjustments = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName).GetAdjustmentRules
      Catch e As TimeZoneNotFoundException
         Console.WriteLine("The {0} time zone is not defined in the registry.", timeZoneName)
      Catch e As InvalidTimeZoneException
         Console.WriteLine("Data for the {0} time zone is invalid.", timeZoneName)
      End Try
      ' Determine if CST and other time zones have the same rules
      For Each rule As TimeZoneInfo.AdjustmentRule In usCstAdjustments
         Console.WriteLine("Comparing Central Standard Time rule for {0:d} to {1:d} with:", _
                           rule.DateStart, rule.DateEnd)
         ' Compare with Canada Central Standard Time
         If canCstAdjustments.Length = 0 Then
            Console.WriteLine("   Canada Central Standard Time has no adjustment rules.")
         Else
            For Each canRule As TimeZoneInfo.AdjustmentRule In canCstAdjustments
               Console.WriteLine("   Canadian CST for {0:d} to {1:d}: {2}", _
                                 canRule.DateStart, canRule.DateEnd, _
                                 IIf(rule.Equals(canRule), "Equal", "Not Equal"))
            Next              
         End If          
   
         ' Compare with Mexico Central Standard Time
         If mexCstAdjustments.Length = 0 Then
            Console.WriteLine("   Mexican Central Standard Time has no adjustment rules.")
         Else
            For Each mexRule As TimeZoneInfo.AdjustmentRule In mexCstAdjustments
               Console.WriteLine("   Mexican CST for {0:d} to {1:d}: {2}", _
                                 mexRule.DateStart, mexRule.DateEnd, _
                                 IIf(rule.Equals(mexRule), "Equal", "Not Equal"))
            Next              
         End If
      Next   
      ' This code displays the following output to the console:
      ' 
      ' Comparing Central Standard Time rule for 1/1/0001 to 12/31/9999 with:
      '    Canada Central Standard Time has no adjustment rules.
      '    Mexican CST for 1/1/0001 to 12/31/9999: Equal
      ' </Snippet2>
   End Sub

   ' <Snippet3>   
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
   ' </Snippet3>
End Module

