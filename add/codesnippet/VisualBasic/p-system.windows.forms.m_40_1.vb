 Public Sub SetupMyMenuItem()
     ' Set the caption for the menu item.
     menuItem1.Text = "&New"
     ' Assign a shortcut key.
     menuItem1.Shortcut = Shortcut.CtrlN
     ' Make the menu item visible.
     menuItem1.Visible = True
     ' Display the shortcut key combination.
     menuItem1.ShowShortcut = True
 End Sub
