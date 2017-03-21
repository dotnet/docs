public void HighlightCheckedNodes()
{
   int countIndex = 0;
   string selectedNode = "Selected customer nodes are : ";
   foreach (TreeNode myNode in myTreeView.Nodes[0].Nodes)
   {
      // Check whether the tree node is checked.
      if(myNode.Checked)
      {
         // Set the node's backColor.
         myNode.BackColor = Color.Yellow;
         selectedNode += myNode.Text+" ";
         countIndex++;
      }
      else
         myNode.BackColor = Color.White;
   }

   if(countIndex > 0)
      MessageBox.Show(selectedNode);
   else
      MessageBox.Show("No nodes are selected");
}