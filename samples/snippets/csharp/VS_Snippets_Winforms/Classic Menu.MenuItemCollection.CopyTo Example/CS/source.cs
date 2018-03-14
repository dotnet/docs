using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected MenuItem menuItem1;
 protected MenuItem menuItem2;
 protected ContextMenu contextMenu1;
// <Snippet1>
private void CopyMyMenus()
{
   // Create empty array to store MenuItem objects.
   MenuItem[] myItems = 
      new MenuItem[menuItem1.MenuItems.Count + menuItem2.MenuItems.Count];
   
   // Copy elements of the first MenuItem collection to array.
   menuItem1.MenuItems.CopyTo(myItems, 0);
   // Copy elements of the second MenuItem collection, after the first set.
   menuItem2.MenuItems.CopyTo(myItems, myItems.Length);

   // Add the array to the menu item collection of the ContextMenu.
   contextMenu1.MenuItems.AddRange(myItems);
}

// </Snippet1>
}
