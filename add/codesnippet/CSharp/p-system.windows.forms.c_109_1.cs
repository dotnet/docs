private void treeView1_MouseUp(object sender, MouseEventArgs e)
{
   // If the right mouse button was clicked and released,
   // display the shortcut menu assigned to the TreeView. 
   if(e.Button == MouseButtons.Right)
   {
      treeView1.ContextMenu.Show(treeView1, new Point(e.X, e.Y) );      
   }
}