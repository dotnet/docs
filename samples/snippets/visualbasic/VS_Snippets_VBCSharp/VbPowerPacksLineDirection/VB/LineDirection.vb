Public Class LineDirection
    ' <Snippet1>
    Dim canvas As New Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Dim line1 As New Microsoft.VisualBasic.PowerPacks.LineShape(10, 10,
        200, 10)
    Private Sub LineDirection_Load(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the form as the parent of the ShapeContainer.
        canvas.Parent = Me
        ' Set the ShapeContainer as the parent of the LineShape.
        line1.Parent = canvas
    End Sub
    Private Sub LineDirection_Click(ByVal sender As Object,
        ByVal e As System.EventArgs) Handles Me.Click
        ChangeDirection()
    End Sub
    Private Sub ChangeDirection()
        If line1.X1 = line1.Y2 Then
            line1.X2 = 10
            line1.Y2 = 200
        Else
            line1.X2 = 200
            line1.Y2 = 10
        End If
    End Sub
    ' </Snippet1>
End Class
