' Visual Basic .NET Document
Option Strict On

' <Snippet9>
Module Example8
    Public Sub Main8()
        Dim pst As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time")
        Dim date1 As Date = DateTime.SpecifyKind(#3/9/2013 10:30AM#,
                                                 DateTimeKind.Local)
        Dim utc1 As Date = date1.ToUniversalTime()
        Dim interval As New TimeSpan(48, 0, 0)
        Dim utc2 As Date = utc1 + interval
        Dim date2 As Date = TimeZoneInfo.ConvertTimeFromUtc(utc2, pst)
        Console.WriteLine("{0:g} + {1:N1} hours = {2:g}",
                          date1, interval.TotalHours, date2)
    End Sub
End Module
' The example displays the following output:
'       3/9/2013 10:30 AM + 48.0 hours = 3/11/2013 11:30 AM
' </Snippet9>

