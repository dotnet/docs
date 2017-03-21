     private void GetIsPreRelease()
     {
         // Get the file version for the notepad.
         FileVersionInfo myFileVersionInfo =
             FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

         // Print whether the file is a prerelease version.
         textBox1.Text = "File is prerelease version " + myFileVersionInfo.IsPreRelease;
    }