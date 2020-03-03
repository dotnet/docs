Public Class SimpleShapeBottom
    ' <Snippet1>
    Private Sub RectangleShape1_Click() Handles RectangleShape1.Click
        ' Set the upper-left corner of Rectangle2 
        ' to the lower-right corner of Rectangle1.
        RectangleShape2.Left = RectangleShape1.Right
        RectangleShape2.Top = RectangleShape1.Bottom
    End Sub
    ' </Snippet1>
End Class
