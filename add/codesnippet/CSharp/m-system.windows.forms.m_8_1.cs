		private void InitializeMyMainMenu()
		{
			// Create the MainMenu and the menu items to add.
			MainMenu mainMenu1 = new MainMenu();

			MenuItem menuItem1 = new MenuItem();
			MenuItem menuItem2 = new MenuItem();
			MenuItem menuItem3 = new MenuItem();
			MenuItem menuItem4 = new MenuItem();

   
			// Set the caption for the menu items.
			menuItem1.Text = "File";
			menuItem2.Text = "Edit";
			menuItem3.Text = "View";

			// Add 3 menu items to the MainMenu for displaying.
			mainMenu1.MenuItems.Add(menuItem1);
			mainMenu1.MenuItems.Add(menuItem2);
			mainMenu1.MenuItems.Add(menuItem3);

			// Assign mainMenu1 to the form.
			Menu = mainMenu1;

			// Determine whether menuItem3 is currently being used.
			if(menuItem3.GetMainMenu() != null)
				// Display the name of the form in which it is located.
				label1.Text= menuItem3.GetMainMenu().GetForm().ToString();
		}