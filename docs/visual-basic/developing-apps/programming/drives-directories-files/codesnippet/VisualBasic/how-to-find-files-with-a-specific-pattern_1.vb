        For Each foundFile As String In My.Computer.FileSystem.GetFiles(
            My.Computer.FileSystem.SpecialDirectories.MyDocuments,
            Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.dll")

            Listbox1.Items.Add(foundFile)
        Next