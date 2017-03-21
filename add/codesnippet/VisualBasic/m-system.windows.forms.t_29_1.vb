Private Sub treeView1_MouseDown(sender As Object, _
  e As MouseEventArgs) Handles treeView1.MouseDown
   Select Case e.Button
      ' Remove the TreeNode under the mouse cursor 
      ' if the right mouse button was clicked. 
      Case MouseButtons.Right
         treeView1.GetNodeAt(e.X, e.Y).Remove()
      
      ' Toggle the TreeNode under the mouse cursor 
      ' if the middle mouse button (mouse wheel) was clicked. 
      Case MouseButtons.Middle
         treeView1.GetNodeAt(e.X, e.Y).Toggle()
   End Select
End Sub