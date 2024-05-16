' Visual Basic .NET Document
Option Strict On

' <Snippet8>
Module Example7
    Public Sub Main7()
        Dim date1 As Date = DateTime.SpecifyKind(#3/9/2013 10:30AM#,
                                                 DateTimeKind.Local)
        Dim interval As New TimeSpan(48, 0, 0)
        Dim date2 As Date = date1 + interval
        Console.WriteLine("{0:g} + {1:N1} hours = {2:g}",
                          date1, interval.TotalHours, date2)
    End Sub
End Module
' The example displays the following output:
'       3/9/2013 10:30 AM + 48.0 hours = 3/11/2013 10:30 AM
' </Snippet8>
