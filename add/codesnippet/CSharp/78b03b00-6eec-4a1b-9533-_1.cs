    public void DrawVisualStyleElementScrollBarLeftTrackHorizontal2(PaintEventArgs e)
    {
        if (VisualStyleRenderer.IsElementDefined(
            VisualStyleElement.ScrollBar.LeftTrackHorizontal.Hot))
        {
            VisualStyleRenderer renderer =
                 new VisualStyleRenderer(VisualStyleElement.ScrollBar.LeftTrackHorizontal.Hot);
            Rectangle rectangle1 = new Rectangle(10, 50, 50, 50);
            renderer.DrawBackground(e.Graphics, rectangle1);
            e.Graphics.DrawString("VisualStyleElement.ScrollBar.LeftTrackHorizontal.Hot",
                 this.Font, Brushes.Black, new Point(10, 10));
        }
        else
            e.Graphics.DrawString("This element is not defined in the current visual style.",
                 this.Font, Brushes.Black, new Point(10, 10));
    }