    Public Sub CreateMyMenu()
        ' Create a main menu object.
        Dim mainMenu1 As New MainMenu()

        ' Create empty menu item objects.
        Dim menuItem1 As New MenuItem()
        Dim menuItem2 As New MenuItem()

        ' Set the caption of the menu items.
        menuItem1.Text = "&File"
        menuItem2.Text = "&Edit"

        ' Add the menu items to the main menu.
        mainMenu1.MenuItems.Add(menuItem1)
        mainMenu1.MenuItems.Add(menuItem2)

        ' Add functionality to the menu items. 
        AddHandler menuItem1.Click, AddressOf Me.menuItem1_Click
        AddHandler menuItem2.Click, AddressOf Me.menuItem2_Click

        ' Assign mainMenu1 to the form.
        Me.Menu = mainMenu1

        ' Perform a click on the File menu item.
        menuItem1.PerformClick()
    End Sub 'CreateMyMenu


    Private Sub menuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MessageBox.Show("You clicked the File menu.", "The Event Information")
    End Sub 'menuItem1_Click


    Private Sub menuItem2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MessageBox.Show("You clicked the Edit menu.", "The Event Information")
    End Sub 'menuItem2_Click