Public Class DrawLine

    Private Sub DrawLine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' <Snippet1>
        Dim canvas As New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Dim line1 As New Microsoft.VisualBasic.PowerPacks.LineShape
        ' Set the form as the parent of the ShapeContainer.
        canvas.Parent = Me
        ' Set the ShapeContainer as the parent of the LineShape.
        line1.Parent = canvas
        ' Set the starting and ending coordinates for the line.
        line1.StartPoint = New System.Drawing.Point(Me.Width / 2, 0)
        line1.EndPoint = New System.Drawing.Point(Me.Width / 2, Me.Height)
        ' </Snippet1>
    End Sub
    
End Class
