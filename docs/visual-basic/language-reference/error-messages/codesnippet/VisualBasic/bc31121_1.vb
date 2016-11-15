    Interface TestInterface
        Delegate Sub TestDelegate(ByVal sender As Object, ByVal i As Integer)

        Event Test As TestDelegate
    End Interface

    Class TestClass
        Implements TestInterface

        Public Custom Event Test As TestInterface.
            TestDelegate Implements TestInterface.Test

            AddHandler(ByVal value As TestInterface.TestDelegate)
                ' Code for adding an event handler goes here.
            End AddHandler

            RemoveHandler(ByVal value As TestInterface.TestDelegate)
                ' Code for removing an event handler goes here.
            End RemoveHandler

            RaiseEvent(ByVal sender As Object, ByVal i As Integer)
                ' Code for raising an event goes here.
            End RaiseEvent
        End Event
    End Class