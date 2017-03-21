    private void GetIsPatched()
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo =
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

        // Print whether the file has a patch installed.
        textBox1.Text = "File has patch installed: " + myFileVersionInfo.IsPatched;
    }