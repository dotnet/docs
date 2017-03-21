        private void CopyPixels1(PaintEventArgs e)
        {
            e.Graphics.CopyFromScreen(this.Location, 
                new Point(40, 40), new Size(100, 100));
        }