private void DataGridView1_CellStyleContentChanged(Object sender, DataGridViewCellStyleContentChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "CellStyle", e.CellStyle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "CellStyleScope", e.CellStyleScope );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellStyleContentChanged Event" );
}