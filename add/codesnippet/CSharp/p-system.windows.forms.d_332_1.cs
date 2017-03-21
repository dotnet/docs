private void SetAllowNull(){
    DataGridBoolColumn myGridColumn = (DataGridBoolColumn)dataGrid1.TableStyles[0].GridColumnStyles[0];
    myGridColumn.AllowNull = false;
 }
 