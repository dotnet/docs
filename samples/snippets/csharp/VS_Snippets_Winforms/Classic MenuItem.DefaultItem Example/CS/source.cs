using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
// <Snippet1>
 public void CreateMyMenus()
 {
    MenuItem menuItem1 = new MenuItem("&File");
    MenuItem menuItem2 = new MenuItem("&New");
    MenuItem menuItem3 = new MenuItem("&Open");
    // Make menuItem2 the default menu item.
    menuItem2.DefaultItem = true;
 }
 
// </Snippet1>
}
