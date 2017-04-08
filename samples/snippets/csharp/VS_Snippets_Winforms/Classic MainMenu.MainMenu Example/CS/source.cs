using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
 public void CreateMyMainMenu()
 {
    // Create an empty MainMenu.
    MainMenu mainMenu1 = new MainMenu();
 
    MenuItem menuItem1 = new MenuItem();
    MenuItem menuItem2 = new MenuItem();
 
    menuItem1.Text = "File";
    menuItem2.Text = "Edit";
    // Add two MenuItem objects to the MainMenu.
    mainMenu1.MenuItems.Add(menuItem1);
    mainMenu1.MenuItems.Add(menuItem2);
    
    // Bind the MainMenu to Form1.
    Menu = mainMenu1;   
 }
 
// </Snippet1>
}
