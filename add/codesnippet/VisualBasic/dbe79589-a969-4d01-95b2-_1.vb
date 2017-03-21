    Private Sub ShowRectangleUnion(ByVal e As PaintEventArgs)

        ' Declare two rectangles and draw them.
        Dim rectangle1 As New Rectangle(30, 40, 50, 100)
        Dim rectangle2 As New Rectangle(50, 60, 100, 60)
        e.Graphics.DrawRectangle(Pens.Sienna, rectangle1)
        e.Graphics.DrawRectangle(Pens.BlueViolet, rectangle2)

        ' Declare a third rectangle as a union of the first two.
        Dim rectangle3 As Rectangle = Rectangle.Union(rectangle1, _
            rectangle2)

        ' Fill in the third rectangle in a semi-transparent color.
        Dim transparentColor As Color = Color.FromArgb(40, 135, 135, 255)
        e.Graphics.FillRectangle(New SolidBrush(transparentColor), _
            rectangle3)
    End Sub