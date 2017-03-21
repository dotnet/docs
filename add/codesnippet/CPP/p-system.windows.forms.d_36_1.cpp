         int myPreferredRowHeight = Convert::ToInt32( myTextBox->Text->Trim() );
         if ( myPreferredRowHeight < 18 || myPreferredRowHeight > 134 )
         {
            MessageBox::Show( "Enter the height between 18 and 134" );
            return;
         }

         // Set the 'PreferredRowHeight' property of DataGridTableStyle instance.
         myTableStyle->PreferredRowHeight = myPreferredRowHeight;

         // Add the DataGridTableStyle instance to the GridTableStylesCollection.
         myDataGrid->TableStyles->Add( myTableStyle );