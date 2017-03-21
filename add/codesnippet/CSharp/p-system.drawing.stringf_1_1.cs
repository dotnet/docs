    private void ShowHotKey(PaintEventArgs e)
    {

        // Declare the string with a keyboard shortcut.
        string text = "&Click Here";

        // Declare a new StringFormat.
        StringFormat format = new StringFormat();

        // Set the HotkeyPrefix property.
        format.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;

        // Draw the string.
        Brush theBrush = 
            SystemBrushes.FromSystemColor(SystemColors.Highlight);

        e.Graphics.DrawString(text, this.Font, theBrush, 30, 40, format);
    }