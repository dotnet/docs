Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
   ' Delete the first TreeNode in the collection 
   ' if the Text property is "Node0." 
   If Me.treeView1.Nodes(0).Text = "Node0" Then
      Me.treeView1.Nodes.RemoveAt(0)
   End If
End Sub