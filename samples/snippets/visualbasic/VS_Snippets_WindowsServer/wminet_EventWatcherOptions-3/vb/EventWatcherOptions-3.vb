'<Snippet1>
Imports System
Imports System.Management

' This example shows synchronous consumption of events. 
' The client is blocked while waiting for events. 

Public Class EventWatcherPolling
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        ' Create event query to be notified within 1 second of 
        ' a change in a service
        Dim query As String
        query = "SELECT * FROM" & _
            " __InstanceCreationEvent WITHIN 1 " & _
            "WHERE TargetInstance isa ""Win32_Process"""

        ' Event options
        ' blockSize = 1 to receive one event
        Dim eventOptions As New EventWatcherOptions( _
            Nothing, System.TimeSpan.MaxValue, 1)

        ' Initialize an event watcher and subscribe to events 
        ' that match this query
        Dim watcher As New ManagementEventWatcher( _
            "root\CIMV2", query, eventOptions)

        ' Block until the next event occurs 
        ' Note: this can be done in a loop
        ' if waiting for more than one occurrence
        Console.WriteLine( _
          "Open an application (notepad.exe) to trigger an event.")
        Dim e As ManagementBaseObject = _
            watcher.WaitForNextEvent()

        'Display information from the event
        Console.WriteLine( _
            "Process {0} has created, path is: {1}", _
            CType(e("TargetInstance"), _
                ManagementBaseObject)("Name"), _
            CType(e("TargetInstance"), _
                ManagementBaseObject)("ExecutablePath"))

        'Cancel the subscription
        watcher.Stop()
        Return 0

    End Function 'Main
End Class 'EventWatcherPolling
'</Snippet1>