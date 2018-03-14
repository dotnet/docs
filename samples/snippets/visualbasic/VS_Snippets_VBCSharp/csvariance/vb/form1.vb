Public Class Form1
    Dim Label1 As Label
    Dim Button1 As Button

    '<Snippet200>
    ' Event hander that accepts a parameter of the EventArgs type.
    Private Sub MultiHandler(ByVal sender As Object,
                             ByVal e As System.EventArgs)
        Label1.Text = DateTime.Now
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles MyBase.Load

        ' You can use a method that has an EventArgs parameter,
        ' although the event expects the KeyEventArgs parameter.
        AddHandler Button1.KeyDown, AddressOf MultiHandler

        ' You can use the same method 
        ' for the event that expects the MouseEventArgs parameter.
        AddHandler Button1.MouseClick, AddressOf MultiHandler
    End Sub
    '</Snippet200>
End Class

Module w1
    '<Snippet201>
    Class Mammals
    End Class

    Class Dogs
        Inherits Mammals
    End Class
    Class Test
        Public Delegate Function HandlerMethod() As Mammals
        Public Shared Function MammalsHandler() As Mammals
            Return Nothing
        End Function
        Public Shared Function DogsHandler() As Dogs
            Return Nothing
        End Function
        Sub Test()
            Dim handlerMammals As HandlerMethod = AddressOf MammalsHandler
            ' Covariance enables this assignment.
            Dim handlerDogs As HandlerMethod = AddressOf DogsHandler
        End Sub
    End Class
    '</Snippet201>
End Module
