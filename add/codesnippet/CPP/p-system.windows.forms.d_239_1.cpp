   private:
      void Create_Table()
      {
         // Create a DataSet.
         myDataSet = gcnew DataSet( "myDataSet" );

         // Create DataTable.
         DataTable^ myCustomerTable = gcnew DataTable( "Customers" );

         // Create two columns, and add to the table.
         DataColumn^ CustID = gcnew DataColumn( "CustID",int::typeid );
         DataColumn^ CustName = gcnew DataColumn( "CustName" );
         myCustomerTable->Columns->Add( CustID );
         myCustomerTable->Columns->Add( CustName );
         DataRow^ newRow1;

         // Create three customers in the Customers Table.
         for ( int i = 1; i < 3; i++ )
         {
            newRow1 = myCustomerTable->NewRow();
            newRow1[ "custID" ] = i;

            // Add row to the Customers table.
            myCustomerTable->Rows->Add( newRow1 );
         }
         myCustomerTable->Rows[ 0 ][ "custName" ] = "Alpha";
         myCustomerTable->Rows[ 1 ][ "custName" ] = "Beta";

         // Add table to DataSet.
         myDataSet->Tables->Add( myCustomerTable );
         dataGrid1->SetDataBinding( myDataSet, "Customers" );
         myTableStyle = gcnew DataGridTableStyle;
         myTableStyle->MappingName = "Customers";
         myTableStyle->ForeColor = Color::DarkMagenta;
         dataGrid1->TableStyles->Add( myTableStyle );
      }

      // Set table's forecolor.
      void OnForeColor_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         dataGrid1->TableStyles->Clear();
         String^ str = dynamic_cast<String^>(myComboBox->SelectedItem);
         if ( str->Equals( "Green" ) )
                  myTableStyle->ForeColor = Color::Green;
         else
         if ( str->Equals( "Red" ) )
                  myTableStyle->ForeColor = Color::Red;
         else
         if ( str->Equals( "Violet" ) )
                  myTableStyle->ForeColor = Color::Violet;

         dataGrid1->TableStyles->Add( myTableStyle );
      }