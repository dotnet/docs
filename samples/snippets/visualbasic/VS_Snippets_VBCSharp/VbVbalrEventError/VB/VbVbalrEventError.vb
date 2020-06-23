Class VbVbalrEventError
    '<snippet1>
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
    '</snippet1>
End Class

Class VbVbalrEventError2
    '<snippet2>
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
    '</snippet2>
End Class

Class VbVbalrEventError3
    '<snippet3>
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
    '</snippet3>
End Class

Class Class6911f0d1641a473b906d8ee5681194be
    ' 'Custom' modifier is not valid on events declared without explicit delegate types

    ' <snippet18>
    Delegate Sub TestDelegate(ByVal sender As Object, ByVal i As Integer)
    ' </snippet18>

    ' <snippet19>
    Custom Event Test As TestDelegate
        ' </snippet19>
        AddHandler(ByVal value As TestDelegate)
        End AddHandler
        RemoveHandler(ByVal value As TestDelegate)
        End RemoveHandler
        RaiseEvent(ByVal sender As Object, ByVal i As Integer)
        End RaiseEvent
    End Event

End Class

Class Class7d7b4934b5214ed3b054aeb71f8daacf
    ' '.' expected

    Private WithEvents Button1 As New Button
    ' <snippet21>
    Sub Button1_Click(ByVal sender As System.Object, 
            ByVal e As System.EventArgs) Handles Button1.Click
        ' </snippet21>
    End Sub

End Class


Class Classb71eb2f00bb24aeb94ec5c37ab960d9e
    ' 'AddHandler' or 'RemoveHandler' statement event operand must be a dot-qualified expression or a simple name

    Class Wobject
        Event ThisEvent()
    End Class
    Private Sub ThisEventHandler()

    End Sub
    Public Sub Method30()
        ' <snippet30>
        ' Assume that the class Wobject has an event named ThisEvent.
        Dim wObj As New Wobject
        ' Assume that this class has as method named ThisEventHandler.
        AddHandler wObj.ThisEvent, AddressOf Me.ThisEventHandler
        ' </snippet30>
    End Sub

End Class
