private void ListView1_ItemDrag(Object sender, ItemDragEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ItemDrag Event" );
}