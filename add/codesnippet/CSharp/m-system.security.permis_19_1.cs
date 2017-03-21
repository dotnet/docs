    //Copy creates and returns an identical copy of the current permission.
    private static void CopyDemo()
    {

        UIPermission uiPerm1 = new UIPermission(UIPermissionWindow.SafeTopLevelWindows);
        UIPermission uiPerm2 = new UIPermission(PermissionState.None);
        uiPerm2 = (UIPermission)uiPerm1.Copy();
        if (uiPerm2 != null)
        {
            Console.WriteLine("The copy succeeded:  " + uiPerm2.ToString() + " \n");
        }

    }