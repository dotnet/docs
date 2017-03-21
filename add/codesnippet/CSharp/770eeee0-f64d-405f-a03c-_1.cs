        public void DrawStringFloat(PaintEventArgs e)
        {
                     
            // Create string to draw.
            String drawString = "Sample Text";
                     
            // Create font and brush.
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
                     
            // Create point for upper-left corner of drawing.
            float x = 150.0F;
            float y = 150.0F;
                     
            // Draw string to screen.
            e.Graphics.DrawString(drawString, drawFont, drawBrush, x, y);
        }