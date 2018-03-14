using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
 public void SetMDIList()
 {
    // Create the MenuItem to be used to display an MDI list.
    MenuItem menuItem1 = new MenuItem();
    // Set this menu item to be used as an MDI list.
    menuItem1.MdiList = true;
 }

// </Snippet1>
}
