        private void FlattenExample(PaintEventArgs e)
        {
            GraphicsPath myPath = new GraphicsPath();
            Matrix translateMatrix = new Matrix();
            translateMatrix.Translate(0, 10);
            Point point1 = new Point(20, 100);
            Point point2 = new Point(70, 10);
            Point point3 = new Point(130, 200);
            Point point4 = new Point(180, 100);
            Point[] points = {point1, point2, point3, point4};
            myPath.AddCurve(points);
            e.Graphics.DrawPath(new Pen(Color.Black, 2), myPath);
            myPath.Flatten(translateMatrix, 10f);
            e.Graphics.DrawPath(new Pen(Color.Red, 1), myPath);
        }