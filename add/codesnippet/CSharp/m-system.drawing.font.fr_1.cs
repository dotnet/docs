        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern IntPtr GetStockObject(int fnObject);
        public void FromHfont_Example(PaintEventArgs e)
        {
                     
            // Get a handle for a GDI font.
            IntPtr hFont = GetStockObject(0);
                     
            // Create a Font object from hFont.
            Font hfontFont = Font.FromHfont(hFont);
                     
            // Use hfontFont to draw text to the screen.
            e.Graphics.DrawString(
                "This font is from a GDI HFONT", hfontFont,Brushes.Black, 
                0, 0);
               
                
                
                
        }