        private void DrawImageUnscaled(PaintEventArgs e)
        {
            string filepath = @"C:\Documents and Settings\All Users\Documents\" + 
                @"My Pictures\Sample Pictures\Water Lilies.jpg";
            Bitmap bitmap1 = new Bitmap(filepath);
            e.Graphics.DrawImageUnscaledAndClipped(bitmap1, new Rectangle(10,10,250,250));
        }