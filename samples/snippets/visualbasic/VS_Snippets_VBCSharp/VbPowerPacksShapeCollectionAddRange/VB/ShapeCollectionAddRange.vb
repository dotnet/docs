Imports Microsoft.VisualBasic.PowerPacks
Public Class ShapeCollectionAddRange
    ' <Snippet1>
    Private Sub RectangleShape1_Click() Handles RectangleShape1.Click
        ' Create two oval shapes to add to the form.
        Dim oval1 As OvalShape = New OvalShape()
        Dim oval2 As OvalShape = New OvalShape()

        ' Set the size of the ovals.
        oval1.Size = New Size(100, 200)
        oval2.Size = oval1.Size

        ' Set the appropriate location of ovals.
        oval1.Location = New Point(10, 10)
        oval2.Location = New Point(oval1.Left + 10, oval1.Top + 10)

        ' Add the controls to the form by using the AddRange method.
        RectangleShape1.Parent.Shapes.AddRange(New Shape() {oval1, oval2})
    End Sub
    ' </Snippet1>
End Class
