    ' Intersect creates and returns a new permission that is the intersection of the current
    ' permission and the permission specified.
    Private Function IntersectDemo() As Boolean 
        
        Dim returnValue As Boolean = True
        
        Dim snIdPerm1, snIdPerm2, snIdPerm3 As StrongNameIdentityPermission
        
        snIdPerm1 = New StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", New Version("1.0.0.0"))
        snIdPerm2 = New StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.MyFile", New Version("1.0.0.0"))
        
        Try
            
            snIdPerm3 = CType(snIdPerm1.Intersect(snIdPerm2), StrongNameIdentityPermission)
            
            Console.WriteLine("The intersection of MyCompany.MyDepartment.*" + "MyCompany.MyDepartment.MyFile is " + CType(snIdPerm3, StrongNameIdentityPermission).Name.ToString())
        
        Catch e As Exception
            Console.WriteLine("An exception was thrown: " + e.ToString())
            returnValue = False
        End Try
        
        Return returnValue
    
    End Function 'IntersectDemo
     