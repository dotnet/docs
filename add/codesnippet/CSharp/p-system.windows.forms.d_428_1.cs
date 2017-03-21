private void DataGridView1_RowStateChanged(Object sender, DataGridViewRowStateChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Row", e.Row );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "StateChanged", e.StateChanged );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowStateChanged Event" );
}