
    ' Begin Example03.
    Private Sub DrawBezierFloat(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create coordinates of points for curve.
        Dim startX As Single = 100.0F
        Dim startY As Single = 100.0F
        Dim controlX1 As Single = 200.0F
        Dim controlY1 As Single = 10.0F
        Dim controlX2 As Single = 350.0F
        Dim controlY2 As Single = 50.0F
        Dim endX As Single = 500.0F
        Dim endY As Single = 100.0F

        ' Draw arc to screen.
        e.Graphics.DrawBezier(blackPen, startX, startY, controlX1, _
        controlY1, controlX2, controlY2, endX, endY)
    End Sub