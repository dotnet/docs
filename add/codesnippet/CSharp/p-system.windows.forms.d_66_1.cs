private void DataGridView1_CellParsing(Object sender, DataGridViewCellParsingEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "InheritedCellStyle", e.InheritedCellStyle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ParsingApplied", e.ParsingApplied );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Value", e.Value );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "DesiredType", e.DesiredType );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellParsing Event" );
}