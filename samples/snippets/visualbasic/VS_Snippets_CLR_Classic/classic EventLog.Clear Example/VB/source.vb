' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.Diagnostics
Imports System.Threading

Class MySample
    Public Shared Sub Main()
        ' Create an EventLog instance and assign its log name.
        Dim myLog As New EventLog()
        myLog.Log = "myNewLog"
        
        myLog.Clear()
    End Sub 'Main
End Class 'MySample
' </Snippet1>