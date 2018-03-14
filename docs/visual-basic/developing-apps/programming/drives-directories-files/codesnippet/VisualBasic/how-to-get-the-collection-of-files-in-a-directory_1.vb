        For Each foundFile As String In My.Computer.FileSystem.GetFiles(
          My.Computer.FileSystem.SpecialDirectories.MyDocuments)

            listBox1.Items.Add(foundFile)
        Next