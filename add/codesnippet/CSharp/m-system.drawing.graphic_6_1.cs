        private void IsVisiblePoint(PaintEventArgs e)
        {

            // Set clip region.
            Region clipRegion = new Region(new Rectangle(50, 50, 100, 100));
            e.Graphics.SetClip(clipRegion, CombineMode.Replace);

            // Set up coordinates of points.
            int x1 = 100;
            int y1 = 100;
            int x2 = 200;
            int y2 = 200;
            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);

            // If point is visible, fill ellipse that represents it.
            if (e.Graphics.IsVisible(point1))
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), x1, y1, 10, 10);
            }
            if (e.Graphics.IsVisible(point2))
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Blue), x2, y2, 10, 10);
            }
        }