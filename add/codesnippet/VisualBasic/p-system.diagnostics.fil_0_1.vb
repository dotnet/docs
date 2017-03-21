    Private Sub GetOriginalName()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the original file name.
        textBox1.Text = "Original file name: " & myFileVersionInfo.OriginalFilename
    End Sub 'GetOriginalName