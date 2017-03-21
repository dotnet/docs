         // String variable used to show message.   
         string myString = "Fore color changed from: ";
         // Store current foreground color of selected cells.
         Color myCurrentColor = customersStyle.SelectionForeColor;
         myString += myCurrentColor.ToString();
         // Reset selection fore color to default.
         customersStyle.ResetSelectionForeColor();
         myString += "  to ";
         myString += customersStyle.SelectionForeColor.ToString();
         // Show information about changes in color setting.  
         MessageBox.Show(myString, "Selection fore color information");