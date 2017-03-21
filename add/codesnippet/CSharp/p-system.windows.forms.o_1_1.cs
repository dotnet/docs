    private FileStream OpenFile()
    {
        // Displays an OpenFileDialog and shows the read/only files.

        OpenFileDialog dlgOpenFile = new OpenFileDialog();
        dlgOpenFile.ShowReadOnly = true;


        if(dlgOpenFile.ShowDialog() == DialogResult.OK)
        {

            // If ReadOnlyChecked is true, uses the OpenFile method to
            // open the file with read/only access.
            string path = null;

            try {
                if(dlgOpenFile.ReadOnlyChecked == true)
                {
                    return (FileStream)dlgOpenFile.OpenFile();
                }

                // Otherwise, opens the file with read/write access.
                else
                {
                    path = dlgOpenFile.FileName;
                    return new FileStream(path, System.IO.FileMode.Open,
                                System.IO.FileAccess.ReadWrite);
                }
            } catch (SecurityException ex)
                {
                    // The user lacks appropriate permissions to read files, discover paths, etc.
                    MessageBox.Show("Security error. Please contact your administrator for details.\n\n" +
                        "Error message: " + ex.Message + "\n\n" +
                        "Details (send to Support):\n\n" + ex.StackTrace
                    );
                }
                catch (Exception ex)
                {
                    // Could not load the image - probably related to Windows file system permissions.
                    MessageBox.Show("Cannot display the image: " + path.Substring(path.LastIndexOf('\\'))
                        + ". You may not have permission to read the file, or " +
                        "it may be corrupt.\n\nReported error: " + ex.Message);
                }
        }

        return null;
    }
