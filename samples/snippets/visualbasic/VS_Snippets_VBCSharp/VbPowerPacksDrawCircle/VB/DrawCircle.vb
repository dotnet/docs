Public Class DrawCircle

    Private Sub DrawCircle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DrawCircle()
        DrawOval()
        DrawCircle2()
    End Sub
    ' <Snippet1>
    Private Sub DrawCircle()
        Dim canvas As New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Dim oval1 As New Microsoft.VisualBasic.PowerPacks.OvalShape
        ' Set the form as the parent of the ShapeContainer.
        canvas.Parent = Me
        ' Set the ShapeContainer as the parent of the OvalShape.
        oval1.Parent = canvas
        ' Set the location and size of the circle.
        oval1.Left = 10
        oval1.Top = 10
        oval1.Width = 100
        oval1.Height = 100
    End Sub
    ' </Snippet1>
    ' <Snippet2>
    Private Sub DrawOval()
        ' Declare an OvalShape and parent it to LineShape1's ShapeContainer.
        Dim oval1 As New Microsoft.VisualBasic.PowerPacks.
          OvalShape(LineShape1.Parent)
        ' Set the location and size of the oval.
        oval1.Left = 10
        oval1.Top = 10
        oval1.Width = 100
        oval1.Height = 200
    End Sub
    ' </Snippet2>
    ' <Snippet3>
    Private Sub DrawCircle2()
        Dim canvas As New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        ' Declare an OvalShape and set the location and size.
        Dim oval1 As New Microsoft.VisualBasic.PowerPacks.OvalShape(20, 20,
          120, 120)
        ' Set the form as the parent of the ShapeContainer.
        canvas.Parent = Me
        ' Set the ShapeContainer as the parent of the OvalShape.
        oval1.Parent = canvas
    End Sub
    ' </Snippet3>
End Class
