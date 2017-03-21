private void DataGridView1_ColumnDataPropertyNameChanged(Object sender, DataGridViewColumnEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Column", e.Column );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnDataPropertyNameChanged Event" );
}