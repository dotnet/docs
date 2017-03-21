        public void RotateAtExample(PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Blue, 1);
            Pen myPen2 = new Pen(Color.Red, 1);
            PointF rotatePoint = new PointF(150.0f, 50.0f);
                     
            // Draw the rectangle to the screen before applying the
            // transform.
            e.Graphics.DrawRectangle(myPen, 150, 50, 200, 100);
                     
            // Create a matrix and rotate it 45 degrees.
            Matrix myMatrix = new Matrix();
            myMatrix.RotateAt(45, rotatePoint, MatrixOrder.Append);
                     
            // Draw the rectangle to the screen again after applying the
            // transform.
            e.Graphics.Transform = myMatrix;
            e.Graphics.DrawRectangle(myPen2, 150, 50, 200, 100);
        }