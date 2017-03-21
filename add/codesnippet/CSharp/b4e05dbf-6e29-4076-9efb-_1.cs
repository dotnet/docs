    // ToXml creates an XML encoding of the permission and its current state; FromXml reconstructs a
    // permission with the specified state from the XML encoding.
    private static void ToFromXmlDemo()
    {


        UIPermission uiPerm1 = new UIPermission(UIPermissionWindow.SafeTopLevelWindows);
        UIPermission uiPerm2 = new UIPermission(PermissionState.None);
        uiPerm2.FromXml(uiPerm1.ToXml());
        bool result = uiPerm2.Equals(uiPerm1);
        if (result)
        {
            Console.WriteLine("Result of ToFromXml = " + uiPerm2.ToString());
        }
        else
        {
            Console.WriteLine(uiPerm2.ToString());
            Console.WriteLine(uiPerm1.ToString());
        }

    }