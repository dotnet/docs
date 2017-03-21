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
			this.Menu = myMainMenu;
			
			// Clear the File menu items. 
			fileMenu.MenuItems.Clear(); 
		}