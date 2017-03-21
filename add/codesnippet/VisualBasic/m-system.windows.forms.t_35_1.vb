Private Sub button3_Click(sender As Object, _
  e As System.EventArgs) Handles button3.Click
   Dim lastNode as TreeNode
   lastNode = treeView1.Nodes(treeView1.Nodes.Count - 1). _
     Nodes(treeView1.Nodes(treeView1.Nodes.Count - 1).Nodes.Count - 1)

   If Not lastNode.IsVisible Then
      lastNode.EnsureVisible()
      MessageBox.Show(lastNode.Text & _
        " tree node is visible.")
   End If
End Sub