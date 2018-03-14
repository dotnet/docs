using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected MenuItem menuItem2;
// <Snippet1>
 public void DisableMyChildMenus ()
 {
    // Determine if menuItem2 is a parent menu.
    if(menuItem2.IsParent == true)
    {
       // Loop through all the submenus.
       for(int i = 0; i < menuItem2.MenuItems.Count; i++)
       {
          // Disable all of the submenus of menuItem2.
          menuItem2.MenuItems[i].Enabled = false;
       }
    }
 }

// </Snippet1>
}
