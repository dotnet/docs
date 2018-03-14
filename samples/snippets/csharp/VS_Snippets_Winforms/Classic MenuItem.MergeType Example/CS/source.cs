using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected MenuItem menuItem1;
// <Snippet1>
 public void InitMyFileMenu()
 {
    // Set the MergeType to Add so that the menu item is added to the merged menu.
    menuItem1.MergeType = MenuMerge.Add;
    // Set the MergeOrder to 1 so that this menu item is placed lower in the merged menu order.
    menuItem1.MergeOrder = 1;
 }
 
// </Snippet1>
}
