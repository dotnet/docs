         // String variable used to show message.
         String^ myString = "Selection backgound color changed from: ";

         // Store current foreground color of selected cells.
         Color myCurrentColor = myDataGrid->SelectionBackColor;
         myString = String::Concat( myString, myCurrentColor.ToString() );

         // Reset selection background color to default.
         myDataGrid->ResetSelectionBackColor();
         myString = String::Concat( myString, " to " );
         myString = String::Concat( myString, myDataGrid->SelectionBackColor.ToString() );

         // Show information about changes in color setting.  
         MessageBox::Show( myString, "Selection background color information" );