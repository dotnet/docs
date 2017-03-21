private void ListView1_VirtualItemsSelectionRangeChanged(Object sender, ListViewVirtualItemsSelectionRangeChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "EndIndex", e.EndIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "IsSelected", e.IsSelected );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "StartIndex", e.StartIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "VirtualItemsSelectionRangeChanged Event" );
}