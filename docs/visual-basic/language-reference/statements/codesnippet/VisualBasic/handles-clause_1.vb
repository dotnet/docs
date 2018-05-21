    Public Class ContainerClass
        ' Module or class level declaration.
        WithEvents Obj As New Class1

        Public Class Class1
            ' Declare an event.
            Public Event Ev_Event()
            Sub CauseSomeEvent()
                ' Raise an event.
                RaiseEvent Ev_Event()
            End Sub
        End Class

        Sub EventHandler() Handles Obj.Ev_Event
            ' Handle the event.
            MsgBox("EventHandler caught event.")
        End Sub

        ' Call the TestEvents procedure from an instance of the ContainerClass 
        ' class to test the Ev_Event event and the event handler.
        Public Sub TestEvents()
            Obj.CauseSomeEvent()
        End Sub
    End Class