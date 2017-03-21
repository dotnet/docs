private void ListView1_DrawItem(Object sender, DrawListViewItemEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "DrawDefault", e.DrawDefault );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Bounds", e.Bounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ItemIndex", e.ItemIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "State", e.State );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DrawItem Event" );
}