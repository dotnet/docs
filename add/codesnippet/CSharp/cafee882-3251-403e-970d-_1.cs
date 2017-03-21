        private void ScaleTransformFloatMatrixOrder(PaintEventArgs e)
        {

            // Set world transform of graphics object to rotate.
            e.Graphics.RotateTransform(30.0F);

            // Then to scale, appending to world transform.
            e.Graphics.ScaleTransform(3.0F, 1.0F, MatrixOrder.Append);

            // Draw rotated, scaled rectangle to screen.
            e.Graphics.DrawRectangle(new Pen(Color.Blue, 3), 50, 0, 100, 40);
        }