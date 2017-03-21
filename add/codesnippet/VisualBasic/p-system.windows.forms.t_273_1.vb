Private Sub treeView1_AfterCollapse(sender As Object, _
  e As TreeViewEventArgs) Handles treeView1.AfterCollapse
   ' Create a copy of the e.Node from its Handle.
   Dim tn As TreeNode = TreeNode.FromHandle(e.Node.TreeView, e.Node.Handle)
   tn.Text += "Copy"
   ' Remove the e.Node so it can be replaced with tn.
   e.Node.Remove()
   ' Add tn to the TreeNodeCollection.
   treeView1.Nodes.Add(tn)
End Sub 