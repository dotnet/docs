private void ListControl1_Format(Object sender, ListControlConvertEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ListItem", e.ListItem );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Value", e.Value );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "DesiredType", e.DesiredType );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Format Event" );
}