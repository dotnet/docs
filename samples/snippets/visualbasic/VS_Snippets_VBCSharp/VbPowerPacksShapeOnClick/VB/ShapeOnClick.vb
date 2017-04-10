Imports Microsoft.VisualBasic.PowerPacks

Public Class ShapeOnClick
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim theLine As New HighlightLine
        Dim canvas As New ShapeContainer
        canvas.Parent = Me
        theLine.Parent = canvas
        theLine.X1 = 0
        theLine.X2 = 0
        theLine.StartPoint = New System.Drawing.Point(0, 0)
        theLine.EndPoint = New System.Drawing.Point(640, 480)
    End Sub
End Class
' <Snippet1>
Public Class HighlightLine
    Inherits LineShape
    Protected Overrides Sub OnClick(ByVal e As EventArgs)
        ' Change the color of the line when clicked.
        Me.BorderColor = Color.Red
        MyBase.OnClick(e)
    End Sub
    Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
        ' Change the color of the line when focus is changed.
        Me.BorderColor = Color.Black
        MyBase.OnLostFocus(e)
    End Sub
End Class
' </Snippet1>


