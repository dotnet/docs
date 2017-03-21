		public void AddContextmenu()
		{
			// Create a shortcut menu.
			ContextMenu m = new ContextMenu();
			this.ContextMenu= m;

			// Create MenuItem objects.
			MenuItem menuItem1 = new MenuItem();
			MenuItem menuItem2 = new MenuItem();
			
			// Set the Text property.
			menuItem1.Text = "New";
			menuItem2.Text = "Open";

			// Add menu items to the MenuItems collection.
			m.MenuItems.Add(menuItem1);
			m.MenuItems.Add(menuItem2);

			// Display the starting message.
			MessageBox.Show("Right-click the form to display the shortcut menu items");


			// Add functionality to the menu items. 
			menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			string textReport =	"You clicked the New menu item. \n" +
				"It is contained in the following shortcut menu: \n\n"; 
		
			// Get information on the shortcut menu in which menuitem1 is contained.
			textReport += ContextMenu.GetContextMenu().ToString();

			// Display the shortcut menu information in a message box.
			MessageBox.Show(textReport,"The ContextMenu Information");		
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			string textReport =	"You clicked the Open menu item. \n" +
				"It is contained in the following shortcut menu: \n\n"; 
		
			// Get information on the shortcut menu in which menuitem1 is contained.
			textReport += ContextMenu.GetContextMenu().ToString();

			// Display the shortcut menu information in a message box.
			MessageBox.Show(textReport,"The ContextMenu Information");		
		}