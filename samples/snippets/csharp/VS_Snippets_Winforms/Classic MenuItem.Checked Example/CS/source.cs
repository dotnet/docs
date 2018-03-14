using System;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;


public class Form1: Form {

 protected TextBox textBox1;
 protected MenuItem menuItemBlue;
 protected MenuItem menuItemRed;
 protected MenuItem menuItemGreen;
    
// <Snippet1>
// The following event handler would be connected to three menu items.
 private void MyMenuClick(Object sender, EventArgs e)
 {
    // Determine if clicked menu item is the Blue menu item.
    if(sender == menuItemBlue)
    {
       // Set the checkmark for the menuItemBlue menu item.
       menuItemBlue.Checked = true;
       // Uncheck the menuItemRed and menuItemGreen menu items.
       menuItemRed.Checked = false;
       menuItemGreen.Checked = false;
       // Set the color of the text in the TextBox control to Blue.
       textBox1.ForeColor = Color.Blue;
    }
    else if(sender == menuItemRed)
    {
       // Set the checkmark for the menuItemRed menu item.
       menuItemRed.Checked = true;
       // Uncheck the menuItemBlue and menuItemGreen menu items.
       menuItemBlue.Checked = false;
       menuItemGreen.Checked = false;
       // Set the color of the text in the TextBox control to Red.
       textBox1.ForeColor = Color.Red;
    }
    else
    {
       // Set the checkmark for the menuItemGreen.
       menuItemGreen.Checked = true;
       // Uncheck the menuItemRed and menuItemBlue menu items.
       menuItemBlue.Checked = false;
       menuItemRed.Checked = false;
       // Set the color of the text in the TextBox control to Blue.
       textBox1.ForeColor = Color.Green;
    }
 }

// </Snippet1>
}
