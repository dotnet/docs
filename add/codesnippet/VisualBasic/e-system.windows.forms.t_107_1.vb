' Updates all child tree nodes recursively.
Private Sub CheckAllChildNodes(treeNode As TreeNode, nodeChecked As Boolean)
   Dim node As TreeNode
   For Each node In  treeNode.Nodes 
      node.Checked = nodeChecked
      If node.Nodes.Count > 0 Then
         ' If the current node has child nodes, call the CheckAllChildsNodes method recursively.
         Me.CheckAllChildNodes(node, nodeChecked)
      End If
   Next node
End Sub
      
' NOTE   This code can be added to the BeforeCheck event handler instead of the AfterCheck event.
' After a tree node's Checked property is changed, all its child nodes are updated to the same value.
Private Sub node_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles treeView1.AfterCheck
   ' The code only executes if the user caused the checked state to change.
   If e.Action <> TreeViewAction.Unknown Then 
      If e.Node.Nodes.Count > 0 Then
         ' Calls the CheckAllChildNodes method, passing in the current 
         ' Checked value of the TreeNode whose checked state changed. 
         Me.CheckAllChildNodes(e.Node, e.Node.Checked)
      End If
   End If
End Sub 