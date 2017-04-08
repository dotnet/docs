using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected MenuItem menuItem1;
// <Snippet1>
 public void CreateMyMenus()
 {
    // Create an instance of a MenuItem with a specified caption.
    menuItem1 = new MenuItem("&File");
 }
 
// </Snippet1>
}
