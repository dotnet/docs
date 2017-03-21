private void button2_Click(object sender, EventArgs e)
{
   // Delete the first TreeNode in the collection 
   // if the Text property is "Node0." 
   if(this.treeView1.Nodes[0].Text == "Node0")
   {
      this.treeView1.Nodes.RemoveAt(0);
   }
}