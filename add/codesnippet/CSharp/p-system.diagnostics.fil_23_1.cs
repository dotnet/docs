    private void GetInternalName()
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo =
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

        // Print the internal name.
        textBox1.Text = "Internal name: " + myFileVersionInfo.InternalName;
    }