Public Class ShapeContainerShapes
    ' <Snippet1>
    Private Sub Shapes_Click(
        ByVal sender As System.Object, 
        ByVal e As System.EventArgs
      ) Handles RectangleShape1.Click, 
                OvalShape1.Click, LineShape1.Click

        ' Determine whether the shape is in the collection.
        If ShapeContainer1.Shapes.Contains(sender) Then
            ' If the index is greater than 0, remove the shape.
            If ShapeContainer1.Shapes.IndexOf(sender) > 0 Then
                ShapeContainer1.Shapes.Remove(sender)
            End If
        End If
    End Sub
    ' </Snippet1>
End Class
