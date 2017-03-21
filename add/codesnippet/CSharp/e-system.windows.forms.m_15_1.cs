		public void CreateMyMenu()
		{
			// Create a main menu object.
			MainMenu mainMenu1 = new MainMenu();

			// Create empty menu item objects.
			MenuItem topMenuItem = new MenuItem();
			MenuItem menuItem1 = new MenuItem();
                  
			// Set the caption of the menu items.
			topMenuItem.Text = "&File";
			menuItem1.Text = "&Open";

			// Add the menu items to the main menu.
         		topMenuItem.MenuItems.Add(menuItem1);
			mainMenu1.MenuItems.Add(topMenuItem);
						
			// Add functionality to the menu items using the Click event. 
			menuItem1.Click += new System.EventHandler(this.menuItem1_Click);

			// Assign mainMenu1 to the form.
			this.Menu=mainMenu1;
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{	
                   // Create a new OpenFileDialog and display it.
		   OpenFileDialog fd = new OpenFileDialog();
         	   fd.DefaultExt = "*.*";
		   fd.ShowDialog();
		}