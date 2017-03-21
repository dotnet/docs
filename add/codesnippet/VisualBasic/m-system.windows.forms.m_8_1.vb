    Private Sub InitializeMyMainMenu()
        ' Create the MainMenu and the menu items to add.
        Dim mainMenu1 As New MainMenu()

        Dim menuItem1 As New MenuItem()
        Dim menuItem2 As New MenuItem()
        Dim menuItem3 As New MenuItem()
        Dim menuItem4 As New MenuItem()


        ' Set the caption for the menu items.
        menuItem1.Text = "File"
        menuItem2.Text = "Edit"
        menuItem3.Text = "View"

        ' Add 3 menu items to the MainMenu for displaying.
        mainMenu1.MenuItems.Add(menuItem1)
        mainMenu1.MenuItems.Add(menuItem2)
        mainMenu1.MenuItems.Add(menuItem3)

        ' Assign mainMenu1 to the form.
        Menu = mainMenu1

        ' Determine whether menuItem3 is currently being used.
        If (menuItem3.GetMainMenu() IsNot Nothing) Then
            ' Display the name of the form in which it is located.
            Label1.Text = menuItem3.GetMainMenu().GetForm().ToString()
        End If
    End Sub 'InitializeMyMainMenu 