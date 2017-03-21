        For Each foundDirectory In My.Computer.FileSystem.GetDirectories(
              My.Computer.FileSystem.SpecialDirectories.MyDocuments,
              True, "*Logs*")

            ListBox1.Items.Add(foundDirectory)
        Next