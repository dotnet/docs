
Imports System

' Code section for remarks
Namespace EventRemarks
    Public Class AlarmEventArgs
        Inherits EventArgs
    End Class
    ' <Snippet2>
    Public Delegate Sub AlarmEventHandler(sender As Object, e As AlarmEventArgs)
    ' </Snippet2>

    Public Class AlarmClock
        Public Event Alarm As AlarmEventHandler
    End Class

    ' <Snippet4>
    Delegate Sub EventHandler(sender As Object, e As EventArgs)
    ' </Snippet4>
    ' <Snippet3>
    Public Class WakeMeUp
        ' AlarmRang has the same signature as AlarmEventHandler.
        Public Sub AlarmRang(sender As Object, e As AlarmEventArgs)
            '...
        End Sub
        '...
    End Class
    ' </Snippet3>

    Public Class AlarmDriver
        Public Shared Sub Main()
            ' <Snippet5>
            ' Create an instance of WakeMeUp.
            Dim w As New WakeMeUp()

            ' Instantiate the event delegate.
            Dim alhandler As AlarmEventHandler = AddressOf w.AlarmRang
            ' </Snippet5>

            ' <Snippet6>
            ' Instantiate the event source.
            Dim clock As New AlarmClock()

            ' Add the delegate instance to the event.
            AddHandler clock.Alarm, alhandler
            ' </Snippet6>
      End Sub
   End Class
End Namespace