Imports System

Namespace ca1003

    Public Class CustomEventArgs
        Inherits EventArgs

        Public info As String = "data"

    End Class

    Public Class ClassThatRaisesEvent

        ' This statement creates a new delegate, which violates the rule.
        Event SomeEvent(sender As Object, e As CustomEventArgs)

        ' To satisfy the rule, comment out the previous line 
        ' and uncomment the following line.
        'Event SomeEvent As EventHandler(Of CustomEventArgs)

        Protected Overridable Sub OnSomeEvent(e As CustomEventArgs)
            RaiseEvent SomeEvent(Me, e)
        End Sub

        Sub SimulateEvent()
            OnSomeEvent(New CustomEventArgs())
        End Sub

    End Class

    Public Class ClassThatHandlesEvent

        Sub New(eventRaiser As ClassThatRaisesEvent)
            AddHandler eventRaiser.SomeEvent, AddressOf HandleEvent
        End Sub

        Private Sub HandleEvent(sender As Object, e As CustomEventArgs)
            Console.WriteLine("Event handled: {0}", e.info)
        End Sub

    End Class

    Class Test

        Shared Sub Main1003()

            Dim eventRaiser As New ClassThatRaisesEvent()
            Dim eventHandler As New ClassThatHandlesEvent(eventRaiser)

            eventRaiser.SimulateEvent()

        End Sub

    End Class

End Namespace
