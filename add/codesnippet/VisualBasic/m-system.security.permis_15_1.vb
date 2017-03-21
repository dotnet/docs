    'Copy creates and returns an identical copy of the current permission.
    Private Function CopyDemo() As Boolean 
        Dim returnValue As Boolean = True
        
        Dim snIdPerm1, snIdPerm2 As StrongNameIdentityPermission
        
        snIdPerm1 = New StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", New Version("1.0.0.0"))
        snIdPerm2 = New StrongNameIdentityPermission(PermissionState.None)
        snIdPerm2 = CType(snIdPerm1.Copy(), StrongNameIdentityPermission)
        Console.WriteLine("Result of copy = " + snIdPerm2.ToString() + vbLf)
        
        Return returnValue
    
    End Function 'CopyDemo
    