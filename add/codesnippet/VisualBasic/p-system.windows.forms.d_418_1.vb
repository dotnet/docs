         ' Creates a common color dialog box.
         Dim myColorDialog As New ColorDialog()
         myColorDialog.AllowFullOpen = False
         ' Allow the user to get help. 
         myColorDialog.ShowHelp = True
         ' Set the initial color select to the current color.
         myColorDialog.Color = customersStyle.SelectionForeColor
         ' Show color dialog box.
         myColorDialog.ShowDialog()
         ' Set selection fore color to selected color.
         customersStyle.SelectionForeColor = myColorDialog.Color