private void TreeView1_BeforeCheck(Object sender, TreeViewCancelEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Node", e.Node );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "BeforeCheck Event" );
}