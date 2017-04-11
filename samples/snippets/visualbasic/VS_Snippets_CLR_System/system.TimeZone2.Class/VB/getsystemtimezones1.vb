' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Collections.ObjectModel
Imports System.Globalization
Imports System.IO

Module Example
   Public Sub Main()
      Const OUTPUTFILENAME As String = "C:\Temp\TimeZoneInfo.txt"
      
      Dim timeZones As ReadOnlyCollection(Of TimeZoneInfo) = TimeZoneInfo.GetSystemTimeZones() 
      Dim sw As StreamWriter = New StreamWriter(OUTPUTFILENAME, False)
      
      For Each timeZone As TimeZoneInfo in timeZones
         Dim hasDST As Boolean = timeZone.SupportsDaylightSavingTime
         Dim offsetFromUtc As TimeSpan = timeZone.BaseUtcOffset
         Dim adjustRules() As System.TimeZoneInfo.AdjustmentRule
         Dim offsetString As String
         
         sw.WriteLine("ID: {0}", timeZone.Id)
         sw.WriteLine("   Display Name: {0, 40}", timeZone.DisplayName)
         sw.WriteLine("   Standard Name: {0, 39}", timeZone.StandardName)
         sw.Write("   Daylight Name: {0, 39}", timeZone.DaylightName)
         sw.Write(iif(hasDST, "   ***Has ", "   ***Does Not Have "))
         sw.WriteLine("Daylight Saving Time***")
         offsetString = String.Format("{0} hours, {1} minutes", offsetFromUtc.Hours, offsetFromUtc.Minutes)
         sw.WriteLine("   Offset from UTC: {0, 40}", offsetString)
         adjustRules = timeZone.GetAdjustmentRules()
         sw.WriteLine("   Number of adjustment rules: {0, 26}", adjustRules.Length)  
         If adjustRules.Length > 0 Then
            sw.WriteLine("   Adjustment Rules:")
            For Each rule As TimeZoneInfo.AdjustmentRule In adjustRules
               Dim transTimeStart As TimeZoneInfo.TransitionTime = rule.DaylightTransitionStart
               Dim transTimeEnd As TimeZoneInfo.TransitionTime = rule.DaylightTransitionEnd 
               
               sw.WriteLine("      From {0} to {1}", rule.DateStart, rule.DateEnd)
               sw.WriteLine("      Delta: {0}", rule.DaylightDelta)
               If Not transTimeStart.IsFixedDateRule
                  sw.WriteLine("      Begins at {0:t} on {1} of week {2} of {3}", transTimeStart.TimeOfDay, _
                                                                                transTimeStart.DayOfWeek, _
                                                                                transTimeStart.Week, _
                                                                                MonthName(transTimeStart.Month))
                  sw.WriteLine("      Ends at {0:t} on {1} of week {2} of {3}", transTimeEnd.TimeOfDay, _
                                                                                transTimeEnd.DayOfWeek, _
                                                                                transTimeEnd.Week, _
                                                                                MonthName(transTimeEnd.Month))
               Else
                  sw.WriteLine("      Begins at {0:t} on {1} {2}", transTimeStart.TimeOfDay, _
                                                                 transTimeStart.Day, _
                                                                 MonthName(transTimeStart.Month))
                  sw.WriteLine("      Ends at {0:t} on {1} {2}", transTimeEnd.TimeOfDay, _
                                                               transTimeEnd.Day, _
                                                               MonthName(transTimeEnd.Month))
               End If
            Next
         End If            
      Next
      sw.Close()
      ' </Snippet6>
   End Sub
End Module

