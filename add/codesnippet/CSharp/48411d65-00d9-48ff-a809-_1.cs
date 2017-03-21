        public void TranslateExample(PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Blue, 1);
            Pen myPen2 = new Pen(Color.Red, 1);
                     
            // Draw a rectangle to the screen before applying the
            // transform.
            e.Graphics.DrawRectangle(myPen, 20, 20, 100, 50);
                     
            // Create a matrix and translate it.
            Matrix myMatrix = new Matrix();
            myMatrix.Translate(100, 100, MatrixOrder.Append);
                     
            // Draw the Points to the screen again after applying the
            // transform.
            e.Graphics.Transform = myMatrix;
            e.Graphics.DrawRectangle(myPen2, 20, 20, 100, 50);
        }