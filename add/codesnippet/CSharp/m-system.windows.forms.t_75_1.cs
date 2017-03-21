private void myCheckBox_CheckedChanged(object sender, System.EventArgs e)
{
   // If the check box is checked, expand all the tree nodes.
   if (myCheckBox.Checked == true)
   {
      myTreeView.ExpandAll();
   }
   else
   {
      // If the check box is not cheked, collapse the first tree node.
      myTreeView.Nodes[0].FirstNode.Collapse();
      MessageBox.Show("The first and last  node of CutomerList root node is collapsed");
   }
}