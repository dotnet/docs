		private void InitializeMyMainMenu()
		{
			// Create the 2 menus and the menu items to add.
			MainMenu mainMenu1 = new MainMenu();
			MainMenu mainMenu2 = new MainMenu();

			MenuItem menuItem1 = new MenuItem();
			MenuItem menuItem2 = new MenuItem();
  
			// Set the caption for the menu items.
			menuItem1.Text = "File";
			menuItem2.Text = "Edit";

			// Add a menu item to each menu for displaying.
			mainMenu1.MenuItems.Add(menuItem1);
			mainMenu2.MenuItems.Add(menuItem2);

			// Merge mainMenu2 with mainMenu1
			mainMenu1.MergeMenu(mainMenu2);

			// Assign mainMenu1 to the form.
			this.Menu = mainMenu1;
		}