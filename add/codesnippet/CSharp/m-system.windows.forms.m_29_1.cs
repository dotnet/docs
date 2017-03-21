 private void InitializeMyMainMenu()
 {
    // Create the MainMenu.
    MainMenu mainMenu1 = new MainMenu();
    
    /* Use the MenuItems property to call the Add method
       to add two new MenuItem objects to the MainMenu. */
    mainMenu1.MenuItems.Add ("&File");
    mainMenu1.MenuItems.Add ("&Edit");
 
    // Assign mainMenu1 to the form.
    this.Menu = mainMenu1;
 }
    