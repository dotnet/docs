Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
   ' If neither TreeNodeCollection is read-only, move the 
   ' selected node from treeView1 to treeView2. 
   If Not treeView1.Nodes.IsReadOnly And Not treeView2.Nodes.IsReadOnly Then
      If (treeView1.SelectedNode IsNot Nothing) Then
         Dim tn As TreeNode = treeView1.SelectedNode
         treeView1.Nodes.Remove(tn)
         treeView2.Nodes.Insert(treeView2.Nodes.Count, tn)
      End If
   End If
End Sub