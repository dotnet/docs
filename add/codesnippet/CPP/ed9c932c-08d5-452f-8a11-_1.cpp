    // ToXml creates an XML encoding of the permission and its current state;
    //FromXml reconstructs a permission with the specified state from the XML encoding.
    bool ToFromXmlDemo()
    {
        bool returnValue = true;
        StrongNameIdentityPermission^ snIdPerm1;
        StrongNameIdentityPermission^ snIdPerm2;
        snIdPerm1 = gcnew StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", gcnew Version("1.0.0.0"));    
        snIdPerm2 = gcnew StrongNameIdentityPermission(PermissionState::None);
        snIdPerm2->FromXml(snIdPerm1->ToXml());
        Console::WriteLine("Result of ToFromXml = " + snIdPerm2->ToString() + "\n");

        return returnValue;
    }


public:
