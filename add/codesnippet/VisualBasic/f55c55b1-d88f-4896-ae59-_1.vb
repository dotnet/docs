    Private Sub DrawArcRectangleF(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create rectangle to bound ellipse.
        Dim rect As New RectangleF(0.0F, 0.0F, 100.0F, 200.0F)

        ' Create start and sweep angles on ellipse.
        Dim startAngle As Single = 45.0F
        Dim sweepAngle As Single = 270.0F

        ' Draw arc to screen.
        e.Graphics.DrawArc(blackPen, rect, startAngle, sweepAngle)
    End Sub