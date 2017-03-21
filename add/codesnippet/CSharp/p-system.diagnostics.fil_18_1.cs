    private void GetFileDescription()
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo =
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

        // Print the file description.
        textBox1.Text = "File description: " + myFileVersionInfo.FileDescription;
    }