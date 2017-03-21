private:
   System::Windows::Forms::DataGrid^ dataGrid1;

   void CreateDataGrid()
   {
      dataGrid1 = gcnew DataGrid;
      // Add the handler for the DataSourceChanged event.
      dataGrid1->DataSourceChanged += gcnew EventHandler(
         this, &Form1::DataGrid1_DataSourceChanged );
   }

   void DataGrid1_DataSourceChanged( Object^ sender, EventArgs^ /*e*/ )
   {
      DataGrid^ thisGrid = dynamic_cast<DataGrid^>(sender);
   }