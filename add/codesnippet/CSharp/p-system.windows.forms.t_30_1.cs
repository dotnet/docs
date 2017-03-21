private void CopyTreeNodes()
{
   // Get the collection of TreeNodes.
   TreeNodeCollection myNodeCollection = myTreeView.Nodes;
   int myCount = myNodeCollection.Count;

   myLabel.Text += "Number of nodes in the collection :" + myCount;
   myLabel.Text += "\n\nElements of the Array after Copying from the collection :\n";
   // Create an Object array.
   Object[] myArray = new Object[myCount];
   // Copy the collection into an array.
   myNodeCollection.CopyTo(myArray,0);
   for(int i=0; i<myArray.Length; i++)
   {
      myLabel.Text += ((TreeNode)myArray[i]).Text + "\n";
   }
}