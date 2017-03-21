private void PropertyGrid1_PropertyValueChanged(Object sender, PropertyValueChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ChangedItem", e.ChangedItem );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "OldValue", e.OldValue );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "PropertyValueChanged Event" );
}