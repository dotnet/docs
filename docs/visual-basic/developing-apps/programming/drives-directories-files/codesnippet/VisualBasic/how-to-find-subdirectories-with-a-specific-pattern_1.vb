        For Each foundDirectory As String In
               My.Computer.FileSystem.GetDirectories(
                   My.Computer.FileSystem.SpecialDirectories.MyDocuments,
                   FileIO.SearchOption.SearchTopLevelOnly,
                   "*Logs*")

            ListBox1.Items.Add(foundDirectory)
        Next