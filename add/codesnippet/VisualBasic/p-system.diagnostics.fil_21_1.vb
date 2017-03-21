    Private Sub GetFileBuildPart()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the file build number.
        textBox1.Text = "File build number: " & myFileVersionInfo.FileBuildPart
    End Sub 'GetFileBuildPart