Private Sub myCheckBox_CheckedChanged(ByVal sender As Object, _
   ByVal e As System.EventArgs) Handles myCheckBox.CheckedChanged
   ' If the check box is checked, expand all the tree nodes.
   If myCheckBox.Checked = True Then
      myTreeView.ExpandAll()
   Else
      ' If the check box is not cheked, collapse the first tree node.
      myTreeView.Nodes(0).FirstNode.Collapse()
      MessageBox.Show("The first and last node of CutomerList root node is collapsed")
   End If
End Sub