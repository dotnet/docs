    Public Sub DrawPieFloat(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create location and size of ellipse.
        Dim x As Single = 0.0F
        Dim y As Single = 0.0F
        Dim width As Single = 200.0F
        Dim height As Single = 100.0F

        ' Create start and sweep angles.
        Dim startAngle As Single = 0.0F
        Dim sweepAngle As Single = 45.0F

        ' Draw pie to screen.
        e.Graphics.DrawPie(blackPen, x, y, width, height, _
        startAngle, sweepAngle)
    End Sub