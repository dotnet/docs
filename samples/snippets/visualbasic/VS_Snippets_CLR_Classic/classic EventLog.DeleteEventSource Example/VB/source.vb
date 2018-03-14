' <Snippet1>
Option Explicit On
Option Strict On

Imports System
Imports System.Diagnostics
Imports System.Threading

Class MySample
    Public Shared Sub Main()
        Dim logName As String

        If EventLog.SourceExists("MySource") Then
            ' Find the log associated with this source.    
            logName = EventLog.LogNameFromSourceName("MySource", ".")
            ' Make sure the source is in the log we believe it to be in
            If (logName <> "MyLog") Then
                Return
            End If
            ' Delete the source and the log.
            EventLog.DeleteEventSource("MySource")
            EventLog.Delete(logName)

            Console.WriteLine((logName & " deleted."))
        Else
            ' Create the event source to make next try successful.
            EventLog.CreateEventSource("MySource", "MyLog")
        End If
    End Sub 'Main
End Class 'MySample
' </Snippet1>