        If filesListBox.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a file.")
            Exit Sub
        End If

        ' Obtain the file path from the list box selection.
        Dim filePath = filesListBox.SelectedItem.ToString

        ' Verify that the file was not removed since the
        ' Browse button was clicked.
        If My.Computer.FileSystem.FileExists(filePath) = False Then
            MessageBox.Show("File Not Found: " & filePath)
            Exit Sub
        End If

        ' Obtain file information in a string.
        Dim fileInfoText As String = GetTextForOutput(filePath)

        ' Show the file information.
        MessageBox.Show(fileInfoText)