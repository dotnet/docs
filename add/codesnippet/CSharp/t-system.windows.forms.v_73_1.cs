    public void DrawVisualStyleElementListViewGroup1(PaintEventArgs e)
    {
        if (VisualStyleRenderer.IsElementDefined(
            VisualStyleElement.ListView.Group.Normal))
        {
            VisualStyleRenderer renderer =
                 new VisualStyleRenderer(VisualStyleElement.ListView.Group.Normal);
            Rectangle rectangle1 = new Rectangle(10, 50, 50, 50);
            renderer.DrawBackground(e.Graphics, rectangle1);
            e.Graphics.DrawString("VisualStyleElement.ListView.Group.Normal",
                 this.Font, Brushes.Black, new Point(10, 10));
        }
        else
            e.Graphics.DrawString("This element is not defined in the current visual style.",
                 this.Font, Brushes.Black, new Point(10, 10));
    }