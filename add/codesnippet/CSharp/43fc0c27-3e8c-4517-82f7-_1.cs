    public void DrawVisualStyleElementTabTabItemRightEdge4(PaintEventArgs e)
    {
        if (VisualStyleRenderer.IsElementDefined(
            VisualStyleElement.Tab.TabItemRightEdge.Disabled))
        {
            VisualStyleRenderer renderer =
                 new VisualStyleRenderer(VisualStyleElement.Tab.TabItemRightEdge.Disabled);
            Rectangle rectangle1 = new Rectangle(10, 50, 50, 50);
            renderer.DrawBackground(e.Graphics, rectangle1);
            e.Graphics.DrawString("VisualStyleElement.Tab.TabItemRightEdge.Disabled",
                 this.Font, Brushes.Black, new Point(10, 10));
        }
        else
            e.Graphics.DrawString("This element is not defined in the current visual style.",
                 this.Font, Brushes.Black, new Point(10, 10));
    }