            ' String variable used to show message.
            Dim myString As String = "Selection backgound color changed from: "
            ' Store current foreground color of selected cells.
            Dim myCurrentColor As Color = myDataGrid.SelectionBackColor
            myString += myCurrentColor.ToString()
            ' Reset selection background color to default.
            myDataGrid.ResetSelectionBackColor()
            myString += "  to "
            myString += myDataGrid.SelectionBackColor.ToString()
            ' Show information about changes in color setting.  
            MessageBox.Show(myString, "Selection background color information")