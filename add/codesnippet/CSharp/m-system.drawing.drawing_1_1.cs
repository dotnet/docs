        public void TransformPointsExample(PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Blue, 1);
            Pen myPen2 = new Pen(Color.Red, 1);
                     
            // Create an array of points.
            Point[] myArray =
                     {
                         new Point(20, 20),
                         new Point(120, 20),
                         new Point(120, 120),
                         new Point(20, 120),
                         new Point(20,20)
                     };
                     
            // Draw the Points to the screen before applying the
            // transform.
            e.Graphics.DrawLines(myPen, myArray);
                     
            // Create a matrix and scale it.
            Matrix myMatrix = new Matrix();
            myMatrix.Scale(3, 2, MatrixOrder.Append);
            myMatrix.TransformPoints(myArray);
                     
            // Draw the Points to the screen again after applying the
            // transform.
            e.Graphics.DrawLines(myPen2, myArray);
        }