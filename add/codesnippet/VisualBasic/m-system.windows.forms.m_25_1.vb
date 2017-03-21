    Private Sub InitializeMyMainMenu()
        ' Create the 2 menus and the menu items to add.
        Dim mainMenu1 As New MainMenu()
        Dim mainMenu2 As New MainMenu()

        Dim menuItem1 As New MenuItem()
        Dim menuItem2 As New MenuItem()

        ' Set the caption for the menu items.
        menuItem1.Text = "File"
        menuItem2.Text = "Edit"

        ' Add a menu item to each menu for displaying.
        mainMenu1.MenuItems.Add(menuItem1)
        mainMenu2.MenuItems.Add(menuItem2)

        ' Merge mainMenu2 with mainMenu1
        mainMenu1.MergeMenu(mainMenu2)

        ' Assign mainMenu1 to the form.
        Me.Menu = mainMenu1
    End Sub 'InitializeMyMainMenu