    Public Sub WarpExample(ByVal e As PaintEventArgs)

        ' Create a path and add a rectangle.
        Dim myPath As New GraphicsPath
        Dim srcRect As New RectangleF(0, 0, 100, 200)
        myPath.AddRectangle(srcRect)

        ' Draw the source path (rectangle)to the screen.
        e.Graphics.DrawPath(Pens.Black, myPath)

        ' Create a destination for the warped rectangle.
        Dim point1 As New PointF(200, 200)
        Dim point2 As New PointF(400, 250)
        Dim point3 As New PointF(220, 400)
        Dim destPoints As PointF() = {point1, point2, point3}

        ' Create a translation matrix.
        Dim translateMatrix As New Matrix
        translateMatrix.Translate(100, 0)

        ' Warp the source path (rectangle).
        myPath.Warp(destPoints, srcRect, translateMatrix, _
        WarpMode.Perspective, 0.5F)

        ' Draw the warped path (rectangle) to the screen.
        e.Graphics.DrawPath(New Pen(Color.Red), myPath)
    End Sub