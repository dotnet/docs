    Private Sub GetSpecialBuild()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the special build information.
        textBox1.Text = "Special build information: " & myFileVersionInfo.SpecialBuild
    End Sub 'GetSpecialBuild