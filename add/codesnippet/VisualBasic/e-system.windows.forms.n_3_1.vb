    ' Initalize the NofifyIcon object's shortcut menu.
    Private Sub InitializeContextMenu()
        Dim menuList() As MenuItem = New MenuItem() _
                    {New MenuItem("Sign In"), New MenuItem("Get Help"), _
                    New MenuItem("Open")}
        Dim clickMenu As New ContextMenu(menuList)
        NotifyIcon1.ContextMenu = clickMenu
    End Sub


    ' When user clicks the left mouse button display the shortcut menu.  
    ' Use the SystemInformation.PrimaryMonitorMaximizedWindowSize property
    ' to place the menu at the lower corner of the screen.
    Private Sub NotifyIcon1_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles NotifyIcon1.Click

        Dim windowSize As System.Drawing.Size = _
            SystemInformation.PrimaryMonitorMaximizedWindowSize
        Dim menuPoint As System.Drawing.Point = New System.Drawing.Point _
            (windowSize.Width - 180, windowSize.Height - 5)
        menuPoint = Me.PointToClient(menuPoint)

        NotifyIcon1.ContextMenu.Show(Me, menuPoint)
    End Sub