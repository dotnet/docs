   void AddStyleRange()
   {
      
      // Create two DataGridColumnStyle objects.
      DataGridColumnStyle^ col1 = gcnew DataGridTextBoxColumn;
      col1->MappingName = "FirstName";
      DataGridColumnStyle^ col2 = gcnew DataGridBoolColumn;
      col2->MappingName = "Current";
      
      // Create an array and use AddRange to add to collection.
      array<DataGridColumnStyle^>^cols = {col1,col2};
      dataGrid1->TableStyles[ 0 ]->GridColumnStyles->AddRange( cols );
   }