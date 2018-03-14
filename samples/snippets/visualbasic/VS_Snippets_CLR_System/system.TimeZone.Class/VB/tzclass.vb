'<Snippet1>
' Example of selected TimeZone class elements.
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Module TimeZoneDemo

    Sub Main( )

        Const dataFmt As String = "{0,-30}{1}"
        Const timeFmt As String = "{0,-30}{1:yyyy-MM-dd HH:mm}"

        Console.WriteLine( "This example of selected " & _
            "TimeZone class elements generates the following " & _
            vbCrLf & "output, which varies depending on the " & _
            "time zone in which it is run." & vbCrLf )

        ' Get the local time zone and the current local time and year.
        Dim localZone As TimeZone = TimeZone.CurrentTimeZone
        Dim currentDate As DateTime = DateTime.Now
        Dim currentYear As Integer = currentDate.Year

        ' Display the names for standard time and daylight saving 
        ' time for the local time zone.
        Console.WriteLine( dataFmt, "Standard time name:", _
            localZone.StandardName )
        Console.WriteLine( dataFmt, "Daylight saving time name:", _
            localZone.DaylightName )

        ' Display the current date and time and show if they occur 
        ' in daylight saving time.
        Console.WriteLine( vbCrLf & timeFmt, _
            "Current date and time:", currentDate )
        Console.WriteLine( dataFmt, "Daylight saving time?", _
            localZone.IsDaylightSavingTime( currentDate ) )

        ' Get the current Coordinated Universal Time (UTC) and UTC 
        ' offset.
        Dim currentUTC As DateTime = _
            localZone.ToUniversalTime( currentDate )
        Dim currentOffset As TimeSpan = _
            localZone.GetUtcOffset( currentDate )

        Console.WriteLine( timeFmt, "Coordinated Universal Time:", _
            currentUTC )
        Console.WriteLine( dataFmt, "UTC offset:", currentOffset )

        ' Get the DaylightTime object for the current year.
        Dim daylight As DaylightTime = _
            localZone.GetDaylightChanges( currentYear )

        ' Display the daylight saving time range for the current year.
        Console.WriteLine( vbCrLf & _
            "Daylight saving time for year {0}:", currentYear )
        Console.WriteLine( "{0:yyyy-MM-dd HH:mm} to " & _
            "{1:yyyy-MM-dd HH:mm}, delta: {2}", _
            daylight.Start, daylight.End, daylight.Delta )
    End Sub 
End Module 

'This example of selected TimeZone class elements generates the following
'output, which varies depending on the time zone in which it is run.
'
'Standard time name:           Pacific Standard Time
'Daylight saving time name:    Pacific Daylight Time
'
'Current date and time:        2006-01-06 16:47
'Daylight saving time?         False
'Coordinated Universal Time:   2006-01-07 00:47
'UTC offset:                   -08:00:00
'
'Daylight saving time for year 2006:
'2006-04-02 02:00 to 2006-10-29 02:00, delta: 01:00:00
'</Snippet1>