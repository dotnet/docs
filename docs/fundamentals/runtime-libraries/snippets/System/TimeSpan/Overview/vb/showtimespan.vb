' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example4
    Public Sub Main()
        Dim interval As TimeSpan = Date.Now - Date.Now.Date
        Dim msg As String = String.Format("Elapsed Time Today: {0:d} hours.",
                                         interval)
        Console.WriteLine(msg)
    End Sub
End Module
' The example displays output like the following:
'       Elapsed Time Today: 01:40:52.2524662 hours.
' </Snippet2>
