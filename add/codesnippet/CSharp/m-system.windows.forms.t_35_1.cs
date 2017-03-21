private void button3_Click(object sender, System.EventArgs e)
{
   TreeNode lastNode = treeView1.Nodes[treeView1.Nodes.Count - 1].
     Nodes[treeView1.Nodes[treeView1.Nodes.Count - 1].Nodes.Count - 1];

   if (!lastNode.IsVisible)
   {
      lastNode.EnsureVisible();
      MessageBox.Show(lastNode.Text + " tree node is visible.");
   }
}