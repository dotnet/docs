      ' Create a MenuStrip control with a new window.
      Dim ms As New MenuStrip()
      Dim windowMenu As New ToolStripMenuItem("Window")
      Dim windowNewMenu As New ToolStripMenuItem("New", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
      windowMenu.DropDownItems.Add(windowNewMenu)
      CType(windowMenu.DropDown, ToolStripDropDownMenu).ShowImageMargin = False
      CType(windowMenu.DropDown, ToolStripDropDownMenu).ShowCheckMargin = True
      
      ' Assign the ToolStripMenuItem that displays 
      ' the list of child forms.
      ms.MdiWindowListItem = windowMenu
      
      ' Add the window ToolStripMenuItem to the MenuStrip.
      ms.Items.Add(windowMenu)
      
      ' Dock the MenuStrip to the top of the form.
      ms.Dock = DockStyle.Top
      
      ' The Form.MainMenuStrip property determines the merge target.
      Me.MainMenuStrip = ms