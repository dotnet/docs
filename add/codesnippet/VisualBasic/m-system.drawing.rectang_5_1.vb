    Public Sub RectangleFInflateExample(ByVal e As PaintEventArgs)

        ' Create a RectangleF structure.
        Dim myRectF As New RectangleF(100, 20, 100, 100)

        ' Draw myRect to the screen.
        Dim myRect As Rectangle = Rectangle.Truncate(myRectF)
        e.Graphics.DrawRectangle(Pens.Black, myRect)

        ' Create a Size structure.
        Dim inflateSize As New SizeF(100, 0)

        ' Inflate myRect.
        myRectF.Inflate(inflateSize)

        ' Draw the inflated rectangle to the screen.
        myRect = Rectangle.Truncate(myRectF)
        e.Graphics.DrawRectangle(Pens.Red, myRect)
    End Sub