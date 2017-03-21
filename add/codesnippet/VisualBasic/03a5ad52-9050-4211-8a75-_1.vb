    Private Sub RoundingAndTruncatingRectangles( _
        ByVal e As PaintEventArgs)

        ' Construct a new RectangleF.
        Dim myRectangleF As New RectangleF(30.6F, 30.7F, 40.8F, 100.9F)

        ' Call the Round method.
        Dim roundedRectangle As Rectangle = Rectangle.Round(myRectangleF)

        ' Draw the rounded rectangle in red.
        Dim redPen As New Pen(Color.Red, 4)
        e.Graphics.DrawRectangle(redPen, roundedRectangle)

        ' Call the Truncate method.
        Dim truncatedRectangle As Rectangle = _
            Rectangle.Truncate(myRectangleF)

        ' Draw the truncated rectangle in white.
        Dim whitePen As New Pen(Color.White, 4)
        e.Graphics.DrawRectangle(whitePen, truncatedRectangle)

        ' Dispose of the custom pens.
        redPen.Dispose()
        whitePen.Dispose()
    End Sub