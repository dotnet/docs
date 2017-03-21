    private void GetIsPrivateBuild()
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo =
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

        // Print whether the version is a private build.
        textBox1.Text = "Version is a private build: " + myFileVersionInfo.IsPrivateBuild;
    }