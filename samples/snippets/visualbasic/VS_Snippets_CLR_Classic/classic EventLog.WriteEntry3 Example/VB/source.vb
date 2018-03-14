' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.Diagnostics
Imports System.Threading

Class MySample
    Public Shared Sub Main()
        ' Write an informational entry to the event log.    
        EventLog.WriteEntry("MySource", "Writing warning to event log.", _
            EventLogEntryType.Warning)
    End Sub ' Main 
End Class ' MySample
' </Snippet1>