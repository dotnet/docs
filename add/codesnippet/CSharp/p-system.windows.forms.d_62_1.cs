private void DataGridView1_RowHeightInfoPushed(Object sender, DataGridViewRowHeightInfoPushedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Height", e.Height );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "MinimumHeight", e.MinimumHeight );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowHeightInfoPushed Event" );
}