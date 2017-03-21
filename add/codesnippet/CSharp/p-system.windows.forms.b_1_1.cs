private void BindingManagerBase1_DataError(Object sender, BindingManagerDataErrorEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Exception", e.Exception );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DataError Event" );
}