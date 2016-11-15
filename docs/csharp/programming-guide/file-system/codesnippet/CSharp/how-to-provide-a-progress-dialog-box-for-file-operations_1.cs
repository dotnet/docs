        // The following using directive requires a project reference to Microsoft.VisualBasic.
        using Microsoft.VisualBasic.FileIO;

        class FileProgress
        {
            static void Main()
            {
                // Specify the path to a folder that you want to copy. If the folder is small, 
                // you won't have time to see the progress dialog box.
                string sourcePath = @"C:\Windows\symbols\";
                // Choose a destination for the copied files.
                string destinationPath = @"C:\TestFolder";

                FileSystem.CopyDirectory(sourcePath, destinationPath,
                    UIOption.AllDialogs);
            }
        }