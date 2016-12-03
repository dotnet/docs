    Custom Event Test As System.EventHandler
        AddHandler(ByVal value As System.EventHandler)
            ' Code for adding an event handler goes here.
        End AddHandler

        RemoveHandler(ByVal value As System.EventHandler)
            ' Code for removing an event handler goes here.
        End RemoveHandler

        RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
            ' Code for raising an event goes here.
        End RaiseEvent
    End Event