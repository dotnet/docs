Imports Microsoft.VisualBasic.PowerPacks

Public Class SimpleShapeBorderWidth
    ' <Snippet1>
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim OvalShape1 As New OvalShape
        Dim canvas As New ShapeContainer
        ' Set the form as the parent of the ShapeContainer.
        canvas.Parent = Me
        ' Set the ShapeContainer as the parent of the OvalShape.
        OvalShape1.Parent = canvas
        ' Change the color of the border to red.
        OvalShape1.BorderColor = Color.Red
        ' Change the style of the border to dotted.
        OvalShape1.BorderStyle = Drawing2D.DashStyle.Dot
        ' Change the thickness of the border to 3 pixels.
        OvalShape1.BorderWidth = 3
        OvalShape1.Size = New Size(300, 200)
    End Sub
    ' </Snippet1>
End Class
