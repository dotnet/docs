    // Union creates a new permission that is the union of the current permission and the specified permission.
    private bool UnionDemo()
    {

        bool returnValue = true;

        StrongNameIdentityPermission snIdPerm1, snIdPerm2;
        IPermission snIdPerm3;

        snIdPerm1 = new StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", new Version("1.0.0.0"));
        snIdPerm2 = new StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.MyFile", new Version("1.0.0.0"));

        snIdPerm3 = (StrongNameIdentityPermission)snIdPerm1.Union(snIdPerm2);

        try
        {
            Console.WriteLine("The union of MyCompany.MyDepartment.*" +
            "and MyCompany.MyDepartment.MyFile is " +
            ((StrongNameIdentityPermission)snIdPerm3).Name.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine("An expected exception was thrown: " + e.Message);
        }


        return returnValue;

    }