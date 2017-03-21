private void DataGridView1_RowErrorTextChanged(Object sender, DataGridViewRowEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Row", e.Row );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowErrorTextChanged Event" );
}