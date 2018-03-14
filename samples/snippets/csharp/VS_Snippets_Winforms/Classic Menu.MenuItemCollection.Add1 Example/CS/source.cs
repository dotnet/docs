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
    // Create the MainMenu.
    MainMenu mainMenu1 = new MainMenu();
    
    /* Use the MenuItems property to call the Add method
       to add two new MenuItem objects to the MainMenu. */
    mainMenu1.MenuItems.Add ("&File");
    mainMenu1.MenuItems.Add ("&Edit", new EventHandler (menuItem2_Click));
 
    // Assign mainMenu1 to the form.
    this.Menu = mainMenu1;
 }
 
 private void menuItem2_Click(System.Object sender, System.EventArgs e)
 {
    // Insert code to handle Click event.
 }
 
// </Snippet1>
}
