' <Snippet1>
Imports System
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Class MySample
    Public Shared Sub Main()
        Dim myNewLog As New EventLog()
        myNewLog.Log = "NewEventLog"
        Dim entry As EventLogEntry
        For Each entry In  myNewLog.Entries
            Console.WriteLine((ControlChars.Tab & "Entry: " & entry.Message))
        Next entry
    End Sub 'Main
End Class 'MySample
' </Snippet1>