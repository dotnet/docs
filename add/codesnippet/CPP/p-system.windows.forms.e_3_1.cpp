private:
   void InitializeComponent()
   {
      
      // Standard control setup.
      //....
      // You set the DataSource to a data set, and the DataMember to a table.
      errorProvider1->DataSource = dataSet1;
      errorProvider1->DataMember = dataTable1->TableName;
      errorProvider1->ContainerControl = this;
      errorProvider1->BlinkRate = 200;
      
      //...
      // Since the ErrorProvider control does not have a visible component,
      // it does not need to be added to the form. 
   }


private:
   void buttonSave_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Checks for a bad post code.
      DataTable^ CustomersTable;
      CustomersTable = dataSet1->Tables[ "Customers" ];
      System::Collections::IEnumerator^ myEnum = (CustomersTable->Rows)->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         DataRow^ row = safe_cast<DataRow^>(myEnum->Current);
         if ( Convert::ToBoolean( row[ "PostalCodeIsNull" ] ) )
         {
            row->RowError = "The Customer details contain errors";
            row->SetColumnError( "PostalCode", "Postal Code required" );
         }
      }
   }