    Public Sub DrawLinesPointF(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create array of points that define lines to draw.
        Dim points As PointF() = {New PointF(10.0F, 10.0F), _
        New PointF(10.0F, 100.0F), New PointF(200.0F, 50.0F), _
        New PointF(250.0F, 300.0F)}

        'Draw lines to screen.
        e.Graphics.DrawLines(blackPen, points)
    End Sub