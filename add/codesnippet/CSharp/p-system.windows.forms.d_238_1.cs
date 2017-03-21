private void DataGridView1_RowsAdded(Object sender, DataGridViewRowsAddedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowCount", e.RowCount );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowsAdded Event" );
}