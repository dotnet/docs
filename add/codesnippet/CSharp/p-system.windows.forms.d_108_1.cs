private void DataGridView1_RowErrorTextNeeded(Object sender, DataGridViewRowErrorTextNeededEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowErrorTextNeeded Event" );
}