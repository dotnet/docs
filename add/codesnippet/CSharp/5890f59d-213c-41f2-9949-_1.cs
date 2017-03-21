        private void BeginContainerRectangleF(PaintEventArgs e)
        {
            // Define transformation for container.
            RectangleF srcRect = new RectangleF(0.0F, 0.0F, 200.0F, 200.0F);
            RectangleF destRect = new RectangleF(100.0F, 100.0F, 150.0F, 150.0F);
                     
            // Begin graphics container.
            GraphicsContainer containerState = e.Graphics.BeginContainer(
                destRect, srcRect,
                GraphicsUnit.Pixel);
                     
            // Fill red rectangle in container.
            e.Graphics.FillRectangle(new SolidBrush(Color.Red), 0.0F, 0.0F, 200.0F, 200.0F);
                     
            // End graphics container.
            e.Graphics.EndContainer(containerState);
                     
            // Fill untransformed rectangle with green.
            e.Graphics.FillRectangle(new SolidBrush(Color.Green), 0.0F, 0.0F, 200.0F, 200.0F);
        }