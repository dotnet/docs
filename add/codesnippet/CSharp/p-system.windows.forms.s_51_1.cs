private void ListView1_SearchForVirtualItem(Object sender, SearchForVirtualItemEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "IsTextSearch", e.IsTextSearch );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "IncludeSubItemsInSearch", e.IncludeSubItemsInSearch );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Index", e.Index );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "IsPrefixSearch", e.IsPrefixSearch );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Text", e.Text );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "StartingPoint", e.StartingPoint );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Direction", e.Direction );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "StartIndex", e.StartIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "SearchForVirtualItem Event" );
}