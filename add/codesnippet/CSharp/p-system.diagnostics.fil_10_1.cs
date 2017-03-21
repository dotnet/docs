    private void GetProductBuildPart()
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo =
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

        // Print the product build part number.
        textBox1.Text = "Product build part number: " + myFileVersionInfo.ProductBuildPart;
    }