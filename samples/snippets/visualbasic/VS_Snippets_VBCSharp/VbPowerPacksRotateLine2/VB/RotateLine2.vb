Public Class RotateLine2
    ' <Snippet1>
    Dim canvas As New Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Dim line1 As New Microsoft.VisualBasic.PowerPacks.LineShape(10, 10, 200, 10)

    Private Sub RotateLine2_Load() Handles MyBase.Load
        ' Set the form as the parent of the ShapeContainer.
        canvas.Parent = Me
        ' Set the ShapeContainer as the parent of the LineShape.
        line1.Parent = canvas
    End Sub
    Private Sub RotateLine2_Click() Handles Me.Click
        ChangeOrientation()
    End Sub
    Private Sub ChangeOrientation()
        Static direction As String = "horizontal"
        If direction = "horizontal" Then
            ' Change the orientation to diagonal.
            line1.StartPoint = New System.Drawing.Point(line1.X1, 200)
            direction = "diagonal"
        ElseIf direction = "diagonal" Then
            ' Change the orientation to vertical.
            line1.StartPoint = New System.Drawing.Point(line1.Y1, 200)
            direction = "vertical"
        Else
            ' Change the orientation to horizontal.
            line1.StartPoint = New System.Drawing.Point(10, line1.Y2)
            direction = "horizontal"
        End If
    End Sub
    ' </Snippet1>
End Class
