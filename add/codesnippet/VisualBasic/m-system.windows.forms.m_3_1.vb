    Public Sub CreateMyMenu()
      ' Create a main menu object.
      Dim mainMenu1 As New MainMenu()

      ' Create empty menu item objects.
      Dim topMenuItem As New MenuItem()
      Dim menuItem1 As New MenuItem()

      ' Set the caption of the menu items.
      topMenuItem.Text = "&File"
      menuItem1.Text = "&Open"

      ' Add the menu items to the main menu.
      topMenuItem.MenuItems.Add(menuItem1)
      mainMenu1.MenuItems.Add(topMenuItem)

      ' Add functionality to the menu items using the Click event. 
      AddHandler menuItem1.Click, AddressOf Me.menuItem1_Click
      ' Assign mainMenu1 to the form.
      Me.Menu = mainMenu1
   End Sub


   Private Sub menuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
      ' Create a new OpenFileDialog and display it.
      Dim fd As New OpenFileDialog()
      fd.DefaultExt = "*.*"
      fd.ShowDialog()
   End Sub