    Private Sub DrawArcInt(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create coordinates of rectangle to bound ellipse.
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim width As Integer = 100
        Dim height As Integer = 200

        ' Create start and sweep angles on ellipse.
        Dim startAngle As Integer = 45
        Dim sweepAngle As Integer = 270

        ' Draw arc to screen.
        e.Graphics.DrawArc(blackPen, x, y, width, height, startAngle, _
        sweepAngle)
    End Sub