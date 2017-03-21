    Public Sub GetBoundsExample(ByVal e As PaintEventArgs)

        ' Create path number 1 and a Pen for drawing.
        Dim myPath As New GraphicsPath
        Dim pathPen As New Pen(Color.Black, 1)

        ' Add an Ellipse to the path and Draw it (circle in start

        ' position).
        myPath.AddEllipse(20, 20, 100, 100)
        e.Graphics.DrawPath(pathPen, myPath)

        ' Get the path bounds for Path number 1 and draw them.
        Dim boundRect As RectangleF = myPath.GetBounds()
        e.Graphics.DrawRectangle(New Pen(Color.Red, 1), boundRect.X, _
        boundRect.Y, boundRect.Height, boundRect.Width)

        ' Create a second graphics path and a wider Pen.
        Dim myPath2 As New GraphicsPath
        Dim pathPen2 As New Pen(Color.Black, 10)

        ' Create a new ellipse with a width of 10.
        myPath2.AddEllipse(150, 20, 100, 100)
        myPath2.Widen(pathPen2)
        e.Graphics.FillPath(Brushes.Black, myPath2)

        ' Get the second path bounds.
        Dim boundRect2 As RectangleF = myPath2.GetBounds()

        ' Show the bounds in a message box.
        e.Graphics.DrawString("Rectangle2 Bounds: " + _
        boundRect2.ToString(), New Font("Arial", 8), Brushes.Black, _
        20, 150)

        ' Draw the bounding rectangle.
        e.Graphics.DrawRectangle(New Pen(Color.Red, 1), boundRect2.X, _
        boundRect2.Y, boundRect2.Height, boundRect2.Width)
    End Sub