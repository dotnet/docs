 public void CloneMyMenu()
 {
    // Determine if mainMenu1 is currently hosted on the form.
    if(mainMenu1.GetForm() != null)
    {
       // Create a copy of the MainMenu that is hosted on the form.
       MainMenu mainMenu2 = mainMenu1.CloneMenu();
       // Set the RightToLeft property for mainMenu2.
       mainMenu2.RightToLeft = RightToLeft.Yes;
    }
 }
