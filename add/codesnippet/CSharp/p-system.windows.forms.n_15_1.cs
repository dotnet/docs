private void DataGrid1_Navigate(Object sender, NavigateEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Forward", e.Forward );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Navigate Event" );
}