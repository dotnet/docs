    ' ToXml creates an XML encoding of the permission and its current state;
    'FromXml reconstructs a permission with the specified state from the XML encoding.
    Private Function ToFromXmlDemo() As Boolean 
        
        Dim returnValue As Boolean = True
        
        Dim snIdPerm1, snIdPerm2 As StrongNameIdentityPermission
        
        snIdPerm1 = New StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", New Version("1.0.0.0"))
        snIdPerm2 = New StrongNameIdentityPermission(PermissionState.None)
        snIdPerm2.FromXml(snIdPerm1.ToXml())
        Console.WriteLine("Result of ToFromXml = " + snIdPerm2.ToString() + vbLf)
        
        Return returnValue
    
    End Function 'ToFromXmlDemo
     