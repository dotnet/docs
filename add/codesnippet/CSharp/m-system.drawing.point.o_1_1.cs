        private void OffsetPoint(PaintEventArgs e)
        {
            Point point1 = new Point(10, 10);
            point1.Offset(50, 0);
            Point point2 = new Point(250, 10);
            e.Graphics.DrawLine(Pens.Red, point1, point2);
        }