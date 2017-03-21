	
	// Displays the shortcut menu, offsetting its location 
	// from the upper-left corner of Button1 by 20 pixels in each direction. 
	private void Button1_Click(System.Object sender, System.EventArgs e)
	{

		//Declare the menu items and the shortcut menu.
		MenuItem[] menuItems = new MenuItem[]{new MenuItem("Some Button Info"), 
			new MenuItem("Some Other Button Info"), new MenuItem("Exit")};

		ContextMenu buttonMenu = new ContextMenu(menuItems);
		buttonMenu.Show(Button1, new System.Drawing.Point(20, 20));
	}