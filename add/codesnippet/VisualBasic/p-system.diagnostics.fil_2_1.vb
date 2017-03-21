    Private Sub GetFileMinorPart()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the file minor part number.
        textBox1.Text = "File minor part number: " & myFileVersionInfo.FileMinorPart
    End Sub 'GetFileMinorPart