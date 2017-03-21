Private Sub MyButtonAddAllClick(sender As Object, e As EventArgs)
   ' Get the 'myTreeNodeCollection' from the 'myTreeViewBase' TreeView.
   Dim myTreeNodeCollection As TreeNodeCollection = myTreeViewBase.Nodes
   ' Create an array of 'TreeNodes'.
   Dim myTreeNodeArray(myTreeViewBase.Nodes.Count-1) As TreeNode
   ' Copy the tree nodes to the 'myTreeNodeArray' array.
   myTreeViewBase.Nodes.CopyTo(myTreeNodeArray, 0)
   ' Remove all the tree nodes from the 'myTreeViewBase' TreeView.
   myTreeViewBase.Nodes.Clear()
   ' Add the 'myTreeNodeArray' to the 'myTreeViewCustom' TreeView.
      myTreeViewCustom.Nodes.AddRange(myTreeNodeArray)
End Sub