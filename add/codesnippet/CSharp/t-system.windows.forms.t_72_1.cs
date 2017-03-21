private void TreeView1_NodeMouseHover(Object sender, TreeNodeMouseHoverEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Node", e.Node );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "NodeMouseHover Event" );
}