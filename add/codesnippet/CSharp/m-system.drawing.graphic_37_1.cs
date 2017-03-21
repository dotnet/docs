        private void RotateTransformAngle(PaintEventArgs e)
        {

            // Set world transform of graphics object to translate.
            e.Graphics.TranslateTransform(100.0F, 0.0F);

            // Then to rotate, prepending rotation matrix.
            e.Graphics.RotateTransform(30.0F);

            // Draw rotated, translated ellipse to screen.
            e.Graphics.DrawEllipse(new Pen(Color.Blue, 3), 0, 0, 200, 80);
        }