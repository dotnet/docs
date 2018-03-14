using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
 public void CreateMyMenu()
 {
    // Create an empty menu item object.
    MenuItem menuItem1 = new MenuItem();
    // Intialize the menu item using the parameterless version of the constructor.
    // Set the caption of the menu item.
    menuItem1.Text = "&File";
 }

// </Snippet1>
}
