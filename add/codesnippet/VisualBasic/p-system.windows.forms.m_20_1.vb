 Public Sub CreateMyMenus()
     ' Create three top-level menu items.
     Dim menuItem1 As New MenuItem("&File")
     Dim menuItem2 As New MenuItem("&Options")
     Dim menuItem3 As New MenuItem("&Edit")
     ' Place the "Edit" menu on a new line in the menu bar.
     menuItem3.Break = True
 End Sub
