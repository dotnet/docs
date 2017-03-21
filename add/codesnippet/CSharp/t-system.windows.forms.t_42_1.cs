private void ToolStrip1_ItemClicked(Object sender, ToolStripItemClickedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ClickedItem", e.ClickedItem );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ItemClicked Event" );
}