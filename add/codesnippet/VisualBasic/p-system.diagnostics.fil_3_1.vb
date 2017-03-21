    Private Sub GetCopyright()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the copyright notice.
        textBox1.Text = "Copyright notice: " & myFileVersionInfo.LegalCopyright
    End Sub 'GetCopyright