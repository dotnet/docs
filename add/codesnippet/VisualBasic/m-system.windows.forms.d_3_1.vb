         ' String variable used to show message.   
         Dim myString As String = "Link color changed from: "
         ' Store current foreground color of selected cells.
         Dim myCurrentColor As Color = myDataGridTableStyle.LinkColor
         myString += myCurrentColor.ToString()
         ' Reset link color to default.
         myDataGridTableStyle.ResetLinkColor()
         myString += "  to "
         myString += myDataGridTableStyle.LinkColor.ToString()
         ' Show information about changes in color setting.  
         MessageBox.Show(myString, "Link line color information")