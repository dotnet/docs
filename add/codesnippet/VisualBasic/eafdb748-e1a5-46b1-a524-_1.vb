    Public Sub DrawLinePointF(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create points that define line.
        Dim point1 As New PointF(100.0F, 100.0F)
        Dim point2 As New PointF(500.0F, 100.0F)

        ' Draw line to screen.
        e.Graphics.DrawLine(blackPen, point1, point2)
    End Sub