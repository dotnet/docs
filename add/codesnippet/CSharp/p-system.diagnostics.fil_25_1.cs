    private void GetProductPrivatePart()
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo =
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

        // Print the product private part number.
        textBox1.Text = "Product private part number: " + myFileVersionInfo.ProductPrivatePart;
    }