using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected MenuItem menuItem1;
 protected MenuItem menuItem2;
// <Snippet1>
 public void SwitchMyMenuItems()
 {
    // Move menuItem1 down one position in the menu order.
    menuItem1.Index = menuItem1.Index + 1;
    // Move menuItem2 up one position in the menu order.
    menuItem2.Index = menuItem2.Index - 1;
 }

// </Snippet1>
}
