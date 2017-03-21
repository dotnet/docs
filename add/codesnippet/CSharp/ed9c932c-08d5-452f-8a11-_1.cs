    // ToXml creates an XML encoding of the permission and its current state;
    //FromXml reconstructs a permission with the specified state from the XML encoding.
    private bool ToFromXmlDemo()
    {

        bool returnValue = true;

        StrongNameIdentityPermission snIdPerm1, snIdPerm2;

        snIdPerm1 = new StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", new Version("1.0.0.0"));    
        snIdPerm2 = new StrongNameIdentityPermission(PermissionState.None);
        snIdPerm2.FromXml(snIdPerm1.ToXml());
        Console.WriteLine("Result of ToFromXml = " + snIdPerm2.ToString() + "\n");

        return returnValue;

    }