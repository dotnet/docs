    private void GetPrivateBuild()
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo =
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

        // Print the private build number.
        textBox1.Text = "Private build number: " + myFileVersionInfo.PrivateBuild;
    }