using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected MenuItem menuItem1;
// <Snippet1>
 public void SetupMyMenuItem()
 {
    // Set the caption for the menu item.
    menuItem1.Text = "&New";
    // Assign a shortcut key.
    menuItem1.Shortcut = Shortcut.CtrlN;
    // Make the menu item visible.
    menuItem1.Visible = true;
    // Display the shortcut key combination.
    menuItem1.ShowShortcut = true;
 }
   
// </Snippet1>
}
