        private void TranslateTransformAngle(PaintEventArgs e)
        {

            // Set world transform of graphics object to rotate.
            e.Graphics.RotateTransform(30.0F);

            // Then to translate, prepending to world transform.
            e.Graphics.TranslateTransform(100.0F, 0.0F);

            // Draw translated, rotated ellipse to screen.
            e.Graphics.DrawEllipse(new Pen(Color.Blue, 3), 0, 0, 200, 80);
        }