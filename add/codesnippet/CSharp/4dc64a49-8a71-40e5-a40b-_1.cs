        public void RotateExample(PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Blue, 1);
            Pen myPen2 = new Pen(Color.Red, 1);
                     
            // Draw the rectangle to the screen before applying the transform.
            e.Graphics.DrawRectangle(myPen, 150, 50, 200, 100);
                     
            // Create a matrix and rotate it 45 degrees.
            Matrix myMatrix = new Matrix();
            myMatrix.Rotate(45, MatrixOrder.Append);
                     
            // Draw the rectangle to the screen again after applying the
                     
            // transform.
            e.Graphics.Transform = myMatrix;
            e.Graphics.DrawRectangle(myPen2, 150, 50, 200, 100);
        }