		public void CreateMyMenu()
		{
			// Create a main menu object.
			MainMenu mainMenu1 = new MainMenu();

			// Create empty menu item objects.
			MenuItem menuItem1 = new MenuItem();
			MenuItem menuItem2 = new MenuItem();

			// Set the caption of the menu items.
			menuItem1.Text = "&File";
			menuItem2.Text = "&Edit";

			// Add the menu items to the main menu.
			mainMenu1.MenuItems.Add(menuItem1);
			mainMenu1.MenuItems.Add(menuItem2);
			
			// Add functionality to the menu items. 
			menuItem1.Select += new System.EventHandler(this.menuItem1_Select);
			menuItem2.Select += new System.EventHandler(this.menuItem2_Select);
			
			// Assign mainMenu1 to the form.
			this.Menu=mainMenu1;

			// Select the File menu item.
			menuItem1.PerformSelect();
		}

		private void menuItem1_Select(object sender, System.EventArgs e)
		{	
			MessageBox.Show("You selected the File menu.","The Event Information");		
		}

		private void menuItem2_Select(object sender, System.EventArgs e)
		{
			MessageBox.Show("You selected the Edit menu.","The Event Information");		
		}