    ' Intersect creates and returns a new permission that is the intersection of the
    ' current permission and the permission specified.
    Private Shared Sub IntersectDemo()
        Dim uiPerm1 As New UIPermission(UIPermissionWindow.SafeTopLevelWindows, UIPermissionClipboard.OwnClipboard)
        Dim uiPerm2 As New UIPermission(UIPermissionWindow.SafeSubWindows, UIPermissionClipboard.NoClipboard)
        Dim p3 As UIPermission = CType(uiPerm1.Intersect(uiPerm2), UIPermission)

        Console.WriteLine("The intersection of " + uiPerm1.Window.ToString() + " and " + vbLf + vbTab + uiPerm2.Window.ToString() + " is " + p3.Window.ToString() + vbLf)
        Console.WriteLine("The intersection of " + uiPerm1.Clipboard.ToString() + " and " + vbLf + vbTab + uiPerm2.Clipboard.ToString() + " is " + p3.Clipboard.ToString() + vbLf)

    End Sub 'IntersectDemo

