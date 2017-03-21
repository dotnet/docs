private void ListView1_DrawSubItem(Object sender, DrawListViewSubItemEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "DrawDefault", e.DrawDefault );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Bounds", e.Bounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "SubItem", e.SubItem );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ItemIndex", e.ItemIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Header", e.Header );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ItemState", e.ItemState );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DrawSubItem Event" );
}