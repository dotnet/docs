    private void InstanceRectangleIntersection(PaintEventArgs e)
    {

        Rectangle rectangle1 = new Rectangle(50, 50, 200, 100);
        Rectangle rectangle2 = new Rectangle(70, 20, 100, 200);
    
        e.Graphics.DrawRectangle(Pens.Black, rectangle1);
        e.Graphics.DrawRectangle(Pens.Red, rectangle2);

        if (rectangle1.IntersectsWith(rectangle2))
        {
            rectangle1.Intersect(rectangle2);
            if (!rectangle1.IsEmpty)
            {
                e.Graphics.FillRectangle(Brushes.Green, rectangle1);
            }
        }
    }