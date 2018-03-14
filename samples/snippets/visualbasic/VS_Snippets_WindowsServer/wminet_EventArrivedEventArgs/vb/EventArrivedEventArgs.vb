'<Snippet1>
Imports System
Imports System.Management

' This example shows asynchronous consumption of events.
' In this example you are listening for timer events.
' The first part of the example sets up the timer.

Public Class EventWatcherAsync

    Public Sub New()
        ' Set up a timer to raise events every 1 second
        '=============================================
        Dim timerClass As New ManagementClass( _
            "__IntervalTimerInstruction")
        Dim timer As ManagementObject = _
            timerClass.CreateInstance()
        timer("TimerId") = "Timer1"
        timer("IntervalBetweenEvents") = 1000
        timer.Put()

        ' Set up the event consumer
        '==========================
        ' Create event query to receive timer events
        Dim query As New WqlEventQuery("__TimerEvent", _
            "TimerId=""Timer1""")

        ' Initialize an event watcher and subscribe to 
        ' events that match this query
        Dim watcher As New ManagementEventWatcher(query)

        ' Set up a listener for events
        AddHandler watcher.EventArrived, _
            AddressOf Me.HandleEvent

        ' Start listening
        watcher.Start()

        ' Do something in the meantime
        System.Threading.Thread.Sleep(10000)

        ' Stop listening
        watcher.Stop()

    End Sub

    Private Sub HandleEvent(ByVal sender As Object, _
        ByVal e As EventArrivedEventArgs)

        Console.WriteLine("Event arrived !")
    End Sub

    Public Overloads Shared Function _
            Main(ByVal args() As String) As Integer

        'start the event watcher
        Dim eventWatcher As New EventWatcherAsync

        Return 0

    End Function

End Class
'</Snippet1>