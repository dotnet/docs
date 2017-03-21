 Private Sub InitializeMyMainMenu()
     ' Create the MainMenu.
     Dim mainMenu1 As New MainMenu()
        
     ' Use the MenuItems property to call the Add method
     ' to add two new MenuItem objects to the MainMenu. 
     mainMenu1.MenuItems.Add("&File")
     mainMenu1.MenuItems.Add("&Edit")
        
     ' Assign mainMenu1 to the form.
     Me.Menu = mainMenu1
 End Sub
