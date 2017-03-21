        private void CopyPixels4(PaintEventArgs e)
        {
            e.Graphics.CopyFromScreen(0, 0, 20, 20, new Size(160, 160), 
                CopyPixelOperation.SourceInvert);
        }