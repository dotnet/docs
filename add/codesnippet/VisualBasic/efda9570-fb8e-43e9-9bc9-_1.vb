    Public Sub DrawPieInt(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create location and size of ellipse.
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim width As Integer = 200
        Dim height As Integer = 100

        ' Create start and sweep angles.
        Dim startAngle As Integer = 0
        Dim sweepAngle As Integer = 45

        ' Draw pie to screen.
        e.Graphics.DrawPie(blackPen, x, y, width, height, _
        startAngle, sweepAngle)
    End Sub