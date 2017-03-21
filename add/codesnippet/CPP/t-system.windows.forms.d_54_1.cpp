private:
   void GetDataGridTextBox()
   {
      
      // Get the DataGridTextBoxColumn from the DataGrid control.
      DataGridTextBoxColumn^ myTextBoxColumn;
      
      // Assuming the CompanyName column is a DataGridTextBoxColumn.
      myTextBoxColumn = dynamic_cast<DataGridTextBoxColumn^>(dataGrid1->TableStyles[ 0 ]->GridColumnStyles[ "CompanyName" ]);
      
      // Get the DataGridTextBox for the column.
      DataGridTextBox^ myGridTextBox;
      myGridTextBox = dynamic_cast<DataGridTextBox^>(myTextBoxColumn->TextBox);
   }
