using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected MenuItem menuItem1;
 protected ContextMenu contextMenu1;
// <Snippet1>
 public void CloneMyMenu()
 {
    // Clone the existing MenuItem into the new MenuItem.
    MenuItem tempMenuItem = menuItem1.CloneMenu();
  
    // Assign the cloned MenuItem to the ContextMenu.
    contextMenu1.MenuItems.Add(tempMenuItem);
 }

// </Snippet1>
}
