private void SetBoolColumnValues(){
   DataGridBoolColumn myGridColumn;
   // Get the DataGridBoolColumn you are setting.
   myGridColumn = (DataGridBoolColumn) myDataGrid.
   TableStyles["Customers"].GridColumnStyles["Current"];
   // Set TrueValue, FalseValue, and NullValue.
   myGridColumn.TrueValue = true;
   myGridColumn.FalseValue = false;
   myGridColumn.NullValue = Convert.DBNull;
}

 