Private Sub button1_Click(sender As Object, _
  e As System.EventArgs) Handles button1.Click
   If treeView1.SelectedNode.IsExpanded Then
      treeView1.SelectedNode.Collapse()
      MessageBox.Show(treeView1.SelectedNode.Text & _ 
        " tree node collapsed.")
   Else
      treeView1.SelectedNode.Expand()
      MessageBox.Show(treeView1.SelectedNode.Text & _
        " tree node expanded.")
   End If
End Sub 