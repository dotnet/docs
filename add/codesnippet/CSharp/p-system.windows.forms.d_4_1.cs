private void SetNullText()
{
    DataGridColumnStyle myGridColumn;
    myGridColumn = dataGrid1.TableStyles[0].GridColumnStyles[0];
    myGridColumn.NullText = "Null Text";
}
 