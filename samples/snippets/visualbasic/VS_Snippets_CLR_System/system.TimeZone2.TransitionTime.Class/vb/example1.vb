' Visual Basic .NET Document
Option Strict On

Imports System.Collections.ObjectModel
Imports System.Globalization

Module Example
   Public Sub Main()
      GetTransitionTimes(2007)
   End Sub
   
   ' <Snippet5>
   Private Sub GetTransitionTimes(year As Integer)
      ' Get and iterate time zones on local computer
      Dim timeZones As ReadOnlyCollection(Of TimeZoneInfo) = TimeZoneInfo.GetSystemTimeZones()
      For Each timeZone As TimeZoneInfo In timeZones
         Console.WriteLine("{0}:", timeZone.StandardName)
         Dim adjustments() As TimeZoneInfo.AdjustmentRule = timeZone.GetAdjustmentRules()
         Dim startYear As Integer = year
         Dim endYear As Integer = startYear

         If adjustments.Length = 0 Then
            Console.WriteLine("   No adjustment rules.")
         Else   
            Dim adjustment As TimeZoneInfo.AdjustmentRule = GetAdjustment(adjustments, year)
            If adjustment Is Nothing Then
               Console.WriteLine("   No adjustment rules available for this year.")
               Continue For
            End If
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
               DisplayTransitionInfo(startTransition, startYear, "Begins on")
            End If    

            ' Determine if ending transition is fixed and display transition info for year
            endTransition = adjustment.DaylightTransitionEnd
                   
            ' Does the transition back occur in an earlier month (i.e., 
            ' the following year) than the transition to DST? If so, make
            ' sure we have the right adjustment rule.
            If endTransition.Month < startTransition.Month Then
               endTransition = GetAdjustment(adjustments, year + 1).DaylightTransitionEnd
               endYear += 1
            End If

            If endTransition.IsFixedDateRule Then
               Console.WriteLine("   Ends on {0} {1} at {2:t}", _
                                 MonthName(endTransition.Month), _
                                 endTransition.Day, _
                                 endTransition.TimeOfDay)
            Else
               DisplayTransitionInfo(endTransition, endYear, "Ends on")
            End If    
         End If   
      Next 
   End Sub

   Private Function GetAdjustment(adjustments As TimeZoneInfo.AdjustmentRule(), _
                                  year As Integer) As TimeZoneInfo.AdjustmentRule
      ' Iterate adjustment rules for time zone
      For Each adjustment As TimeZoneInfo.AdjustmentRule In adjustments
         ' Determine if this adjustment rule covers year desired
         If adjustment.DateStart.Year <= year And adjustment.DateEnd.Year >= year Then
            Return adjustment
         End If
      Next   
      Return Nothing
   End Function
      
   Private Sub DisplayTransitionInfo(transition As TimeZoneInfo.TransitionTime, year As Integer, label As String)
      ' For non-fixed date rules, get local calendar
      Static cal As Calendar = CultureInfo.CurrentCulture.Calendar
   
      ' Get first day of week for transition
      ' For example, the 3rd week starts no earlier than the 15th of the month
      Dim startOfWeek As Integer = transition.Week * 7 - 6
      ' What day of the week does the month start on?
      Dim firstDayOfWeek As Integer = cal.GetDayOfWeek(New Date(year, transition.Month, 1))
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
   ' </Snippet5>
End Module

