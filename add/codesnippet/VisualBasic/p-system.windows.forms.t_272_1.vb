Private Sub SelectNode(node As TreeNode)
   If node.IsSelected Then
      ' Determine which TreeNode to select.
      Select Case myComboBox.Text
         Case "Previous"
            node.TreeView.SelectedNode = node.PrevNode
         Case "PreviousVisible"
            node.TreeView.SelectedNode = node.PrevVisibleNode
         Case "Next"
            node.TreeView.SelectedNode = node.NextNode
         Case "NextVisible"
            node.TreeView.SelectedNode = node.NextVisibleNode
         Case "First"
            node.TreeView.SelectedNode = node.FirstNode
         Case "Last"
            node.TreeView.SelectedNode = node.LastNode
      End Select
   End If
   node.TreeView.Focus()
End Sub