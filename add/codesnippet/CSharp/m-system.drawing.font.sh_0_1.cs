        private void ConstructFontWithString(PaintEventArgs e)
        {
            Font font1 = new Font("Arial", 20);
            e.Graphics.DrawString("Arial Font", font1, Brushes.Red, new PointF(10, 10));
        }