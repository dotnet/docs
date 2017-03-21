    public void DrawVisualStyleElementTreeViewGlyph2(PaintEventArgs e)
    {
        if (VisualStyleRenderer.IsElementDefined(
            VisualStyleElement.TreeView.Glyph.Opened))
        {
            VisualStyleRenderer renderer =
                 new VisualStyleRenderer(VisualStyleElement.TreeView.Glyph.Opened);
            Rectangle rectangle1 = new Rectangle(10, 50, 50, 50);
            renderer.DrawBackground(e.Graphics, rectangle1);
            e.Graphics.DrawString("VisualStyleElement.TreeView.Glyph.Opened",
                 this.Font, Brushes.Black, new Point(10, 10));
        }
        else
            e.Graphics.DrawString("This element is not defined in the current visual style.",
                 this.Font, Brushes.Black, new Point(10, 10));
    }