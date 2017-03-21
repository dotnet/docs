    Public Sub CreateMyMenuItems()
        ' Craete a main menu object.
        Dim mainMenu1 As New MainMenu()

        ' Create three top-level menu items.
        Dim menuItem1 As New MenuItem("&File")
        Dim menuItem2 As New MenuItem("&New")
        Dim menuItem3 As New MenuItem("&Open")

        ' Add menuItem1 to the main menu.
        mainMenu1.MenuItems.Add(menuItem1)

        ' Add menuItem2 and menuItem3 to menuItem1.
        menuItem1.MenuItems.Add(menuItem2)
        menuItem1.MenuItems.Add(menuItem3)

        ' Check to see if menuItem3 has a parent menu.
        If (menuItem3.Parent IsNot Nothing) Then
            MessageBox.Show(menuItem3.Parent.ToString() + ".", "Parent Menu Information of menuItem3")
        Else
            MessageBox.Show("No parent menu.")
        End If
        ' Assign mainMenu1 to the form.
        Me.Menu = mainMenu1
    End Sub 'CreateMyMenuItems