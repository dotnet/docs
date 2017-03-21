    // IsSubsetOf determines whether the current permission is a subset of the specified permission.
    private bool IsSubsetOfDemo()
    {

        bool returnValue = true;

        StrongNameIdentityPermission snIdPerm1, snIdPerm2;

        snIdPerm1 = new StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", new Version("1.0.0.0"));
        snIdPerm2 = new StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.MyFile", new Version("1.0.0.0"));

        if (snIdPerm1.IsSubsetOf(snIdPerm2))
        {

            Console.WriteLine("MyCompany.MyDepartment.* is a subset " +
            "of MyCompany.MyDepartment.MyFile \n");
        }
        else
        {
            Console.WriteLine("MyCompany.MyDepartment.*" +
            " is not a subset of MyCompany.MyDepartment.MyFile \n");
        }

        return returnValue;
    }