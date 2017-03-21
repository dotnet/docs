    Private Sub GetPrivateBuild()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the private build number.
        textBox1.Text = "Private build number: " & myFileVersionInfo.PrivateBuild
    End Sub 'GetPrivateBuild