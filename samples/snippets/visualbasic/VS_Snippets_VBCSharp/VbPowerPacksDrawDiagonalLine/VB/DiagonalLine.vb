Public Class DiagonalLine

    Private Sub DiagonalLine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' <Snippet1>
        Dim canvas As New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Dim line1 As New Microsoft.VisualBasic.PowerPacks.LineShape
        ' Set the form as the parent of the ShapeContainer.
        canvas.Parent = Me
        ' Set the ShapeContainer as the parent of the LineShape.
        line1.Parent = canvas
        ' Set the starting and ending coordinates for the line.
        line1.StartPoint = New System.Drawing.Point(0, 0)
        line1.EndPoint = New System.Drawing.Point(1000, 1000)
        ' </Snippet1>
    End Sub
End Class
