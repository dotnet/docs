private void button4_Click(object sender, System.EventArgs e)
{
   TreeNode lastNode = treeView1.Nodes[treeView1.Nodes.Count - 1].
     Nodes[treeView1.Nodes[treeView1.Nodes.Count - 1].Nodes.Count - 1];

   // Clone the last child node.
   TreeNode clonedNode = (TreeNode) lastNode.Clone();

   // Insert the cloned node as the first root node.
   treeView1.Nodes.Insert(0, clonedNode);
   MessageBox.Show(lastNode.Text + 
     " tree node cloned and added to " + treeView1.Nodes[0].Text);
}