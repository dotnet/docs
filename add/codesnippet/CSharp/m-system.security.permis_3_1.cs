    // Union creates a new permission that is the union of the current permission
    // and the specified permission.
    private static void UnionDemo()
    {
        UIPermission uiPerm1 = new UIPermission(UIPermissionWindow.SafeTopLevelWindows);
        UIPermission uiPerm2 = new UIPermission(UIPermissionWindow.SafeSubWindows);
        UIPermission p3 = (UIPermission)uiPerm1.Union(uiPerm2);
        try
        {
            if (p3 != null)
            {
                Console.WriteLine("The union of " + uiPerm1.Window.ToString() +
                    " and \n\t" + uiPerm2.Window.ToString() + " is \n\t"
                    + p3.Window.ToString() + "\n");

            }
            else
            {
                Console.WriteLine("The union of " + uiPerm1.Window.ToString() +
                    " and \n\t" + uiPerm2.Window.ToString() + " is null.\n");
            }
        }
        catch (SystemException e)
        {
            Console.WriteLine("The union of " + uiPerm1.Window.ToString() +
                    " and \n\t" + uiPerm2.Window.ToString() + " failed.");

            Console.WriteLine(e.Message);
        }

    }