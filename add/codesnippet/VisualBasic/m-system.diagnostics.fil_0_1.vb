    Private Sub GetFileVersion2()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print all the version information.
        textBox1.Text = myFileVersionInfo.ToString()
    End Sub 'GetFileVersion2