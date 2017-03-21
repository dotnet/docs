 Public Sub CloneMyMenu()
     ' Clone the existing MenuItem into the new MenuItem.
     Dim tempMenuItem As MenuItem = menuItem1.CloneMenu()
        
     ' Assign the cloned MenuItem to the ContextMenu.
     contextMenu1.MenuItems.Add(tempMenuItem)
 End Sub
