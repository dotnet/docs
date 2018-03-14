using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
 private void InitializeMyMainMenu()
 {
    // Create the MainMenu and the MenuItem to add.
    MainMenu mainMenu1 = new MainMenu();
    MenuItem menuItem1 = new MenuItem("&File");
    
    /* Use the MenuItems property to call the Add method
       to add the MenuItem to the MainMenu menu item collection. */
    mainMenu1.MenuItems.Add (menuItem1);
 
    // Assign mainMenu1 to the form.
    this.Menu = mainMenu1;
 }
 
// </Snippet1>
}
