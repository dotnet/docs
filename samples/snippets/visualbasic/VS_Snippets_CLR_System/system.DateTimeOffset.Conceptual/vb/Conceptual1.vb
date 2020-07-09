' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections.ObjectModel

Module TimeOffsets
    Public Sub Main()
        Dim thisTime As DateTimeOffset

        thisTime = New DateTimeOffset(#06/10/2007#, New TimeSpan(-7, 0, 0))
        ShowPossibleTimeZones(thisTime)

        thisTime = New DateTimeOffset(#03/10/2007#, New TimeSpan(-6, 0, 0))
        ShowPossibleTimeZones(thisTime)

        thisTime = New DateTimeOffset(#03/10/2007#, New TimeSpan(+1, 0, 0))
        ShowPossibleTimeZones(thisTime)
    End Sub

    Private Sub ShowPossibleTimeZones(offsetTime As DateTimeOffset)
        Dim offset As TimeSpan = offsetTime.Offset
        Dim timeZones As ReadOnlyCollection(Of TimeZoneInfo)

        Console.WriteLine("{0} could belong to the following time zones:", _
                          offsetTime.ToString())
        ' Get all time zones defined on local system
        timeZones = TimeZoneInfo.GetSystemTimeZones()
        ' Iterate time zones
        For Each timeZone As TimeZoneInfo In timeZones
            ' Compare offset with offset for that date in that time zone
            If timeZone.GetUtcOffset(offsetTime.DateTime).Equals(offset) Then
                Console.WriteLine("   {0}", timeZone.DisplayName)
            End If
        Next
        Console.WriteLine()
    End Sub
End Module
' This example displays the following output to the console:
'       6/10/2007 12:00:00 AM -07:00 could belong to the following time zones:
'          (GMT-07:00) Arizona
'          (GMT-08:00) Pacific Time (US & Canada)
'          (GMT-08:00) Tijuana, Baja California
'       
'       3/10/2007 12:00:00 AM -06:00 could belong to the following time zones:
'          (GMT-06:00) Central America
'          (GMT-06:00) Central Time (US & Canada)
'          (GMT-06:00) Guadalajara, Mexico City, Monterrey - New
'          (GMT-06:00) Guadalajara, Mexico City, Monterrey - Old
'          (GMT-06:00) Saskatchewan
'       
'       3/10/2007 12:00:00 AM +01:00 could belong to the following time zones:
'          (GMT+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna
'          (GMT+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague
'          (GMT+01:00) Brussels, Copenhagen, Madrid, Paris
'          (GMT+01:00) Sarajevo, Skopje, Warsaw, Zagreb
'          (GMT+01:00) West Central Africa
' </Snippet1>

