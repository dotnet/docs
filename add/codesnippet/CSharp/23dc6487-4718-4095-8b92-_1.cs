    private void OpSubtractionExample(PaintEventArgs e)
    {
        PointF point1 = new PointF(120.5F, 120F);
        SizeF size1 = new SizeF(20.5F, 20.5F);
        PointF point2 = point1 - size1;
        e.Graphics.DrawLine(Pens.Blue, point1, point2);
    }