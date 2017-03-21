    Public Sub AddContextmenu()
        ' Create a shortcut menu.
        Dim m As New ContextMenu()
        Me.ContextMenu = m

        ' Create MenuItem objects.
        Dim menuItem1 As New MenuItem()
        Dim menuItem2 As New MenuItem()

        ' Set the Text property.
        menuItem1.Text = "New"
        menuItem2.Text = "Open"

        ' Add menu items to the MenuItems collection.
        m.MenuItems.Add(menuItem1)
        m.MenuItems.Add(menuItem2)

        ' Display the starting message.
        MessageBox.Show("Right-click the form to display the shortcut menu items")

        ' Add functionality to the menu items. 
        AddHandler menuItem1.Click, AddressOf Me.menuItem1_Click
        AddHandler menuItem2.Click, AddressOf Me.menuItem2_Click

    End Sub 'AddContextmenu


    Private Sub menuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim textReport As String = "You clicked the New menu item. " + vbCr + "It is contained in the following shortcut menu: " + vbCr + vbCr

        ' Get information on the shortcut menu in which menuitem1 is contained.
        textReport += ContextMenu.GetContextMenu().ToString()

        ' Display the shortcut menu information in a message box.
        MessageBox.Show(textReport, "The ContextMenu Information")
    End Sub 'menuItem1_Click


    Private Sub menuItem2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim textReport As String = "You clicked the Open menu item. " + vbCr + "It is contained in the following shortcut menu: " + vbCr + vbCr

        ' Get information on the shortcut menu in which menuitem1 is contained.
        textReport += ContextMenu.GetContextMenu().ToString()

        ' Display the shortcut menu information in a message box.
        MessageBox.Show(textReport, "The ContextMenu Information")
    End Sub 'menuItem2_Click