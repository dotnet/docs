'<snippet2>
Imports System

Class EventTester
    Public Event EventItem As EventHandler

    Public Sub OnTestEvent()
        RaiseEvent EventItem(Me, New EventArgs())
    End Sub

    Public Sub ShowEventInfo()
        ' EventItem needs the 'Event' suffix to refer to the event object.
        For Each handler As EventHandler In EventItemEvent.GetInvocationList()
            Console.WriteLine("EventHandler Method = {0}.{1}", _
                handler.Method.DeclaringType, handler.Method.Name)
        Next handler
    End Sub

    Public Sub ReverseInvocationList()
        ' Delegate is a VB keyword and need to be qualified as a type
        Dim handlers() As System.Delegate = EventItemEvent.GetInvocationList()
        If handlers.Length > 0
            ' remove the handlers first
            For Each handler As EventHandler In handlers
                RemoveHandler EventItem, handler
            Next handler
            ' reveres the order of the handlers
            Array.Reverse(handlers)
            ' now, add the handlers back
            For Each handler As EventHandler In handlers
                AddHandler EventItem, handler
            Next handler
        End If
    End Sub
End Class

Class DelegateExample
    Public Shared Sub Main()
        Dim ev As New EventTester()

        ' Add two handlers to the event
        AddHandler ev.EventItem, AddressOf Handler1
        AddHandler ev.EventItem, AddressOf Handler2

        ' Show what handlers are set to the event
        ev.ShowEventInfo()
        Console.WriteLine()
        ' Invoke the handlers
        ev.OnTestEvent()
        Console.WriteLine()
        ' Reorder the invocation list
        ev.ReverseInvocationList()
        ' Invoke the handlers again
        ev.OnTestEvent()
    End Sub

    Public Shared Sub Handler1(sender As Object, args As EventArgs)
        Console.WriteLine("This is Handler1().")
    End Sub

    Public Shared Sub Handler2(sender As Object, args As EventArgs)
        Console.WriteLine("This is Handler2().")
    End Sub
End Class

' This program will display the following output on the console:
'
' EventHandler Method = DelegateExample.Handler1
' EventHandler Method = DelegateExample.Handler2
'
' This is Handler1().
' This is Handler2().
'
' This is Handler2().
' This is Handler1().
'</snippet2>
