    private void AddExample(PaintEventArgs e)
    {
        PointF point1 = new PointF(120.5F, 120F);
        SizeF size1 = new SizeF(20.5F, 20.5F);
        RectangleF rect1 = new RectangleF(point1, size1);
        PointF point2 = new PointF(rect1.Right, rect1.Bottom);
        if (point2 != PointF.Add(point1, size1))
            e.Graphics.DrawString("They are not equal", this.Font, Brushes.Red, rect1);
        else
            e.Graphics.DrawString("They are equal", this.Font, Brushes.Black, rect1);

    }