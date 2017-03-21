    // IsSubsetOf determines whether the current permission is a subset of the specified permission.
    bool IsSubsetOfDemo()
    {
        bool returnValue = true;

        StrongNameIdentityPermission^ snIdPerm1;
        StrongNameIdentityPermission^ snIdPerm2;

        snIdPerm1 = gcnew StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", gcnew Version("1.0.0.0"));
        snIdPerm2 = gcnew StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.MyFile", gcnew Version("1.0.0.0"));

        if (snIdPerm1->IsSubsetOf(snIdPerm2))
        {

            Console::WriteLine("MyCompany.MyDepartment.* is a subset " +
                "of MyCompany.MyDepartment.MyFile \n");
        }
        else
        {
            Console::WriteLine("MyCompany.MyDepartment.*" +
                " is not a subset of MyCompany.MyDepartment.MyFile \n");
        }

        return returnValue;
    }

