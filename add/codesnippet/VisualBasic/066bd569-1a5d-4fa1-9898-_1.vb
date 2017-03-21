    Private Sub DrawArcFloat(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create coordinates of rectangle to bound ellipse.
        Dim x As Single = 0.0F
        Dim y As Single = 0.0F
        Dim width As Single = 100.0F
        Dim height As Single = 200.0F

        ' Create start and sweep angles on ellipse.
        Dim startAngle As Single = 45.0F
        Dim sweepAngle As Single = 270.0F

        ' Draw arc to screen.
        e.Graphics.DrawArc(blackPen, x, y, width, height, startAngle, _
        sweepAngle)
    End Sub