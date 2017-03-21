   void AddDataGridTableStyle()
   {
      // Create a new DataGridTableStyle and set MappingName.
      DataGridTableStyle^ myGridStyle = gcnew DataGridTableStyle;
      myGridStyle->MappingName = "Customers";
      
      // Create two DataGridColumnStyle objects.
      DataGridColumnStyle^ colStyle1 = gcnew DataGridTextBoxColumn;
      colStyle1->MappingName = "firstName";
      DataGridColumnStyle^ colStyle2 = gcnew DataGridBoolColumn;
      colStyle2->MappingName = "Current";
      
      // Add column styles to table style.
      myGridStyle->GridColumnStyles->Add( colStyle1 );
      myGridStyle->GridColumnStyles->Add( colStyle2 );
      
      // Add the grid style to the GridStylesCollection.
      myDataGrid->TableStyles->Add( myGridStyle );
   }