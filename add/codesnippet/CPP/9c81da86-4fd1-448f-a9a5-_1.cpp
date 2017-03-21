      void UpdateGridUI()
      {
         
         // Get the MyDataGridColumnStyle to update.
         // MyDataGridColumnStyle is a class derived from DataGridColumnStyle.
         MyDataGridColumnStyle^ myGridColumn = dynamic_cast<MyDataGridColumnStyle^>(dataGrid1->TableStyles[ 0 ]->GridColumnStyles[ "CompanyName" ]);
         
         // Call UpdateUI.
         myGridColumn->UpdateUI( myCurrencyManager, 10, "my new value" );
      }