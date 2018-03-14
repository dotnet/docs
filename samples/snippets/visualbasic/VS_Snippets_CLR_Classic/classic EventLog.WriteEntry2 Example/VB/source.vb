' <Snippet1>
Option Strict
Option Explicit

Imports System
Imports System.Diagnostics
Imports System.Threading

Class MySample
    Public Shared Sub Main()
        ' Create an EventLog instance and assign its source.
        Dim myLog As New EventLog("MyNewLog")
        myLog.Source = "MyNewLogSource"
        
        ' Write an informational entry to the event log.    
        myLog.WriteEntry("Writing warning to event log.", EventLogEntryType.Warning)
    End Sub ' Main 
End Class ' MySample
' </Snippet1>