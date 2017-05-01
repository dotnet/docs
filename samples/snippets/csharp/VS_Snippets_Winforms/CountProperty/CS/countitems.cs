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
			MenuItem newFile = new MenuItem("&New");
			MenuItem openFile = new MenuItem("&Open");
			MenuItem exitProgram = new MenuItem("E&xit");
			
			// Add the File menu item to myMainMenu.
			myMainMenu.MenuItems.Add(fileMenu);
			
			// Add three submenus to the File menu.
			fileMenu.MenuItems.Add(newFile);
			fileMenu.MenuItems.Add(openFile);
			fileMenu.MenuItems.Add(exitProgram);
			
			// Assign myMainMenu to the form.
			this.Menu = myMainMenu;
			
			// Count the number of objects in the File menu and display the result.
			string objectNumber = fileMenu.MenuItems.Count.ToString();
			MessageBox.Show("Number of objects in the File menu = " + objectNumber);
		}
		// </snippet1>

   public static void Main()
   {
      Application.Run(new TestForm());
   }
}
