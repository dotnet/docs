    ' Union creates a new permission that is the union of the current permission and the specified permission.
    Private Function UnionDemo() As Boolean 
        
        Dim returnValue As Boolean = True
        
        Dim snIdPerm1, snIdPerm2 As StrongNameIdentityPermission
        Dim snIdPerm3 As IPermission
        
        snIdPerm1 = New StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", New Version("1.0.0.0"))
        snIdPerm2 = New StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.MyFile", New Version("1.0.0.0"))
        
        snIdPerm3 = CType(snIdPerm1.Union(snIdPerm2), StrongNameIdentityPermission)
        
        Try
            Console.WriteLine("The union of MyCompany.MyDepartment.*" + "and MyCompany.MyDepartment.MyFile is " + CType(snIdPerm3, StrongNameIdentityPermission).Name.ToString())
        Catch e As Exception
            Console.WriteLine("An expected exception was thrown: " + e.Message)
        End Try
        
        
        Return returnValue
    
    End Function 'UnionDemo
     