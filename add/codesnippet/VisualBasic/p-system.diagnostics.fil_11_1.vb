    Private Sub GetProductMinorPart()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the product minor part number.
        textBox1.Text = "Product minor part number: " & myFileVersionInfo.ProductMinorPart
    End Sub 'GetProductMinorPart