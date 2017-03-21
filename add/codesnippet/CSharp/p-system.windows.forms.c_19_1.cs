private void ListView1_CacheVirtualItems(Object sender, CacheVirtualItemsEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "StartIndex", e.StartIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "EndIndex", e.EndIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CacheVirtualItems Event" );
}