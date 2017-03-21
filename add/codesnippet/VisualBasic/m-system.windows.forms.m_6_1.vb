   Private Sub CloneMyMainMenu()
      ' Create the main menu.
      Dim mainMenu1 As New MainMenu()

      ' Create the menu items to add.
      Dim menuItem1 As New MenuItem()
      Dim menuItem2 As New MenuItem()
      Dim menuItem3 As New MenuItem()

      ' Set the caption for the menu items.
      menuItem1.Text = "File"
      menuItem2.Text = "Edit"
      menuItem3.Text = "View"

      ' Add the menu item to mainMenu1.
      mainMenu1.MenuItems.Add(menuItem1)
      mainMenu1.MenuItems.Add(menuItem2)
      mainMenu1.MenuItems.Add(menuItem3)

      ' Clone the mainMenu1 and name it mainMenu2.
      Dim mainMenu2 As MainMenu = mainMenu1.CloneMenu()

      ' Assign mainMenu2 to the form.
      Menu = mainMenu2
   End Sub 'CloneMyMainMenu