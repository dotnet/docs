' <Snippet1>
Option Explicit On
Option Strict On

Imports System
Imports System.Diagnostics
Imports System.Threading

Class MySample
    Public Shared Sub Main()
        Dim logName As String

        If EventLog.SourceExists("MySource", "MyMachine") Then
            ' Find the log associated with this source.    
            logName = EventLog.LogNameFromSourceName("MySource", "MyMachine")
            ' Make sure the source is in the log we believe it to be in
            If (logName <> "MyLog") Then
                Return
            End If
            ' Delete the source and the log.
            EventLog.DeleteEventSource("MySource", "MyMachine")
            EventLog.Delete(logName, "MyMachine")

            Console.WriteLine((logName & " deleted."))
        Else
            ' Create the event source to make next try successful.
            Dim mySourceData As New EventSourceCreationData("MySource", "MyLog")
            mySourceData.MachineName = "MyMachine"
            EventLog.CreateEventSource(mySourceData)
        End If
    End Sub 'Main
End Class 'MySample
' </Snippet1>