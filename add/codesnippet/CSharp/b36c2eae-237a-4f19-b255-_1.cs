    // Intersect creates and returns a new permission that is the intersection of the
    // current permission and the permission specified.
    private static void IntersectDemo()
    {
        UIPermission uiPerm1 = new UIPermission(UIPermissionWindow.SafeTopLevelWindows, UIPermissionClipboard.OwnClipboard);
        UIPermission uiPerm2 = new UIPermission(UIPermissionWindow.SafeSubWindows, UIPermissionClipboard.NoClipboard);
        UIPermission p3 = (UIPermission)uiPerm1.Intersect(uiPerm2);

        Console.WriteLine("The intersection of " + uiPerm1.Window.ToString() + " and \n\t" +
            uiPerm2.Window.ToString() + " is " + p3.Window.ToString() + "\n");
        Console.WriteLine("The intersection of " + uiPerm1.Clipboard.ToString() + " and \n\t" +
                uiPerm2.Clipboard.ToString() + " is " + p3.Clipboard.ToString() + "\n");

    }