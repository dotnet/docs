Public Sub HighlightCheckedNodes()
   Dim countIndex As Integer = 0
   Dim selectedNode As String = "Selected customer nodes are : "
   Dim myNode As TreeNode
   For Each myNode In  myTreeView.Nodes(0).Nodes
      ' Check whether the tree node is checked.
      If myNode.Checked Then
         ' Set the node's backColor.
         myNode.BackColor = Color.Yellow
         selectedNode += myNode.Text + " "
         countIndex += 1
      Else
         myNode.BackColor = Color.White
      End If
   Next myNode

   If countIndex > 0 Then
      MessageBox.Show(selectedNode)
   Else
      MessageBox.Show("No nodes are selected")
   End If
End Sub