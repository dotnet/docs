private void PropertyGrid1_PropertyTabChanged(Object sender, PropertyTabChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "OldTab", e.OldTab );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "NewTab", e.NewTab );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "PropertyTabChanged Event" );
}