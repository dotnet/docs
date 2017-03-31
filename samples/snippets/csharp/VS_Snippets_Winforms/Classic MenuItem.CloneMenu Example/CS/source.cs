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
    // Clone the menu item and add it to the collection for the shortcut menu.
    contextMenu1.MenuItems.Add(menuItem1.CloneMenu());
    
 }

// </Snippet1>
}
