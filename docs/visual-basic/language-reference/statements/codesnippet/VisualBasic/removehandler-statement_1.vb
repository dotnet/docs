    Sub TestEvents()
        Dim Obj As New Class1
        ' Associate an event handler with an event.
        AddHandler Obj.Ev_Event, AddressOf EventHandler
        ' Call the method to raise the event.
        Obj.CauseSomeEvent()
        ' Stop handling events.
        RemoveHandler Obj.Ev_Event, AddressOf EventHandler
        ' This event will not be handled.
        Obj.CauseSomeEvent()
    End Sub

    Sub EventHandler()
        ' Handle the event.
        MsgBox("EventHandler caught event.")
    End Sub

    Public Class Class1
        ' Declare an event.
        Public Event Ev_Event()
        Sub CauseSomeEvent()
            ' Raise an event.
            RaiseEvent Ev_Event()
        End Sub
    End Class