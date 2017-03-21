		public void CreateMyMainMenu()
		{
			// Create two MenuItem objects and assign to array.
			MenuItem menuItem1 = new MenuItem();
			MenuItem menuItem2 = new MenuItem();
 
			menuItem1.Text = "&File";
			menuItem2.Text = "&Edit";
 
			// Create a MainMenu and assign MenuItem objects.
			MainMenu mainMenu1 = new MainMenu(new MenuItem[] {
						menuItem1,
						menuItem2});
    
			// Determine whether mainMenu1 contains menu items.  
			if (mainMenu1.IsParent) 
			{
				// Set the RightToLeft property for mainMenu1.
				mainMenu1.RightToLeft = RightToLeft.Yes;
				// Bind the MainMenu to Form1.
				Menu = mainMenu1;
			}	
		}