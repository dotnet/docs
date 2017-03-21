
    ' Displays the shortcut menu, offsetting its location 
    ' from the upper-left corner of Button1 by 20 pixels in each direction. 
    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        'Declare the menu items and the shortcut menu.
        Dim menuItems() As MenuItem = New MenuItem() _
            {New MenuItem("Some Button Info"), _
            New MenuItem("Some Other Button Info"), _
            New MenuItem("Exit")}

        Dim buttonMenu As New ContextMenu(menuItems)
        buttonMenu.Show(Button1, New System.Drawing.Point(20, 20))
    End Sub