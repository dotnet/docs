    public void DrawVisualStyleElementTrackBarTrackVertical1(PaintEventArgs e)
    {
        if (VisualStyleRenderer.IsElementDefined(
            VisualStyleElement.TrackBar.TrackVertical.Normal))
        {
            VisualStyleRenderer renderer =
                 new VisualStyleRenderer(VisualStyleElement.TrackBar.TrackVertical.Normal);
            Rectangle rectangle1 = new Rectangle(10, 50, 50, 50);
            renderer.DrawBackground(e.Graphics, rectangle1);
            e.Graphics.DrawString("VisualStyleElement.TrackBar.TrackVertical.Normal",
                 this.Font, Brushes.Black, new Point(10, 10));
        }
        else
            e.Graphics.DrawString("This element is not defined in the current visual style.",
                 this.Font, Brushes.Black, new Point(10, 10));
    }