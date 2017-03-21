private void DataGridView1_CellDoubleClick(Object sender, DataGridViewCellEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellDoubleClick Event" );
}