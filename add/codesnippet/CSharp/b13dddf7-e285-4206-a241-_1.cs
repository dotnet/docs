    public void DrawVisualStyleElementToolBarDropDownButton6(PaintEventArgs e)
    {
        if (VisualStyleRenderer.IsElementDefined(
            VisualStyleElement.ToolBar.DropDownButton.HotChecked))
        {
            VisualStyleRenderer renderer =
                 new VisualStyleRenderer(VisualStyleElement.ToolBar.DropDownButton.HotChecked);
            Rectangle rectangle1 = new Rectangle(10, 50, 50, 50);
            renderer.DrawBackground(e.Graphics, rectangle1);
            e.Graphics.DrawString("VisualStyleElement.ToolBar.DropDownButton.HotChecked",
                 this.Font, Brushes.Black, new Point(10, 10));
        }
        else
            e.Graphics.DrawString("This element is not defined in the current visual style.",
                 this.Font, Brushes.Black, new Point(10, 10));
    }