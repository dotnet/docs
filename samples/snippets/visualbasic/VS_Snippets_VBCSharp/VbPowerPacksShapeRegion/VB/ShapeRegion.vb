Public Class ShapeRegion
    ' <Snippet1>
    Private Sub RectangleShape1_Paint(
        ByVal sender As Object, 
        ByVal e As System.Windows.Forms.PaintEventArgs
      ) Handles RectangleShape1.Paint

        Dim shapePath As New System.Drawing.Drawing2D.GraphicsPath

        ' Set a new rectangle to the same size as the RectangleShape's 
        ' ClientRectangle property.
        Dim newRectangle As Rectangle = RectangleShape1.ClientRectangle

        ' Decrease the size of the rectangle.
        newRectangle.Inflate(-10, -10)

        ' Draw the new rectangle's border.
        e.Graphics.DrawEllipse(System.Drawing.Pens.Black, newRectangle)

        ' Create a semi-transparent brush.
        Dim br As New SolidBrush(Color.FromArgb(128, 0, 0, 255))

        ' Fill the new rectangle.
        e.Graphics.FillEllipse(br, newRectangle)
        'Increase the size of the rectangle to include the border.
        newRectangle.Inflate(1, 1)

        ' Create an oval region within the new rectangle.
        shapePath.AddEllipse(newRectangle)
        e.Graphics.DrawPath(Pens.Black, shapePath)

        ' Set the RectangleShape's Region property to the newly created 
        ' oval region.
        RectangleShape1.Region = New System.Drawing.Region(shapePath)
    End Sub
    ' </Snippet1>
End Class
