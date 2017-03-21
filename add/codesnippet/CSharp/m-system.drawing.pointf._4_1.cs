    private void SubtractExample(PaintEventArgs e)
    {
        PointF point1 = new PointF(120.5F, 120F);
        SizeF size1 = new SizeF(120.5F, 30.5F);
        PointF point2 = PointF.Subtract(point1, size1);
        e.Graphics.DrawLine(Pens.Blue, point1, point2);
    }