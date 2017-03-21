    Private Sub GetFileDescription()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the file description.
        textBox1.Text = "File description: " & myFileVersionInfo.FileDescription
    End Sub 'GetFileDescription