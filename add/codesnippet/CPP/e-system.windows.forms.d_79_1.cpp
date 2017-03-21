   private:
      void Create_Table()
      {
         // Create DataSet.
         myDataSet = gcnew DataSet( "myDataSet" );

         // Create DataTable.
         DataTable^ myCustomerTable = gcnew DataTable( "Customers" );

         // Create two columns, and add them to the table.
         DataColumn^ CustID = gcnew DataColumn( "CustID",int::typeid );
         DataColumn^ CustName = gcnew DataColumn( "CustName" );
         myCustomerTable->Columns->Add( CustID );
         myCustomerTable->Columns->Add( CustName );

         // Add table to DataSet.
         myDataSet->Tables->Add( myCustomerTable );
         dataGrid1->SetDataBinding( myDataSet, "Customers" );
         myTableStyle = gcnew DataGridTableStyle;
         myTableStyle->MappingName = "Customers";
         myTableStyle->HeaderBackColorChanged += gcnew System::EventHandler( this, &Form1::HeaderBackColorChangedHandler );
         myTableStyle->HeaderForeColorChanged += gcnew System::EventHandler( this, &Form1::HeaderForeColorChangedHandler );
      }

      // Change header background color.
      void OnHeaderBackColor_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         dataGrid1->TableStyles->Clear();
         String^ str = dynamic_cast<String^>(comboBox1->SelectedItem);
         if ( str->Equals( "Red" ) )
                  myTableStyle->ForeColor = Color::Red;
         else
         if ( str->Equals( "Yellow" ) )
                  myTableStyle->ForeColor = Color::Yellow;
         else
         if ( str->Equals( "Blue" ) )
                  myTableStyle->ForeColor = Color::Blue;

         myTableStyle->AlternatingBackColor = Color::LightGray;
         dataGrid1->TableStyles->Add( myTableStyle );
      }

      void HeaderBackColorChangedHandler( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         MessageBox::Show( String::Concat( "Changed Header Background color to : ", comboBox1->SelectedItem ), "Success", MessageBoxButtons::OK, MessageBoxIcon::Exclamation );
      }