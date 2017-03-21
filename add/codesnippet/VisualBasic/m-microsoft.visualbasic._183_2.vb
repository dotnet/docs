        For Each foundFile As String In My.Computer.FileSystem.GetFiles(
                 My.Computer.FileSystem.SpecialDirectories.MyDocuments,
                 FileIO.SearchOption.SearchTopLevelOnly, "*.txt")
            ListBox1.Items.Add(foundFile)
        Next