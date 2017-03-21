private void treeView1_MouseDown(object sender, MouseEventArgs e)
{
   switch(e.Button)
   {
      // Remove the TreeNode under the mouse cursor 
      // if the right mouse button was clicked. 
      case MouseButtons.Right:
         treeView1.GetNodeAt(e.X, e.Y).Remove();
         break;
      
      // Toggle the TreeNode under the mouse cursor 
      // if the middle mouse button (mouse wheel) was clicked. 
      case MouseButtons.Middle:
         treeView1.GetNodeAt(e.X, e.Y).Toggle();
         break;
   }
}