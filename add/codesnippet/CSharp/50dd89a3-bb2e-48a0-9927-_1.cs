        private void MeasureStringSizeF(PaintEventArgs e)
        {

            // Set up string.
            string measureString = "Measure String";
            Font stringFont = new Font("Arial", 16);

            // Set maximum layout size.
            SizeF layoutSize = new SizeF(200.0F, 50.0F);

            // Measure string.
            SizeF stringSize = new SizeF();
            stringSize = e.Graphics.MeasureString(measureString, stringFont, layoutSize);

            // Draw rectangle representing size of string.
            e.Graphics.DrawRectangle(new Pen(Color.Red, 1), 0.0F, 0.0F, stringSize.Width, stringSize.Height);

            // Draw string to screen.
            e.Graphics.DrawString(measureString, stringFont, Brushes.Black, new PointF(0, 0));
        }