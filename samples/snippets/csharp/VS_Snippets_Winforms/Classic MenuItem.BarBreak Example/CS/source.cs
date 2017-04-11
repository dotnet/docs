using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
 public void CreateMyMenus()
 {
    // Create three top-level menu items.
    MenuItem menuItem1 = new MenuItem("&File");
    MenuItem menuItem2 = new MenuItem("&New");
    MenuItem menuItem3 = new MenuItem("&Open");
    // Set the BarBreak property to display horizontally.
    menuItem2.BarBreak = true;
    menuItem3.BarBreak = true;
    // Add menuItem2 and menuItem3 to the menuItem1's list of menu items.
    menuItem1.MenuItems.Add(menuItem2);
    menuItem1.MenuItems.Add(menuItem3);
 }

// </Snippet1>
}
