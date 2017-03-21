private void AddDataGridBoolColumnStyle(){
   DataGridBoolColumn myColumn = new DataGridBoolColumn();
   myColumn.MappingName = "Current";
   myColumn.Width = 200;
   dataGrid1.TableStyles["Customers"].GridColumnStyles.Add(myColumn);
} 