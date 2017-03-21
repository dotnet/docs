Private Sub myButton_Click(ByVal sender As Object, _
  ByVal e As System.EventArgs) Handles myButton.Click
   ' Set the tree view's PathSeparator property.
   myTreeView.PathSeparator = "."

   ' Get the count of the child tree nodes contained in the SelectedNode.
   Dim myNodeCount As Integer = myTreeView.SelectedNode.GetNodeCount(True)
   Dim myChildPercentage As Decimal = CDec(myNodeCount) / _
      CDec(myTreeView.GetNodeCount(True)) * 100

   ' Display the tree node path and the number of child nodes it and the tree view have.
   MessageBox.Show(("The '" + myTreeView.SelectedNode.FullPath + "' node has " _
      + myNodeCount.ToString() + " child nodes." + Microsoft.VisualBasic.ControlChars.Lf _
      + "That is " + String.Format("{0:###.##}", myChildPercentage) _
      + "% of the total tree nodes in the tree view control."))
End Sub