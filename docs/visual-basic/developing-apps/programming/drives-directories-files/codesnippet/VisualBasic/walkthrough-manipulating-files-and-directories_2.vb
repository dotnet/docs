    Private Sub ListFiles(ByVal folderPath As String)
        filesListBox.Items.Clear()

        Dim fileNames = My.Computer.FileSystem.GetFiles(
            folderPath, FileIO.SearchOption.SearchTopLevelOnly, "*.txt")

        For Each fileName As String In fileNames
            filesListBox.Items.Add(fileName)
        Next
    End Sub