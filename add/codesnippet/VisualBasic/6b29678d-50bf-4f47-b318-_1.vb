    Private Sub DrawArcRectangle(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create rectangle to bound ellipse.
        Dim rect As New Rectangle(0, 0, 100, 200)

        ' Create start and sweep angles on ellipse.
        Dim startAngle As Single = 45.0F
        Dim sweepAngle As Single = 270.0F

        ' Draw arc to screen.
        e.Graphics.DrawArc(blackPen, rect, startAngle, sweepAngle)
    End Sub