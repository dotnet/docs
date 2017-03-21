    ' IsSubsetOf determines whether the current permission is a subset of the specified permission.
    Private Function IsSubsetOfDemo() As Boolean 
        
        Dim returnValue As Boolean = True
        
        Dim snIdPerm1, snIdPerm2 As StrongNameIdentityPermission
        
        snIdPerm1 = New StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", New Version("1.0.0.0"))
        snIdPerm2 = New StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.MyFile", New Version("1.0.0.0"))
        
        If snIdPerm1.IsSubsetOf(snIdPerm2) Then
            
            Console.WriteLine("MyCompany.MyDepartment.* is a subset " + "of MyCompany.MyDepartment.MyFile " + vbLf)
        Else
            Console.WriteLine("MyCompany.MyDepartment.*" + " is not a subset of MyCompany.MyDepartment.MyFile " + vbLf)
        End If
        
        Return returnValue
    
    End Function 'IsSubsetOfDemo
    