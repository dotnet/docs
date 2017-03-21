    //Copy creates and returns an identical copy of the current permission.
    bool CopyDemo()
    {
        bool returnValue = true;
        StrongNameIdentityPermission^ snIdPerm1;
        StrongNameIdentityPermission^ snIdPerm2;
        snIdPerm1 = gcnew StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", gcnew Version("1.0.0.0"));
        snIdPerm2 = gcnew StrongNameIdentityPermission(PermissionState::None);

        snIdPerm2 = dynamic_cast<StrongNameIdentityPermission^>(snIdPerm1->Copy());
        Console::WriteLine("Result of copy = " + snIdPerm2->ToString() + "\n");

        return returnValue;
    }

