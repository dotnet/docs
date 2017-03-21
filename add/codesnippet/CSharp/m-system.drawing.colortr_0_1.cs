        public void FromOle_Example(PaintEventArgs e)
        {
            // Create an integer representation of an OLE color.
            int oleColor = 0xFF00;
                     
            // Translate oleColor to a GDI+ Color structure.
            Color myColor = ColorTranslator.FromOle(oleColor);
                     
            // Fill a rectangle with myColor.
            e.Graphics.FillRectangle( new SolidBrush(myColor), 0, 0, 
                100, 100);
        }