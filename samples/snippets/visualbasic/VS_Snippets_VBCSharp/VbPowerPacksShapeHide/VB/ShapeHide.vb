Public Class ShapeHide
    ' <Snippet1>
    Private Sub Form1_Load() Handles MyBase.Load
        ' Hide the oval.
        OvalShape1.Hide()
    End Sub

    Private Sub Shapes_Click() Handles RectangleShape1.Click, 
                                       OvalShape1.Click

        If OvalShape1.Visible = True Then
            ' Hide the oval.
            OvalShape1.Hide()
            ' Show the rectangle.
            RectangleShape1.Show()
        Else
            ' Hide the rectangle.
            RectangleShape1.Hide()
            ' Show the oval.
            OvalShape1.Show()
        End If
    End Sub
    ' </Snippet1>
End Class
