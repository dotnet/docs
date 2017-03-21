private void ListView1_ItemSelectionChanged(Object sender, ListViewItemSelectionChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "IsSelected", e.IsSelected );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ItemIndex", e.ItemIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ItemSelectionChanged Event" );
}