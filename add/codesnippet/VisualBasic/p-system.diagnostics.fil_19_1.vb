    Private Sub GetFileName()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the file name.
        textBox1.Text = "File name: " & myFileVersionInfo.FileName
    End Sub 'GetFileName