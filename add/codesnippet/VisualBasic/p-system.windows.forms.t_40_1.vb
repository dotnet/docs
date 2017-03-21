Private Sub treeView1_AfterSelect(sender As Object, _
  e As TreeViewEventArgs) Handles treeView1.AfterSelect
   ' Display the Text and Index of the 
   ' selected tree node's Parent. 
   If (e.Node.Parent IsNot Nothing) 
      If (e.Node.Parent.GetType() Is GetType(TreeNode)) Then
         statusBar1.Text = "Parent: " + e.Node.Parent.Text + _
           ControlChars.Cr + "Index Position: " + e.Node.Parent.Index.ToString()
      End If
   Else
      statusBar1.Text = "No parent node."
   End If
End Sub 