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
    MenuItem menuItem2 = new MenuItem("&Options");
    MenuItem menuItem3 = new MenuItem("&Edit");
    // Place the "Edit" menu on a new line in the menu bar.
    menuItem3.Break = true;
 }
   
// </Snippet1>
}
