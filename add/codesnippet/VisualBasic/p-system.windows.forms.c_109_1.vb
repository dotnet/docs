      Private Sub treeView1_MouseUp(sender As Object, _
        e As MouseEventArgs) Handles treeView1.MouseUp
         ' If the right mouse button was clicked and released,
         ' display the shortcut menu assigned to the TreeView. 
         If e.Button = MouseButtons.Right Then
            treeView1.ContextMenu.Show(treeView1, New Point(e.X, e.Y))
         End If
      End Sub