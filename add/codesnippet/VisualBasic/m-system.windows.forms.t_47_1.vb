Private Sub button4_Click(sender As Object, _
  e As System.EventArgs) Handles button4.Click
   Dim lastNode as TreeNode
   lastNode = treeView1.Nodes(treeView1.Nodes.Count - 1). _
     Nodes(treeView1.Nodes(treeView1.Nodes.Count - 1).Nodes.Count - 1)

   ' Clone the last child node.
   Dim clonedNode As TreeNode = CType(lastNode.Clone(), TreeNode)

   ' Insert the cloned node as the first root node.
   treeView1.Nodes.Insert(0, clonedNode)
   MessageBox.Show(lastNode.Text & _
     " tree node cloned and added to " & treeView1.Nodes(0).Text)
End Sub