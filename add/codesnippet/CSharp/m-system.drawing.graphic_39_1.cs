        private void IsVisiblePointF(PaintEventArgs e)
        {

            // Set clip region.
            Region clipRegion = new Region(new Rectangle(50, 50, 100, 100));
            e.Graphics.SetClip(clipRegion, CombineMode.Replace);

            // Set up coordinates of points.
            float x1 = 100.0F;
            float y1 = 100.0F;
            float x2 = 200.0F;
            float y2 = 200.0F;
            PointF point1 = new PointF(x1, y1);
            PointF point2 = new PointF(x2, y2);

            // If point is visible, fill ellipse that represents it.
            if (e.Graphics.IsVisible(point1))
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), x1, y1, 10.0F, 10.0F);
            }
            if (e.Graphics.IsVisible(point2))
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Blue), x2, y2, 10.0F, 10.0F);
            }
        }