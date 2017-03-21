    void GetComments()
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo =
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");
        // Print the comments in a text box.
        textBox1.Text = "Comments: " + myFileVersionInfo.Comments;
    }