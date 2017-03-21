        private void FromImageImage(PaintEventArgs e)
        {

            // Create image.
            Image imageFile = Image.FromFile("SampImag.jpg");

            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(imageFile);

            // Alter image.
            newGraphics.FillRectangle(new SolidBrush(Color.Black), 100, 50, 100, 100);

            // Draw image to screen.
            e.Graphics.DrawImage(imageFile, new PointF(0.0F, 0.0F));

            // Dispose of graphics object.
            newGraphics.Dispose();
        }