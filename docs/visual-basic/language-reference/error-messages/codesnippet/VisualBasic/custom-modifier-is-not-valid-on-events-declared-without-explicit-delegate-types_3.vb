    Delegate Sub TestDelegate(ByVal sender As Object, ByVal i As Integer)
    Custom Event Test As TestDelegate
        AddHandler(ByVal value As TestDelegate)
            ' Code for adding an event handler goes here.
        End AddHandler

        RemoveHandler(ByVal value As TestDelegate)
            ' Code for removing an event handler goes here.
        End RemoveHandler

        RaiseEvent(ByVal sender As Object, ByVal i As Integer)
            ' Code for raising an event goes here.
        End RaiseEvent
    End Event