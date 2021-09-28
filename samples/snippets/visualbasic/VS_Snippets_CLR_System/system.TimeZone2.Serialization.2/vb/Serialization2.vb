' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections.Generic

Public Class TimeZoneApplication
    ' Define collection of custom time zones
    Private customTimeZones As New Dictionary(Of String, String)
    Private cst As TimeZoneInfo

    Public Sub New()
        ' Define custom Central Standard Time
        '
        ' Declare necessary TimeZoneInfo.AdjustmentRule objects for time zone
        Dim customTimeZone As TimeZoneInfo
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
        ' Create custom time zone
        customTimeZone = TimeZoneInfo.CreateCustomTimeZone("Central Standard Time", _
                        New TimeSpan(-6, 0, 0), _
                        "(GMT-06:00) Central Time (US Only)", "Central Standard Time", _
                        "Central Daylight Time", adjustmentList.ToArray())
        ' Add time zone to collection
        customTimeZones.Add(customTimeZone.Id, customTimeZone.ToSerializedString())

        ' Create any other required time zones     
    End Sub

    Public Shared Sub Main()
        Dim tza As New TimeZoneApplication()
        tza.AppEntryPoint()
    End Sub

    Private Sub AppEntryPoint()
        Try
            cst = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time")
        Catch e As TimeZoneNotFoundException
            If customTimeZones.ContainsKey("Central Standard Time")
                HandleTimeZoneException("Central Standard Time")
            End If
        Catch e As InvalidTimeZoneException
            If customTimeZones.ContainsKey("Central Standard Time")
                HandleTimeZoneException("Central Standard Time")
            End If
        End Try
        If cst Is Nothing Then
            Console.WriteLine("Unable to load Central Standard Time zone.")
            Return
        End If
        Dim currentTime As Date = Date.Now
        Console.WriteLine("The current {0} time is {1}.", _
                          IIf(TimeZoneInfo.Local.IsDaylightSavingTime(currentTime), _
                              TimeZoneInfo.Local.StandardName, _
                              TimeZoneInfo.Local.DaylightName), _
                          currentTime.ToString("f"))
        Console.WriteLine("The current {0} time is {1}.", _
                          IIf(cst.IsDaylightSavingTime(currentTime), _
                              cst.StandardName, _
                              cst.DaylightName), _
                          TimeZoneInfo.ConvertTime(currentTime, TimeZoneInfo.Local, cst).ToString("f"))
    End Sub

    Private Sub HandleTimeZoneException(timeZoneName As String)
        Dim tzString As String = customTimeZones.Item(timeZoneName)
        cst = TimeZoneInfo.FromSerializedString(tzString)
    End Sub
End Class
' </Snippet1>
