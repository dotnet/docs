	// Initalize the NofifyIcon object's shortcut menu.
	private void InitializeContextMenu()
	{
		MenuItem[] menuList = new MenuItem[]{new MenuItem("Sign In"),
			new MenuItem("Get Help"), new MenuItem("Open")};
		ContextMenu clickMenu = new ContextMenu(menuList);
		NotifyIcon1.ContextMenu = clickMenu;

		// Associate the event-handling method with 
		// the NotifyIcon object's click event.
		NotifyIcon1.Click +=new System.EventHandler(NotifyIcon1_Click);
	}


	// When user clicks the left mouse button display the shortcut menu.  
	// Use the SystemInformation.PrimaryMonitorMaximizedWindowSize property
	// to place the menu at the lower corner of the screen.
	private void NotifyIcon1_Click(object sender, System.EventArgs e)
	{
		System.Drawing.Size windowSize = 
			SystemInformation.PrimaryMonitorMaximizedWindowSize;
		System.Drawing.Point menuPoint = 
			new System.Drawing.Point(windowSize.Width-180, 
			windowSize.Height-5);
		menuPoint = this.PointToClient(menuPoint);

		NotifyIcon1.ContextMenu.Show(this, menuPoint);
		
	}