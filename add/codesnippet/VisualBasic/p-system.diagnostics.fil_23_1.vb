    Private Sub GetInternalName()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the internal name.
        textBox1.Text = "Internal name: " & myFileVersionInfo.InternalName
    End Sub 'GetInternalName