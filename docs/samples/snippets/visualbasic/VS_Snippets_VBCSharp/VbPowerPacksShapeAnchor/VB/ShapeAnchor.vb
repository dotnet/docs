Public Class ShapeAnchor
    ' <Snippet1>
    Private Sub ResizeShapes()
        ' Loop through the ShapeCollection.
        For Each shape As PowerPacks.Shape In ShapeContainer1.Shapes
            ' Set the Anchor property.
            shape.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or
              AnchorStyles.Right Or AnchorStyles.Top
        Next
    End Sub
    ' </Snippet1>
    Private Sub ShapeAnchor_Resize(ByVal sender As Object,
      ByVal e As System.EventArgs) Handles Me.Resize
        ' Call the ResizeShapes function when the form is resized.
        ResizeShapes()
    End Sub

End Class
