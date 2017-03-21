        public void Clone_Example(PaintEventArgs e)
        {
                     
            // Create a TextureBrush object.
            TextureBrush tBrush = new TextureBrush(new Bitmap("texture.jpg"));
                     
            // Create an exact copy of tBrush.
            TextureBrush cloneBrush = (TextureBrush)tBrush.Clone();
                     
            // Fill a rectangle with cloneBrush.
            e.Graphics.FillRectangle(cloneBrush, 0, 0, 100, 100);
        }