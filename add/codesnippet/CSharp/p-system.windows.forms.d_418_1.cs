         // Creates a common color dialog box.
         ColorDialog myColorDialog = new ColorDialog();
         myColorDialog.AllowFullOpen = false ;
         // Allow the user to get help. 
         myColorDialog.ShowHelp = true ;
         // Set the initial color select to the current color.
         myColorDialog.Color = customersStyle.SelectionForeColor; 
         // Show color dialog box.
         myColorDialog.ShowDialog();
         // Set selection fore color to selected color.
         customersStyle.SelectionForeColor = myColorDialog.Color;