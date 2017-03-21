private void SetReadOnly()
{
    DataColumnCollection myDataColumns;
    // Get the columns for a table bound to a DataGrid.
    myDataColumns = dataSet1.Tables["Suppliers"].Columns;
    foreach(DataColumn dataColumn in myDataColumns)
    {
        dataGrid1.TableStyles[0].GridColumnStyles[dataColumn.ColumnName].ReadOnly = dataColumn.ReadOnly;
    }
}
 