        HatchBrush hBrush = new HatchBrush(
           HatchStyle.Horizontal,
           Color.Red,
           Color.FromArgb(255, 128, 255, 255));
        e.Graphics.FillEllipse(hBrush, 0, 0, 100, 60);