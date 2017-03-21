    Private Sub AddShadow(ByVal e As PaintEventArgs)

        ' Create two SizeF objects.
        Dim shadowSize As SizeF = Size.op_Implicit(listBox1.Size)
        Dim addSize As New SizeF(10.5F, 20.8F)

        ' Add them together and save the result in shadowSize.
        shadowSize = SizeF.op_Addition(shadowSize, addSize)

        ' Get the location of the ListBox and convert it to a PointF.
        Dim shadowLocation As PointF = Point.op_Implicit(listBox1.Location)

        ' Add a Size to the Point to get a new location.
        shadowLocation = PointF.op_Addition(shadowLocation, New Size(5, 5))

        ' Create a rectangleF. 
        Dim rectFToFill As New RectangleF(shadowLocation, shadowSize)

        ' Create a custom brush using a semi-transparent color, and 
        ' then fill in the rectangle.
        Dim customColor As Color = Color.FromArgb(50, Color.Gray)
        Dim shadowBrush As SolidBrush = New SolidBrush(customColor)
        e.Graphics.FillRectangles(shadowBrush, _
            New RectangleF() {rectFToFill})

        ' Dispose of the brush.
        shadowBrush.Dispose()
    End Sub