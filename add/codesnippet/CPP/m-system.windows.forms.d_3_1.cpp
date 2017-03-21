         // String variable used to show message.
         String^ myString = "Link color changed from: ";

         // Store current foreground color of selected cells.
         Color myCurrentColor = myDataGridTableStyle->LinkColor;
         myString = String::Concat( myString, myCurrentColor );

         // Reset link color to default.
         myDataGridTableStyle->ResetLinkColor();
         myString = String::Concat( myString, " to " );
         myString = String::Concat( myString, myDataGridTableStyle->LinkColor );

         // Show information about changes in color setting.
         MessageBox::Show( myString, "Link line color information" );