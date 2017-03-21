         ' String variable used to show message.   
         Dim myString As String = "Fore color changed from: "
         ' Store current foreground color of selected cells.
         Dim myCurrentColor As Color = customersStyle.SelectionForeColor
         myString += myCurrentColor.ToString()
         ' Reset selection fore color to default.
         customersStyle.ResetSelectionForeColor()
         myString += "  to "
         myString += customersStyle.SelectionForeColor.ToString()
         ' Show information about changes in color setting.  
         MessageBox.Show(myString, "Selection fore color information")