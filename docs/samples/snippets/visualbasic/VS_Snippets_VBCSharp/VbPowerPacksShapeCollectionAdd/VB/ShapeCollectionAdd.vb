Imports Microsoft.VisualBasic.PowerPacks

Public Class ShapeCollectionAdd
    ' <Snippet1>
    Private Sub RectangleShape1_Click() Handles RectangleShape1.Click
        ' Declare a new oval shape to add to the form.
        Dim oval As OvalShape = New OvalShape()
        ' Add the oval shape to the form.
        RectangleShape1.Parent.Shapes.Add(oval)
        oval.Location = New Point(50, 50)
        oval.Size = New Size(200, 100)
    End Sub
    ' </Snippet1>
End Class
