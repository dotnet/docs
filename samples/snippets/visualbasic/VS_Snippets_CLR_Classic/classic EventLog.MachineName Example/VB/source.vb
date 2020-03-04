' <Snippet1>
Imports System.Diagnostics

Class MySample
    Public Shared Sub Main()
        Dim myNewLog As New EventLog()
        myNewLog.Log = "NewEventLog"
        myNewLog.MachineName = "MyServer"
        Dim entry As EventLogEntry
        For Each entry In  myNewLog.Entries
            Console.WriteLine((ControlChars.Tab & "Entry: " & entry.Message))
        Next entry
    End Sub
End Class
' </Snippet1>
