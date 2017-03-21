    private void GetFileMinorPart()
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo =
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

        // Print the file minor part number.
        textBox1.Text = "File minor part number: " + myFileVersionInfo.FileMinorPart;
    }