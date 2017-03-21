private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
{  
   /* Display the Text and Index of the 
    * selected tree node's Parent. */
   if(e.Node.Parent!= null && 
     e.Node.Parent.GetType() == typeof(TreeNode) )
   {
      statusBar1.Text = "Parent: " + e.Node.Parent.Text + "\n"
         + "Index Position: " + e.Node.Parent.Index.ToString();
   }
   else
   {
      statusBar1.Text = "No parent node.";
   }
}