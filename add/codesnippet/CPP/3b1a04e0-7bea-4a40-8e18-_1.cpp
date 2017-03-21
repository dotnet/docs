    // Union creates a new permission that is the union of the current permission and the specified permission.
    bool UnionDemo()
    {
        bool returnValue = true;
        StrongNameIdentityPermission^ snIdPerm1;
        StrongNameIdentityPermission^ snIdPerm2;
        IPermission^ snIdPerm3;
        snIdPerm1 = gcnew StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", gcnew Version("1.0.0.0"));
        snIdPerm2 = gcnew StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.MyFile", gcnew Version("1.0.0.0"));
        snIdPerm3 = dynamic_cast<StrongNameIdentityPermission^>(snIdPerm1->Union( snIdPerm2 ));
        snIdPerm3 = snIdPerm1->Union( snIdPerm2 );

        try
        {
            Console::WriteLine("The union of MyCompany.MyDepartment.*" +
                "and MyCompany.MyDepartment.MyFile is " +
                (dynamic_cast<StrongNameIdentityPermission^>(snIdPerm3))->Name); 
        }
        catch (Exception^ e)
        {
            Console::WriteLine("An expected exception was thrown: " + e->Message);
        }


        return returnValue;
    }

