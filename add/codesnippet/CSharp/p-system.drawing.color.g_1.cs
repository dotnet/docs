    private void ShowPropertiesOfSlateBlue(PaintEventArgs e)
    {
        Color slateBlue = Color.FromName("SlateBlue");
        byte g = slateBlue.G;
        byte b = slateBlue.B;
        byte r = slateBlue.R;
        byte a = slateBlue.A;
        string text = String.Format("Slate Blue has these ARGB values: Alpha:{0}, " +
            "red:{1}, green: {2}, blue {3}", new object[]{a, r, g, b});
        e.Graphics.DrawString(text, 
            new Font(this.Font, FontStyle.Italic), 
            new SolidBrush(slateBlue), 
            new RectangleF(new PointF(0.0F, 0.0F), this.Size));
    }