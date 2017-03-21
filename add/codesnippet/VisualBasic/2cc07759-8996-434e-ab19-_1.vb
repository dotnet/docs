    Public Sub DrawPieRectangleF(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create rectangle for ellipse.
        Dim rect As New RectangleF(0.0F, 0.0F, 200.0F, 100.0F)

        ' Create start and sweep angles.
        Dim startAngle As Single = 0.0F
        Dim sweepAngle As Single = 45.0F

        ' Draw pie to screen.
        e.Graphics.DrawPie(blackPen, rect, startAngle, sweepAngle)
    End Sub