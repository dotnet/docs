         // String variable used to show message.
         String^ myString = "Fore color changed from: ";

         // Store current foreground color of selected cells.
         Color myCurrentColor = customersStyle->SelectionForeColor;
         myString = String::Concat( myString, myCurrentColor );

         // Reset selection fore color to default.
         customersStyle->ResetSelectionForeColor();
         myString = String::Concat( myString, "  to " );
         myString = String::Concat( myString, customersStyle->SelectionForeColor );

         // Show information about changes in color setting.
         MessageBox::Show( myString, "Selection fore color information" );