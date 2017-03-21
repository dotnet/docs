    Private Sub GetProductMajorPart()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the product major part number.
        textBox1.Text = "Product major part number: " & myFileVersionInfo.ProductMajorPart
    End Sub 'GetProductMajorPart