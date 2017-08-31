
Public Class ShapeContainerCursor
    ' <Snippet1>
    Private Sub Form1_Load() Handles MyBase.Load
        ' Display the hand cursor when mouse is over the ShapeContainer.
        ShapeContainer1.Cursor = Cursors.Hand
        ' Display the default cursor when mouse is over the RectangleShape.
        RectangleShape1.Cursor = Cursors.Default
    End Sub
    ' </Snippet1>
End Class
