Private Sub EnumerateTreeNodes()
   Dim myNodeCollection As TreeNodeCollection = myTreeView.Nodes
   ' Check for a node in the collection.
   If myNodeCollection.Contains(myTreeNode2) Then
      myLabel.Text += "Node2 is at index: " + myNodeCollection.IndexOf(myTreeNode2)
   End If
   myLabel.Text += ControlChars.Cr + ControlChars.Cr + _
     "Elements of the TreeNodeCollection:" + ControlChars.Cr
   
   ' Create an enumerator for the collection.
   Dim myEnumerator As IEnumerator = myNodeCollection.GetEnumerator()
   While myEnumerator.MoveNext()
      myLabel.Text += CType(myEnumerator.Current, TreeNode).Text + ControlChars.Cr
   End While
End Sub 