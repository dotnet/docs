 Public Sub CloneMyMenu()
 
     ' Clone the menu item and add it to the collection for the shortcut menu.
     contextMenu1.MenuItems.Add(menuItem1.CloneMenu())
     
 End Sub
