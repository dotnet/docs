        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            ' List files in the folder.
            ListFiles(FolderBrowserDialog1.SelectedPath)
        End If