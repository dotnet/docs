private void myButton_Click(object sender, System.EventArgs e)
{
   // Set the tree view's PathSeparator property.
   myTreeView.PathSeparator = ".";

   // Get the count of the child tree nodes contained in the SelectedNode.
   int myNodeCount = myTreeView.SelectedNode.GetNodeCount(true);
   decimal myChildPercentage = ((decimal)myNodeCount/
     (decimal)myTreeView.GetNodeCount(true)) * 100;

   // Display the tree node path and the number of child nodes it and the tree view have.
   MessageBox.Show("The '" + myTreeView.SelectedNode.FullPath + "' node has " 
     + myNodeCount.ToString() + " child nodes.\nThat is " 
     + string.Format("{0:###.##}", myChildPercentage) 
     + "% of the total tree nodes in the tree view control.");
}