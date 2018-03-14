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
    // submenu item array.
    MenuItem[] subMenus = new MenuItem[3];
    // Create three menu items to add to the submenu item array.
    MenuItem subMenuItem1 = new MenuItem("Red");
    MenuItem subMenuItem2 = new MenuItem("Blue");
    MenuItem subMenuItem3 = new MenuItem("Green");
    // Add the submenu items to the array.
    subMenus[0] = subMenuItem1;
    subMenus[1] = subMenuItem2;
    subMenus[2] = subMenuItem3;
    // Create an instance of a MenuItem with caption and an array of submenu
    // items specified.
    MenuItem MenuItem1 = new MenuItem("&Colors", subMenus);
 }
   
// </Snippet1>
}
