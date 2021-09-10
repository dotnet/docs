//<Snippet19>
using System;

public class TestCopy{

    public void CopyDirectory()
    {
        //<Snippet20>
        // Duplicate a directory
        Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(
            @"C:\original_directory",
            @"C:\copy_of_original_directory");
        //</Snippet20>
    }
}
