using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
// <Snippet1>
 public void CreateMyMenuItem()
 {
    // Create a MenuItem with caption, shortcut key, and an event handler
    // specified.
    MenuItem MenuItem1 = new MenuItem("&New",
        new System.EventHandler(this.MenuItem1_Click), Shortcut.CtrlL);
 }
 
 // The following method is an event handler for menuItem1 to use when
 // connecting the event handler.
 private void MenuItem1_Click(Object sender, EventArgs e)
 {
    // Code goes here that handles the Click event.
 }
   
// </Snippet1>
}
