' <Snippet1>
Option Strict
Option Explicit

Imports System
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Class MySample
    Public Shared Sub Main()
        
        Dim myLog As New EventLog()
        myLog.Log = "MyNewLog"
        Dim entry As EventLogEntry
        For Each entry In  myLog.Entries
            Console.WriteLine((ControlChars.Tab & "Entry: " & entry.Message))
        Next entry
    End Sub ' Main
End Class ' MySample
' </Snippet1>