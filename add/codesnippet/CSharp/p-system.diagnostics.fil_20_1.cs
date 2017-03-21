    private void GetCompanyName()
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo =
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

        // Print the company name.
        textBox1.Text = "The company name: " + myFileVersionInfo.CompanyName;
    }