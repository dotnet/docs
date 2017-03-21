    // Intersect creates and returns a new permission that is the intersection of the current
    // permission and the permission specified.
    bool IntersectDemo()
    {
        bool returnValue = true;
        StrongNameIdentityPermission^ snIdPerm1;
        StrongNameIdentityPermission^ snIdPerm2;
        StrongNameIdentityPermission^ snIdPerm3;
        snIdPerm1 = gcnew StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", gcnew Version("1.0.0.0"));
        snIdPerm2 = gcnew StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.MyFile", gcnew Version("1.0.0.0"));

        try
        {

            snIdPerm3 = dynamic_cast<StrongNameIdentityPermission^>(snIdPerm1->Intersect(snIdPerm2));

            Console::WriteLine("The intersection of MyCompany.MyDepartment.*" +
                "and MyCompany.MyDepartment.MyFile is " +
                (dynamic_cast<StrongNameIdentityPermission^>(snIdPerm3))->Name);
        }
        catch (Exception^ e)
        {
            Console::WriteLine("An exception was thrown: " + e);
            returnValue = false;
        }

        return returnValue;

    }

