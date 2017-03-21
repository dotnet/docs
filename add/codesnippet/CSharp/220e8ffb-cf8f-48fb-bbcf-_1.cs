    private void StaticRectangleIntersection(PaintEventArgs e)
    {
        Rectangle rectangle1 = new Rectangle(50, 50, 200, 100);
        Rectangle rectangle2 = new Rectangle(70, 20, 100, 200);
        Rectangle rectangle3 = new Rectangle();

        e.Graphics.DrawRectangle(Pens.Black, rectangle1);
        e.Graphics.DrawRectangle(Pens.Red, rectangle2);

        if (rectangle1.IntersectsWith(rectangle2))
        {
            rectangle3 = Rectangle.Intersect(rectangle1, rectangle2);
            if (!rectangle3.IsEmpty)
            {
                e.Graphics.FillRectangle(Brushes.Green, rectangle3);
            }
        }
    }