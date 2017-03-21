private void ToolStrip1_ItemRemoved(Object sender, ToolStripItemEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ItemRemoved Event" );
}