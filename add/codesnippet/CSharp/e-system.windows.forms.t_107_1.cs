// Updates all child tree nodes recursively.
private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
{
   foreach(TreeNode node in treeNode.Nodes)
   {
      node.Checked = nodeChecked;
      if(node.Nodes.Count > 0)
      {
         // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
         this.CheckAllChildNodes(node, nodeChecked);
      }
   }
}

// NOTE   This code can be added to the BeforeCheck event handler instead of the AfterCheck event.
// After a tree node's Checked property is changed, all its child nodes are updated to the same value.
private void node_AfterCheck(object sender, TreeViewEventArgs e)
{
   // The code only executes if the user caused the checked state to change.
   if(e.Action != TreeViewAction.Unknown)
   {
      if(e.Node.Nodes.Count > 0)
      {
         /* Calls the CheckAllChildNodes method, passing in the current 
         Checked value of the TreeNode whose checked state changed. */
         this.CheckAllChildNodes(e.Node, e.Node.Checked);
      }
   }
}