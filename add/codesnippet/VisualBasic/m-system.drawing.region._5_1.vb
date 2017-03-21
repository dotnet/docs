    Public Sub IsVisible_RectF_Example(ByVal e As PaintEventArgs)

        ' Create the first rectangle and draw it to the screen in blue.
        Dim regionRect As New Rectangle(20, 20, 100, 100)
        e.Graphics.DrawRectangle(Pens.Blue, regionRect)

        ' create the second rectangle and draw it to the screen in red.
        Dim myRect As New RectangleF(90, 30, 100, 100)
        e.Graphics.DrawRectangle(Pens.Red, Rectangle.Round(myRect))

        ' Create a region using the first rectangle.
        Dim myRegion As New [Region](regionRect)

        ' Determine if myRect is contained in the region.
        Dim contained As Boolean = myRegion.IsVisible(myRect)

        ' Display the result.
        Dim myFont As New Font("Arial", 8)
        Dim myBrush As New SolidBrush(Color.Black)
        e.Graphics.DrawString("contained = " & contained.ToString(), _
        myFont, myBrush, New PointF(20, 140))
    End Sub