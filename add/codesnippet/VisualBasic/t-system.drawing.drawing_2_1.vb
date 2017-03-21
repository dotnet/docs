        Dim hBrush As New HatchBrush( _
           HatchStyle.Horizontal, _
           Color.Red, _
           Color.FromArgb(255, 128, 255, 255))
        e.Graphics.FillEllipse(hBrush, 0, 0, 100, 60)
