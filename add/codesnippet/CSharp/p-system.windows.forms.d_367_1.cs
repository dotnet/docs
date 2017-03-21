private void DataGridView1_RowHeightInfoNeeded(Object sender, DataGridViewRowHeightInfoNeededEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Height", e.Height );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "MinimumHeight", e.MinimumHeight );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowHeightInfoNeeded Event" );
}