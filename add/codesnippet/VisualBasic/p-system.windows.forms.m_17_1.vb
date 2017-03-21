 Public Sub DisableMyChildMenus()
     ' Determine if menuItem2 is a parent menu.
     If menuItem2.IsParent = True Then
         ' Loop through all the submenus.
         Dim i As Integer
         For i = 0 To menuItem2.MenuItems.Count - 1
             ' Disable all of the submenus of menuItem2.
             menuItem2.MenuItems(i).Enabled = False
         Next i
     End If
 End Sub
