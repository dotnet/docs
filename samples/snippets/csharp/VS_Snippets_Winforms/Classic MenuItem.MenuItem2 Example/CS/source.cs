using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
 public void CreateMyMenuItem()
 {
    // Create an instance of MenuItem with caption and an event handler
    MenuItem menuItem1 = new MenuItem("&New", new System.EventHandler(this.MenuItem1_Click));
 }
 
 // This method is an event handler for menuItem1 to use when connecting its event handler.
 private void MenuItem1_Click(Object sender, System.EventArgs e) 
 {
    // Code goes here that handles the Click event.
 }
   
// </Snippet1>
}
