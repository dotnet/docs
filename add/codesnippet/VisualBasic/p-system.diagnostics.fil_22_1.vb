    Private Sub GetIsPreRelease()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print whether the file is a prerelease version.
        textBox1.Text = "File is prerelease version " & myFileVersionInfo.IsPreRelease
    End Sub 'GetIsPreRelease