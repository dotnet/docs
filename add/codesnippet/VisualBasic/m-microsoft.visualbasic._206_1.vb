        For Each foundFile In My.Computer.FileSystem.GetFiles(
                My.Computer.FileSystem.SpecialDirectories.MyDocuments)
            ListBox1.Items.Add(foundFile)
        Next