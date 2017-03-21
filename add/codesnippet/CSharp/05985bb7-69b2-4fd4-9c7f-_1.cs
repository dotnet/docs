        public void ScaleExample(PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Blue, 1);
            Pen myPen2 = new Pen(Color.Red, 1);
                     
            // Draw the rectangle to the screen before applying the
            // transform.
            e.Graphics.DrawRectangle(myPen, 50, 50, 100, 100);
                     
            // Create a matrix and scale it.
            Matrix myMatrix = new Matrix();
            myMatrix.Scale(3, 2, MatrixOrder.Append);
                     
            // Draw the rectangle to the screen again after applying the
            // transform.
            e.Graphics.Transform = myMatrix;
            e.Graphics.DrawRectangle(myPen2, 50, 50, 100, 100);
        }