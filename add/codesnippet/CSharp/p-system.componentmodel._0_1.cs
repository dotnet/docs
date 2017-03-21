private void BindingSource1_ListChanged(Object sender, ListChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ListChangedType", e.ListChangedType );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "NewIndex", e.NewIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "OldIndex", e.OldIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "PropertyDescriptor", e.PropertyDescriptor );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ListChanged Event" );
}