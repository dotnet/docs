    private void GetProductMinorPart()
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo =
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

        // Print the product minor part number.
        textBox1.Text = "Product minor part number: " + myFileVersionInfo.ProductMinorPart;
    }