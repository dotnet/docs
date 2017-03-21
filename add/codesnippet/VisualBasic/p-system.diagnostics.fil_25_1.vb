    Private Sub GetProductPrivatePart()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the product private part number.
        textBox1.Text = "Product private part number: " & myFileVersionInfo.ProductPrivatePart
    End Sub 'GetProductPrivatePart