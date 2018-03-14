using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
 protected TextBox pictureBox1;

 protected ContextMenu contextMenu1;
// <Snippet1>
private void MyPopupEventHandler(System.Object sender, System.EventArgs e)
 {
    // Define the MenuItem objects to display for the TextBox.
    MenuItem menuItem1 = new MenuItem("&Copy");
    MenuItem menuItem2 = new MenuItem("&Find and Replace");
    // Define the MenuItem object to display for the PictureBox.
    MenuItem menuItem3 = new MenuItem("C&hange Picture");

    // Clear all previously added MenuItems.
    contextMenu1.MenuItems.Clear();
 
    if(contextMenu1.SourceControl == textBox1)
    {
       // Add MenuItems to display for the TextBox.
       contextMenu1.MenuItems.Add(menuItem1);
       contextMenu1.MenuItems.Add(menuItem2);
    }
    else if(contextMenu1.SourceControl == pictureBox1)
    {
       // Add the MenuItem to display for the PictureBox.
       contextMenu1.MenuItems.Add(menuItem3);
    }
 }
// </Snippet1>
}
