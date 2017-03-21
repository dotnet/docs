    Private Sub GetIsPrivateBuild()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print whether the version is a private build.
        textBox1.Text = "Version is a private build: " & myFileVersionInfo.IsPrivateBuild
    End Sub 'GetIsPrivateBuild