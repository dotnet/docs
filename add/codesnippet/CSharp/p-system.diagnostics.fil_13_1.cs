    private void GetFilePrivatePart()
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo =
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

        // Print the file private part number.
        textBox1.Text = "File private part number: " + myFileVersionInfo.FilePrivatePart;
    }