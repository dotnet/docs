private void ListView1_RetrieveVirtualItem(Object sender, RetrieveVirtualItemEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ItemIndex", e.ItemIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RetrieveVirtualItem Event" );
}