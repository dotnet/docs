    public void DrawVisualStyleElementWindowHorizontalThumb3(PaintEventArgs e)
    {
        if (VisualStyleRenderer.IsElementDefined(
            VisualStyleElement.Window.HorizontalThumb.Pressed))
        {
            VisualStyleRenderer renderer =
                 new VisualStyleRenderer(VisualStyleElement.Window.HorizontalThumb.Pressed);
            Rectangle rectangle1 = new Rectangle(10, 50, 50, 50);
            renderer.DrawBackground(e.Graphics, rectangle1);
            e.Graphics.DrawString("VisualStyleElement.Window.HorizontalThumb.Pressed",
                 this.Font, Brushes.Black, new Point(10, 10));
        }
        else
            e.Graphics.DrawString("This element is not defined in the current visual style.",
                 this.Font, Brushes.Black, new Point(10, 10));
    }