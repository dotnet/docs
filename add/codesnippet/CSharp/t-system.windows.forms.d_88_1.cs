private void DataGridView1_DataBindingComplete(Object sender, DataGridViewBindingCompleteEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ListChangedType", e.ListChangedType );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DataBindingComplete Event" );
}