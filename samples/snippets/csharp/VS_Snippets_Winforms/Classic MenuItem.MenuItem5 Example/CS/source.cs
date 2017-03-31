using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
// <Snippet1>
 public void CreateMyMenuItem()
 {
    // Submenu item array.
    MenuItem[] subMenus = new MenuItem[3];
    // Create three menu items to add to the submenu item array.
    MenuItem subMenuItem1 = new MenuItem("Red");
    MenuItem subMenuItem2 = new MenuItem("Blue");
    MenuItem subMenuItem3 = new MenuItem("Green");
 
    // Add the submenu items to the array.
    subMenus[0] = subMenuItem1;
    subMenus[1] = subMenuItem2;
    subMenus[2] = subMenuItem3;
    /* Create a MenuItem with caption, shortcut key, 
       a Click, Popup, and Select event handler, merge type and order, and an 
       array of submenu items specified.
    */
    MenuItem menuItem1 = new MenuItem(MenuMerge.Add, 0,
       Shortcut.CtrlShiftC, "&Colors", 
       new EventHandler(this.MenuItem1_Click),
       new EventHandler(this.MenuItem1_Popup),
       new EventHandler(this.MenuItem1_Select), subMenus);
 }
 
 // The following method is an event handler for menuItem1 to use when connecting the Click event.
 private void MenuItem1_Click(Object sender, EventArgs e)
 {
    // Code goes here that handles the Click event.
 }
 
 // The following method is an event handler for menuItem1 to use  when connecting the Popup event.
 private void MenuItem1_Popup(Object sender, EventArgs e)
 {
    // Code goes here that handles the Click event.
 }
 
 // The following method is an event handler for menuItem1 to use  when connecting the Select event
 private void MenuItem1_Select(Object sender, EventArgs e)
 {
    // Code goes here that handles the Click event.
 }

// </Snippet1>
}
