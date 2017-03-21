    // Intersect creates and returns a new permission that is the intersection of the current
    // permission and the permission specified.
    private bool IntersectDemo()
    {

        bool returnValue = true;

        StrongNameIdentityPermission snIdPerm1, snIdPerm2, snIdPerm3;

        snIdPerm1 = new StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", new Version("1.0.0.0"));
        snIdPerm2 = new StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.MyFile", new Version("1.0.0.0"));

        try
        {

            snIdPerm3 = (StrongNameIdentityPermission)snIdPerm1.Intersect(snIdPerm2);

            Console.WriteLine("The intersection of MyCompany.MyDepartment.*"
            + "MyCompany.MyDepartment.MyFile is "
            + ((StrongNameIdentityPermission)snIdPerm3).Name.ToString());

        }
        catch (Exception e)
        {
            Console.WriteLine("An exception was thrown: " + e);
            returnValue = false;
        }

        return returnValue;

    }