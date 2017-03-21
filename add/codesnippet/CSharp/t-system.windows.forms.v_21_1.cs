    public void DrawVisualStyleElementWindowSmallFrameRight1(PaintEventArgs e)
    {
        if (VisualStyleRenderer.IsElementDefined(
            VisualStyleElement.Window.SmallFrameRight.Active))
        {
            VisualStyleRenderer renderer =
                 new VisualStyleRenderer(VisualStyleElement.Window.SmallFrameRight.Active);
            Rectangle rectangle1 = new Rectangle(10, 50, 50, 50);
            renderer.DrawBackground(e.Graphics, rectangle1);
            e.Graphics.DrawString("VisualStyleElement.Window.SmallFrameRight.Active",
                 this.Font, Brushes.Black, new Point(10, 10));
        }
        else
            e.Graphics.DrawString("This element is not defined in the current visual style.",
                 this.Font, Brushes.Black, new Point(10, 10));
    }