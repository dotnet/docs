Imports Microsoft.VisualBasic.PowerPacks

Public Class ShapeCollectionClear
    ' <Snippet1>
    Private Sub Form1_Click() Handles Me.Click
        ' Call the method to remove the shapes.
        RemoveShapes(OvalShape1)
    End Sub

    Private Sub RemoveShapes(ByVal shape As Shape)
        Dim canvas As ShapeContainer

        ' Find the ShapeContainer in which the shape is located.
        canvas = shape.Parent
        ' Call the Clear method to remove all shapes.
        canvas.Shapes.Clear()
    End Sub
    ' </Snippet1>
End Class
