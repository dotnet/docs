    private void GetFileVersion2()
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo =
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

        // Print all the version information.
        textBox1.Text = myFileVersionInfo.ToString();
    }