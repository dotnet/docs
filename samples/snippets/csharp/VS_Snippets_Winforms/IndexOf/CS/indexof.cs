using System;
using System.Drawing;
using System.Windows.Forms;

class TestForm : Form
{

// <snippet1>
public void InitializeMyMenu()
{
	// Create the MainMenu object.
	MainMenu myMainMenu = new MainMenu();
	
	// Create the MenuItem objects.
	MenuItem fileMenu = new MenuItem("&File");
	MenuItem editMenu = new MenuItem("&Edit");
	MenuItem newFile = new MenuItem("&New");
	MenuItem openFile = new MenuItem("&Open");
	MenuItem exitProgram = new MenuItem("E&xit");
	
	// Add the MenuItem objects to myMainMenu.
	myMainMenu.MenuItems.Add(fileMenu);
	myMainMenu.MenuItems.Add(editMenu);
	
	// Add three submenus to the File menu.
	fileMenu.MenuItems.Add(newFile);
	fileMenu.MenuItems.Add(openFile);
	fileMenu.MenuItems.Add(exitProgram);
	
	// Assign myMainMenu to the form.
	Menu = myMainMenu;
	
	// Retrieve the index of the Exit menu item.
	 string indexValue = 
	fileMenu.MenuItems.IndexOf(exitProgram).ToString();
	// Display the result in a message box.
	MessageBox.Show("The index of the Exit menu item = "
			+ indexValue, "MenuItem Information");
}
// </snippet1>

   public static void Main()
   {
      Application.Run(new TestForm());
   }
}

