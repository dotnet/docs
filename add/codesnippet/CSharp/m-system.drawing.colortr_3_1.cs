        public void FromWin32_Example(PaintEventArgs e)
        {
            // Create an integer representation of a Windows color.
            int winColor = 0xA000;
                     
            // Translate winColor to a GDI+ Color structure.
            Color myColor = ColorTranslator.FromWin32(winColor);
                     
            // Fill a rectangle with myColor.
            e.Graphics.FillRectangle( new SolidBrush(myColor), 0, 0, 
                100, 100);
                
                
                
                
        }