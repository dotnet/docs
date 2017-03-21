        Dim linGrBrush As New LinearGradientBrush( _
           New Point(0, 10), _
           New Point(200, 10), _
           Color.FromArgb(255, 255, 0, 0), _
           Color.FromArgb(255, 0, 0, 255))
        Dim pen As New Pen(linGrBrush)

        e.Graphics.DrawLine(pen, 0, 10, 200, 10)
        e.Graphics.FillEllipse(linGrBrush, 0, 30, 200, 100)
        e.Graphics.FillRectangle(linGrBrush, 0, 155, 500, 30)
