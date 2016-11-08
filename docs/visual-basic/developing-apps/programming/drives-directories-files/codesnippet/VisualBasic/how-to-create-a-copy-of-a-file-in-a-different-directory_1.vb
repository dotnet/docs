        ' Copy the file to a new location without overwriting existing file.
        My.Computer.FileSystem.CopyFile(
            "C:\UserFiles\TestFiles\testFile.txt",
            "C:\UserFiles\TestFiles2\testFile.txt")

        ' Copy the file to a new folder, overwriting existing file.
        My.Computer.FileSystem.CopyFile(
            "C:\UserFiles\TestFiles\testFile.txt",
            "C:\UserFiles\TestFiles2\testFile.txt",
            Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
            Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)

        ' Copy the file to a new folder and rename it.
        My.Computer.FileSystem.CopyFile(
            "C:\UserFiles\TestFiles\testFile.txt",
            "C:\UserFiles\TestFiles2\NewFile.txt",
            Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
            Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)