' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
    Public Sub Main()
        Dim duration As New TimeSpan(1, 12, 23, 62)

        Dim output As String = Nothing
        output = "Time of Travel: " + duration.ToString("%d") + " days"
        Console.WriteLine(output)
        output = "Time of Travel: " + duration.ToString("dd\.hh\:mm\:ss")
        Console.WriteLine(output)

        Console.WriteLine("Time of Travel: {0:%d} day(s)", duration)
        Console.WriteLine("Time of Travel: {0:dd\.hh\:mm\:ss} days", duration)
    End Sub
End Module
' The example displays the following output:
'       Time of Travel: 1 days
'       Time of Travel: 01.12:24:02
'       Time of Travel: 1 day(s)
'       Time of Travel: 01.12:24:02 days
' </Snippet1>
