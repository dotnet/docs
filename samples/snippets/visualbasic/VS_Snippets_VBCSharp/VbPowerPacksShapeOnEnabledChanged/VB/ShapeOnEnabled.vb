Imports Microsoft.VisualBasic.PowerPacks
Public Class ShapeOnEnabled
    Dim canvas As New ShapeContainer
    Dim theLine As New DisabledLine
    Private Sub OvalShape1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OvalShape1.Click
        theLine.Enabled = Not theLine.Enabled
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Set the form as the parent of the ShapeContainer.
        canvas.Parent = Me
        ' Set the ShapeContainer as the parent of the LineShape.
        theLine.Parent = canvas
        ' Set the starting and ending coordinates for the line.
        theLine.StartPoint = New System.Drawing.Point(0, 0)
        theLine.EndPoint = New System.Drawing.Point(640, 480)
    End Sub
End Class
' <Snippet1>
Public Class DisabledLine
    Inherits LineShape
    Protected Overrides Sub OnEnabledChanged(ByVal e As EventArgs)
        ' Change the color of the line when selected.
        If Me.BorderColor = SystemColors.InactiveBorder Then
            Me.BorderColor = Color.Black
        Else
            Me.BorderColor = SystemColors.InactiveBorder
        End If
        MyBase.OnEnabledChanged(e)
    End Sub
End Class
' </Snippet1>

