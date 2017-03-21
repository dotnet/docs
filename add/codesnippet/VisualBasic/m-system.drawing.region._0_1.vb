    Public Sub Union_RectF_Example(ByVal e As PaintEventArgs)

        ' Create the first rectangle and draw it to the screen in black.
        Dim regionRect As New Rectangle(20, 20, 100, 100)
        e.Graphics.DrawRectangle(Pens.Black, regionRect)

        ' create the second rectangle and draw it to the screen in red.
        Dim unionRect As New RectangleF(90, 30, 100, 100)
        e.Graphics.DrawRectangle(Pens.Red, Rectangle.Round(unionRect))

        ' Create a region using the first rectangle.
        Dim myRegion As New [Region](regionRect)

        ' Get the area of union for myRegion when combined with
        ' complementRect.
        myRegion.Union(unionRect)

        ' Fill the intersection area of myRegion with blue.
        Dim myBrush As New SolidBrush(Color.Blue)
        e.Graphics.FillRegion(myBrush, myRegion)
    End Sub