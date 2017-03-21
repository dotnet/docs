    // IsSubsetOf determines whether the current permission is a subset of the specified permission.
    private static void IsSubsetOfDemo()
    {
        UIPermission uiPerm1 = new UIPermission(UIPermissionWindow.SafeTopLevelWindows);
        UIPermission uiPerm2 = new UIPermission(UIPermissionWindow.SafeSubWindows);
        CheckIsSubsetOfWindow(uiPerm1, uiPerm2);
        uiPerm1 = new UIPermission(UIPermissionClipboard.AllClipboard);
        uiPerm2 = new UIPermission(UIPermissionClipboard.OwnClipboard);
        CheckIsSubsetOfClipBoard(uiPerm1, uiPerm2);
    }
    private static void CheckIsSubsetOfWindow(UIPermission uiPerm1, UIPermission uiPerm2)
    {
        if (uiPerm1.IsSubsetOf(uiPerm2))
        {
            Console.WriteLine(uiPerm1.Window.ToString() + " is a subset of " +
                uiPerm2.Window.ToString());
        }
        else
        {
            Console.WriteLine(uiPerm1.Window.ToString() + " is not a subset of " +
                uiPerm2.Window.ToString());

        }
        if (uiPerm2.IsSubsetOf(uiPerm1))
        {
            Console.WriteLine(uiPerm2.Window.ToString() + " is a subset of " +
                uiPerm1.Window.ToString());
        }
        else
        {
            Console.WriteLine(uiPerm2.Window.ToString() + " is not a subset of " +
                uiPerm1.Window.ToString());

        }
    }
    private static void CheckIsSubsetOfClipBoard(UIPermission uiPerm1, UIPermission uiPerm2)
    {
        if (uiPerm1.IsSubsetOf(uiPerm2))
        {
            Console.WriteLine(uiPerm1.Clipboard.ToString() + " is a subset of " +
                uiPerm2.Clipboard.ToString());
        }
        else
        {
            Console.WriteLine(uiPerm1.Clipboard.ToString() + " is not a subset of " +
                uiPerm2.Clipboard.ToString());

        }
        if (uiPerm2.IsSubsetOf(uiPerm1))
        {
            Console.WriteLine(uiPerm2.Clipboard.ToString() + " is a subset of " +
                uiPerm1.Clipboard.ToString());
        }
        else
        {
            Console.WriteLine(uiPerm2.Clipboard.ToString() + " is not a subset of " +
                uiPerm1.Clipboard.ToString());

        }
    }