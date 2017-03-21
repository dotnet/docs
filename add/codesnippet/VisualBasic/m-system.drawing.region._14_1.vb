    Public Sub XorExample(ByVal e As PaintEventArgs)

        ' Create the first rectangle and draw it to the screen in black.
        Dim regionRect As New Rectangle(20, 20, 100, 100)
        e.Graphics.DrawRectangle(Pens.Black, regionRect)

        ' create the second rectangle and draw it to the screen in red.
        Dim xorRect As New RectangleF(90, 30, 100, 100)
        e.Graphics.DrawRectangle(Pens.Red, Rectangle.Round(xorRect))

        ' Create a region using the first rectangle.
        Dim myRegion As New [Region](regionRect)

        ' Get the area of overlap for myRegion when combined with
        ' complementRect.
        myRegion.Xor(xorRect)

        ' Fill the intersection area of myRegion with blue.
        Dim myBrush As New SolidBrush(Color.Blue)
        e.Graphics.FillRegion(myBrush, myRegion)
    End Sub