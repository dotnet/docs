private void DataGridView1_ColumnStateChanged(Object sender, DataGridViewColumnStateChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Column", e.Column );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "StateChanged", e.StateChanged );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnStateChanged Event" );
}