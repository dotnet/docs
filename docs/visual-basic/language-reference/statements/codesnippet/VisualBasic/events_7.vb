Module Module1

    Sub Main()
        Dim c1 As New Class1
        ' Associate an event handler with an event.
        AddHandler c1.AnEvent, AddressOf EventHandler1
        ' Call a method to raise the event.
        c1.CauseTheEvent()
        ' Stop handling the event.
        RemoveHandler c1.AnEvent, AddressOf EventHandler1
        ' Now associate a different event handler with the event.
        AddHandler c1.AnEvent, AddressOf EventHandler2
        ' Call a method to raise the event.
        c1.CauseTheEvent()
        ' Stop handling the event.
        RemoveHandler c1.AnEvent, AddressOf EventHandler2
        ' This event will not be handled.
        c1.CauseTheEvent()
    End Sub

    Sub EventHandler1()
        ' Handle the event.
        MsgBox("EventHandler1 caught event.")
    End Sub

    Sub EventHandler2()
        ' Handle the event.
        MsgBox("EventHandler2 caught event.")
    End Sub

    Public Class Class1
        ' Declare an event.
        Public Event AnEvent()
        Sub CauseTheEvent()
            ' Raise an event.
            RaiseEvent AnEvent()
        End Sub
    End Class

End Module