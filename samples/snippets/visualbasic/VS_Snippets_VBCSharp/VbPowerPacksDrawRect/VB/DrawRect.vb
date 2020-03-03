Public Class DrawRect

    Private Sub DrawRect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DrawRectangle()
        DrawRectangle2()
        DrawSquare()
    End Sub

    ' <Snippet1>
    Private Sub DrawRectangle()
        Dim canvas As New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Dim rect1 As New Microsoft.VisualBasic.PowerPacks.RectangleShape
        ' Set the form as the parent of the ShapeContainer.
        canvas.Parent = Me
        ' Set the ShapeContainer as the parent of the RectangleShape.
        rect1.Parent = canvas
        ' Set the location and size of the rectangle.
        rect1.Left = 10
        rect1.Top = 10
        rect1.Width = 300
        rect1.Height = 100
    End Sub
    ' </Snippet1>
    ' <Snippet2>
    Private Sub DrawRectangle2()
        ' Declare a RectangleShape and parent it to 
        ' LineShape1's ShapeContainer.
        Dim rect1 As New Microsoft.VisualBasic.PowerPacks.
            RectangleShape(LineShape1.Parent)
        ' Set the location and size of the rectangle.
        rect1.Left = 40
        rect1.Top = 40
        rect1.Width = 120
        rect1.Height = 220
    End Sub
    ' </Snippet2>
    ' <Snippet3>
    Private Sub DrawSquare()
        Dim canvas As New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        ' Declare a RectangleShape and set the location and size.
        Dim rect1 As New Microsoft.VisualBasic.PowerPacks.
            RectangleShape(15, 15, 105, 105)
        ' Set the form as the parent of the ShapeContainer.
        canvas.Parent = Me
        ' Set the ShapeContainer as the parent of the RectangleShape.
        rect1.Parent = canvas
    End Sub
    ' </Snippet3>
    ' <Snippet4>
    Private Sub RectangleShape1_Click(ByVal sender As System.Object,
     ByVal e As System.EventArgs) Handles RectangleShape1.Click
        Dim max As Integer
        ' Calculate the maximum radius.
        max = Math.Min(RectangleShape1.Height, RectangleShape1.Width) / 2
        ' Check whether the maximum radius has been reached.
        If RectangleShape1.CornerRadius = max Then
            ' Reset the radius to 0.
            RectangleShape1.CornerRadius = 0
        Else
            ' Increase the radius.
            RectangleShape1.CornerRadius =
              RectangleShape1.CornerRadius + 15
        End If
    End Sub
    ' </Snippet4>
End Class
