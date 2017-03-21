private void DataGridView1_RowDividerDoubleClick(Object sender, DataGridViewRowDividerDoubleClickEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowDividerDoubleClick Event" );
}