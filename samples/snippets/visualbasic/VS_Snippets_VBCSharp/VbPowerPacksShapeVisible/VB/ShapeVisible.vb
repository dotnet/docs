Public Class ShapeVisible
    ' <Snippet1>
    Private Sub ShapeVisible_Load() Handles MyBase.Load
        ' Hide the oval.
        OvalShape1.Visible = False
    End Sub

    Private Sub Shapes_Click() Handles RectangleShape1.Click,
                                       OvalShape1.Click

        If OvalShape1.Visible = True Then
            ' Hide the oval.
            OvalShape1.Visible = False
            ' Show the rectangle.
            RectangleShape1.Visible = True
        Else
            ' Hide the rectangle.
            RectangleShape1.Visible = False
            ' Show the oval.
            OvalShape1.Visible = True
        End If
    End Sub
    ' </Snippet1>
End Class
