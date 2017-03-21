private void DataGridView1_AutoSizeColumnModeChanged(Object sender, DataGridViewAutoSizeColumnModeEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Column", e.Column );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "PreviousMode", e.PreviousMode );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "AutoSizeColumnModeChanged Event" );
}