        private void DrawCurvePointSegmentTension(PaintEventArgs e)
        {

            // Create pens.
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.Green, 3);

            // Create points that define curve.
            Point point1 = new Point(50, 50);
            Point point2 = new Point(100, 25);
            Point point3 = new Point(200, 5);
            Point point4 = new Point(250, 50);
            Point point5 = new Point(300, 100);
            Point point6 = new Point(350, 200);
            Point point7 = new Point(250, 250);
            Point[] curvePoints = {point1, point2, point3, point4, point5, point6, point7};

            // Draw lines between original points to screen.
            e.Graphics.DrawLines(redPen, curvePoints);

            // Create offset, number of segments, and tension.
            int offset = 2;
            int numSegments = 4;
            float tension = 1.0F;

            // Draw curve to screen.
            e.Graphics.DrawCurve(greenPen, curvePoints, offset, numSegments, tension);
        }