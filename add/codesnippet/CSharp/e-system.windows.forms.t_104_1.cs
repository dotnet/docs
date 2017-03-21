private void TreeView1_AfterExpand(Object sender, TreeViewEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Node", e.Node );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "AfterExpand Event" );
}