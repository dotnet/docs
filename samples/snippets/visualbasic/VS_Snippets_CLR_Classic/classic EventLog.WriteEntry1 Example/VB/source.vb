' <Snippet1>
Option Strict
Option Explicit

Imports System
Imports System.Diagnostics
Imports System.Threading

Class MySample
    Public Shared Sub Main()
        ' Create the source, if it does not already exist.
        If Not EventLog.SourceExists("MySource") Then
            EventLog.CreateEventSource("MySource", "myNewLog")
            Console.WriteLine("CreatingEventSource")
        End If
        
        
        ' Write an informational entry to the event log.    
        EventLog.WriteEntry("MySource", "Writing to event log.")
    End Sub ' Main 
End Class ' MySample 
' </Snippet1>