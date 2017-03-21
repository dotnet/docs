    
    private void ShowColorConverter(PaintEventArgs e)
    {

        Color myColor = Color.PaleVioletRed;

        // Create the ColorConverter.
        System.ComponentModel.TypeConverter converter = 
            System.ComponentModel.TypeDescriptor.GetConverter(myColor);

        string colorAsString = converter.ConvertToString(Color.PaleVioletRed);
        e.Graphics.DrawString(colorAsString, this.Font,
            Brushes.PaleVioletRed, 50.0F, 50.0F);
    }