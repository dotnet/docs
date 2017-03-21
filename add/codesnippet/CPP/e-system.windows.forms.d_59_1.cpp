   void SetUp()
   {
      // Create a DataSet with a table.
      MakeDataSet();

      // Bind the DataGrid to the DataSet.
      myDataGrid->SetDataBinding( myDataSet, "Orders" );
      myTableStyle = gcnew DataGridTableStyle;

      // Map 'DataGridTableStyle' instance to the DataTable.
      myTableStyle->MappingName = "Orders";

      // Add EventHandler function for 'PreferredRowHeightChanged' Event.
      myTableStyle->PreferredRowHeightChanged += gcnew EventHandler( this, &MyDataForm::RowHeight_Changed );
   }

   // Called when the PreferredRowHeight property of myTableStyle is modified
   void RowHeight_Changed( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      MessageBox::Show( "PreferredRowHeight property is changed" );
   }