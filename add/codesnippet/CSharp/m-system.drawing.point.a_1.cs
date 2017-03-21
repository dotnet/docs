        private void AddPoint(PaintEventArgs e)
        {
            Point point1 = new Point(10, 10);
            Point point2 = Point.Add(point1, new Size(250,0));
            e.Graphics.DrawLine(Pens.Red, point1, point2);
        }