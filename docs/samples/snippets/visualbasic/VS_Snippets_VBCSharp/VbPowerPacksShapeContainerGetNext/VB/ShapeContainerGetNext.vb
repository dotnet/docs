Imports Microsoft.VisualBasic.PowerPacks

Public Class ShapeContainerGetNext
    ' <Snippet1>
    Private Sub Shapes_PreviewKeyDown(
        ByVal sender As Object, 
        ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs
      ) Handles RectangleShape1.PreviewKeyDown, 
                RectangleShape2.PreviewKeyDown, 
                RectangleShape3.PreviewKeyDown

        Dim sh As Shape
        ' Check for the TAB key.
        If e.KeyCode = Keys.Tab Then
            ' Find the next shape in the order.
            sh = ShapeContainer1.GetNextShape(sender, True)
            ' Select the next shape.
            ShapeContainer1.SelectNextShape(sender, True, True)
        End If
    End Sub
    ' </Snippet1>
End Class
