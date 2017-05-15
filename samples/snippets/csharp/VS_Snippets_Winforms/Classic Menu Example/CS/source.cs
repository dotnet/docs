using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected MainMenu mainMenu1;

 protected MenuItem menuItem1;
 protected MenuItem menuItem2;
 protected MenuItem menuItem3;
 protected MenuItem menuItem4;
// <Snippet1>
public void CreateMyMenu()
    {
    // Set the caption for the top-level menu item.
    menuItem1.Text = "Edit";
    // Set the caption for the first submenu.
    menuItem2.Text = "Font Size";
    // Set the caption for menuItem2's first submenu.
    menuItem3.Text = "Small";
    // Set the checked property to true since this is the default value.
    menuItem3.Checked = true;
    // Define a shortcut key combination for the menu item.
    menuItem3.Shortcut = Shortcut.CtrlS;
    // Set the caption of the second sub menu item of menuItem2.
    menuItem4.Text = "Large";
    // Define a shortcut key combination for the menu item.
    menuItem4.Shortcut = Shortcut.CtrlL;
    // Set the index of the menu item so it is placed below the first submenu item.
    menuItem4.Index = 1;
    // Add menuItem3 and menuItem4 to menuItem2's list of menu items.
    menuItem2.MenuItems.Add(menuItem3);
    menuItem2.MenuItems.Add(menuItem4);
    // Add menuItem2 to menuItem1's list of menu items.
    menuItem1.MenuItems.Add(menuItem2);
    // Add menuItem1 to the MainMenu for displaying.
    mainMenu1.MenuItems.Add(menuItem1);
    }

// </Snippet1>
}
