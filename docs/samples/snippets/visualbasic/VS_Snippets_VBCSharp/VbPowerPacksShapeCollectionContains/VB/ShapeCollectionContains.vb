Imports Microsoft.VisualBasic.PowerPacks

Public Class ShapeCollectionContains
    ' <Snippet1>
    Private Sub Form1_Click() Handles Me.Click
        Dim canvas As ShapeContainer
        ' Get the ShapeContainer.
        canvas = OvalShape1.Parent
        ' If OvalShape2 is in the same collection, remove it.
        If canvas.Shapes.Contains(OvalShape2) Then
            canvas.Shapes.Remove(OvalShape2)
        End If
    End Sub

    ' </Snippet1>
End Class
