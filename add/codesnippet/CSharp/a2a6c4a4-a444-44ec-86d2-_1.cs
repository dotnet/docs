        public void FillClosedCurvePointFillModeTension(PaintEventArgs e)
        {
                     
            // Create solid brush.
            SolidBrush redBrush = new SolidBrush(Color.Red);
                     
            // Create array of points for curve.
            Point point1 = new Point(100, 100);
            Point point2 = new Point(200,  50);
            Point point3 = new Point(250, 200);
            Point point4 = new Point(50, 150);
            Point[] points = {point1, point2, point3, point4};
                     
            // Set fill mode.
            FillMode newFillMode = FillMode.Winding;
                     
            // Set tension.
            float tension = 1.0F;
                     
            // Fill curve on screen.
            e.Graphics.FillClosedCurve(redBrush, points, newFillMode, tension);
        }