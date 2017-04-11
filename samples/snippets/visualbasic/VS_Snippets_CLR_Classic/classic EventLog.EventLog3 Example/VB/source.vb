' <Snippet1>
Option Strict
Option Explicit

Imports System
Imports System.Diagnostics
Imports System.Threading

Class MySample
    Public Shared Sub Main()
        If Not EventLog.SourceExists("MySource") Then
            ' Create the source, if it does not already exist.
            ' An event log source should not be created and immediately used.
            ' There is a latency time to enable the source, it should be created
            ' prior to executing the application that uses the source.
            ' Execute this sample a second time to use the new source.
            EventLog.CreateEventSource("MySource", "MyNewLog")
            Console.WriteLine("CreatingEventSource")
            'The source is created.  Exit the application to allow it to be registered.
            Return
        End If
        ' Create an EventLog instance and assign its source.
        Dim myLog As New EventLog("myNewLog", ".", "MySource")
        
        ' Write an entry to the log.        
        myLog.WriteEntry(("Writing to event log on " & myLog.MachineName))
    End Sub ' Main 
End Class ' MySample
' </Snippet1>