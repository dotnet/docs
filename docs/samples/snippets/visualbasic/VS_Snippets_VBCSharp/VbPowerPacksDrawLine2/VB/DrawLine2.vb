Public Class DrawLine2

    Private Sub DrawLine2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' <Snippet1>
        Dim canvas As New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Dim line1 As New Microsoft.VisualBasic.PowerPacks.LineShape(0,
            0, 1000, 1000)
        ' Set the form as the parent of the ShapeContainer.
        canvas.Parent = Me
        ' Set the ShapeContainer as the parent of the LineShape.
        line1.Parent = canvas
        ' </Snippet1>
    End Sub
End Class
