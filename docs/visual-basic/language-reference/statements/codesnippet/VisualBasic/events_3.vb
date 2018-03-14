    ' Declare a WithEvents variable.
    Dim WithEvents EClass As New EventClass

    ' Call the method that raises the object's events.
    Sub TestEvents()
        EClass.RaiseEvents()
    End Sub

    ' Declare an event handler that handles multiple events.
    Sub EClass_EventHandler() Handles EClass.XEvent, EClass.YEvent
        MsgBox("Received Event.")
    End Sub

    Class EventClass
        Public Event XEvent()
        Public Event YEvent()
        ' RaiseEvents raises both events.
        Sub RaiseEvents()
            RaiseEvent XEvent()
            RaiseEvent YEvent()
        End Sub
    End Class