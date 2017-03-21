Private Sub treeView1_KeyDown(sender As Object, _
  e As KeyEventArgs) Handles treeView1.KeyDown
   ' If the 'Alt' and 'E' keys are pressed,
   ' allow the user to edit the TreeNode label. 
   If e.Alt And e.KeyCode = Keys.E Then
      treeView1.LabelEdit = True
      ' If there is a TreeNode under the mose cursor, begin editing. 
      Dim editNode As TreeNode = treeView1.GetNodeAt( _
        treeView1.PointToClient(System.Windows.Forms.Control.MousePosition))
      If (editNode IsNot Nothing) Then
         editNode.BeginEdit()
      End If
   End If
End Sub

Private Sub treeView1_AfterLabelEdit(sender As Object, _
  e As NodeLabelEditEventArgs) Handles treeView1.AfterLabelEdit
   ' Disable the ability to edit the TreeNode labels.
   treeView1.LabelEdit = False
End Sub