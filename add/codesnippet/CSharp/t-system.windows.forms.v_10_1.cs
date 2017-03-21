    public void DrawVisualStyleElement_Spin_UpHorizontal1(PaintEventArgs e)
    {
        if (VisualStyleRenderer.IsElementDefined(
            VisualStyleElement.Spin.UpHorizontal.Normal))
        {
            VisualStyleRenderer renderer =
                 new VisualStyleRenderer(VisualStyleElement.Spin.UpHorizontal.Normal);
            Rectangle rectangle1 = new Rectangle(10, 50, 50, 50);
            renderer.DrawBackground(e.Graphics, rectangle1);
            e.Graphics.DrawString("VisualStyleElement.Spin.UpHorizontal.Normal",
                 this.Font, Brushes.Black, new Point(10, 10));
        }
        else
            e.Graphics.DrawString("This element is not defined in the current visual style.",
                 this.Font, Brushes.Black, new Point(10, 10));
    }