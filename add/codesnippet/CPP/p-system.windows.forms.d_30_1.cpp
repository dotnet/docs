private:
   void BindToDataView( DataGrid^ myGrid )
   {
      // Create a DataView using the DataTable.
      DataTable^ myTable = gcnew DataTable( "Suppliers" );
      // Insert code to create and populate columns.
      DataView^ myDataView = gcnew DataView( myTable );
      myGrid->DataSource = myDataView;
   }

   void BindToDataSet( DataGrid^ myGrid )
   {
      // Create a DataSet.
      DataSet^ myDataSet = gcnew DataSet( "myDataSet" );
      // Insert code to populate DataSet with several tables.
      myGrid->DataSource = myDataSet;
      // Use the DataMember property to specify the DataTable.
      myGrid->DataMember = "Suppliers";
   }

   DataView^ GetDataViewFromDataSource()
   {
      // Create a DataTable variable, and set it to the DataSource.
      DataView^ myDataView;
      myDataView = (DataView^)(dataGrid1->DataSource);
      return myDataView;
   }

   DataSet^ GetDataSetFromDataSource()
   {
      // Create a DataSet variable, and set it to the DataSource.
      DataSet^ myDataSet;
      myDataSet = (DataSet^)(dataGrid1->DataSource);
      return myDataSet;
   }