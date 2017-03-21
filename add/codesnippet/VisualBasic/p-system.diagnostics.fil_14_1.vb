    Private Sub GetIsSpecialBuild()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print whether the file is a special build.
        textBox1.Text = "File is a special build: " & myFileVersionInfo.IsSpecialBuild
    End Sub 'GetIsSpecialBuild