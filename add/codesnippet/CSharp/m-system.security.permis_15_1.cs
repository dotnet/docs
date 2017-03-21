    //Copy creates and returns an identical copy of the current permission.
    private bool CopyDemo()
    {
        bool returnValue = true;

        StrongNameIdentityPermission snIdPerm1, snIdPerm2;

        snIdPerm1 = new StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", new Version("1.0.0.0"));
        snIdPerm2 = new StrongNameIdentityPermission(PermissionState.None);

        snIdPerm2 = (StrongNameIdentityPermission)snIdPerm1.Copy();
        Console.WriteLine("Result of copy = " + snIdPerm2.ToString() + "\n");

        return returnValue;
    }