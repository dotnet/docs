private void button1_Click(object sender, System.EventArgs e)
{
   if (treeView1.SelectedNode.IsExpanded)
   {
      treeView1.SelectedNode.Collapse();
      MessageBox.Show(treeView1.SelectedNode.Text + 
        " tree node collapsed.");
   }
   else
   {
      treeView1.SelectedNode.Expand();
      MessageBox.Show(treeView1.SelectedNode.Text + 
        " tree node expanded.");
   }
}