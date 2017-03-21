        private void BeginContainerRectangle(PaintEventArgs e)
        {
            // Define transformation for container.
            Rectangle srcRect = new Rectangle(0, 0, 200, 200);
            Rectangle destRect = new Rectangle(100, 100, 150, 150);
                     
            // Begin graphics container.
            GraphicsContainer containerState = e.Graphics.BeginContainer(
                destRect, srcRect,
                GraphicsUnit.Pixel);
                     
            // Fill red rectangle in container.
            e.Graphics.FillRectangle(new SolidBrush(Color.Red), 0, 0, 200, 200);
                     
            // End graphics container.
            e.Graphics.EndContainer(containerState);
                     
            // Fill untransformed rectangle with green.
            e.Graphics.FillRectangle(new SolidBrush(Color.Green), 0, 0, 200, 200);
        }