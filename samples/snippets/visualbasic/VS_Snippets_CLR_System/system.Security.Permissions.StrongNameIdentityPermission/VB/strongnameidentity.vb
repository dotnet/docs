 ' <Snippet1>
Imports System
Imports System.Security
Imports System.Security.Permissions




Public Class StrongNameIdentityDemo
    ' Public key
    Private Shared b1 As Byte() =  {0, 36, 0, 0, 4, 128, 0, 0, 148, 0, 0, 0, 6, 2, 0, 0, 0, 36, 0, 0, 82, 83, 65, 49, 0, 4, 0, 0, 1, 0, 1, 0, 237, 146, 145, 51, 34, 97, 123, 196, 90, 174, 41, 170, 173, 221, 41, 193, 175, 39, 7, 151, 178, 0, 230, 152, 218, 8, 206, 206, 170, 84, 111, 145, 26, 208, 158, 240, 246, 219, 228, 34, 31, 163, 11, 130, 16, 199, 111, 224, 4, 112, 46, 84, 0, 104, 229, 38, 39, 63, 53, 189, 0, 157, 32, 38, 34, 109, 0, 171, 114, 244, 34, 59, 9, 232, 150, 192, 247, 175, 104, 143, 171, 42, 219, 66, 66, 194, 191, 218, 121, 59, 92, 42, 37, 158, 13, 108, 210, 189, 9, 203, 204, 32, 48, 91, 212, 101, 193, 19, 227, 107, 25, 133, 70, 2, 220, 83, 206, 71, 102, 245, 104, 252, 87, 109, 190, 56, 34, 180}
    
    Private blob As New StrongNamePublicKeyBlob(b1)
    ' Use this version number.
    Private v1 As New Version("1.0.0.0")
    
    '<Snippet2>
    ' IsSubsetOf determines whether the current permission is a subset of the specified permission.
    Private Function IsSubsetOfDemo() As Boolean 
        
        Dim returnValue As Boolean = True
        
        Dim snIdPerm1, snIdPerm2 As StrongNameIdentityPermission
        
        '<Snippet8>
        snIdPerm1 = New StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", New Version("1.0.0.0"))
        '</Snippet8>
        snIdPerm2 = New StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.MyFile", New Version("1.0.0.0"))
        
        If snIdPerm1.IsSubsetOf(snIdPerm2) Then
            
            Console.WriteLine("MyCompany.MyDepartment.* is a subset " + "of MyCompany.MyDepartment.MyFile " + vbLf)
        Else
            Console.WriteLine("MyCompany.MyDepartment.*" + " is not a subset of MyCompany.MyDepartment.MyFile " + vbLf)
        End If
        
        Return returnValue
    
    End Function 'IsSubsetOfDemo
    
    '</Snippet2>
    '<Snippet3>
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
     
    '</Snippet3>
    '<Snippet4>
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
     
    '</Snippet4>
    '<Snippet5>
    'Copy creates and returns an identical copy of the current permission.
    Private Function CopyDemo() As Boolean 
        Dim returnValue As Boolean = True
        
        Dim snIdPerm1, snIdPerm2 As StrongNameIdentityPermission
        
        snIdPerm1 = New StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", New Version("1.0.0.0"))
        '<Snippet7>
        snIdPerm2 = New StrongNameIdentityPermission(PermissionState.None)
        '</Snippet7>
        snIdPerm2 = CType(snIdPerm1.Copy(), StrongNameIdentityPermission)
        Console.WriteLine("Result of copy = " + snIdPerm2.ToString() + vbLf)
        
        Return returnValue
    
    End Function 'CopyDemo
    
    '</Snippet5>
    '<Snippet6>
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
     
    '</Snippet6>
    ' Invoke all demos.
    Public Function runDemo() As Boolean

        Dim ret As Boolean = True
        Dim retTmp As Boolean
        ' Call the IsSubsetOf demo.
        retTmp = IsSubsetOfDemo()
        If retTmp Then
            Console.Out.WriteLine("IsSubsetOf demo completed successfully.")
        Else
            Console.Out.WriteLine("IsSubsetOf demo failed.")
        End If
        ret = retTmp AndAlso ret

        ' Call the Union demo.
        retTmp = UnionDemo()
        If retTmp Then
            Console.Out.WriteLine("Union demo completed successfully.")
        Else
            Console.Out.WriteLine("Union demo failed.")
        End If
        ret = retTmp AndAlso ret

        ' Call the Intersect demo.
        retTmp = IntersectDemo()
        If retTmp Then
            Console.Out.WriteLine("Intersect demo completed successfully.")
        Else
            Console.Out.WriteLine("Intersect demo failed.")
        End If
        ret = retTmp AndAlso ret


        ' Call the Copy demo.
        retTmp = CopyDemo()
        If retTmp Then
            Console.Out.WriteLine("Copy demo completed successfully")
        Else
            Console.Out.WriteLine("Copy demo failed.")
        End If
        ret = retTmp AndAlso ret

        ' Call the ToFromXml demo.	
        retTmp = ToFromXmlDemo()
        If retTmp Then
            Console.Out.WriteLine("ToFromXml demo completed successfully")
        Else
            Console.Out.WriteLine("ToFromXml demo failed.")
        End If
        ret = retTmp AndAlso ret

        Console.WriteLine("********************************************************" + ControlChars.Lf)


        Return ret
    End Function 'runDemo


    ' Test harness.
    Public Overloads Shared Sub Main(ByVal args() As [String])
        Try
            Dim democase As New StrongNameIdentityDemo()
            Dim ret As Boolean = democase.runDemo()
            If ret Then
                Console.Out.WriteLine("StrongNameIdentity demo completed successfully.")
                Console.Out.WriteLine("Press the Enter key to exit.")
                Dim consoleInput As String = Console.ReadLine()
                System.Environment.ExitCode = 100
            Else
                Console.Out.WriteLine("StrongNameIdentity demo failed.")
                Console.Out.WriteLine("Press the Enter key to exit.")
                Dim consoleInput As String = Console.ReadLine()
                System.Environment.ExitCode = 101
            End If
        Catch e As Exception
            Console.Out.WriteLine("StrongNameIdentity demo failed.")
            Console.WriteLine(e.ToString())
            Console.Out.WriteLine("Press the Enter key to exit.")
            Dim consoleInput As String = Console.ReadLine()
            System.Environment.ExitCode = 101
        End Try
    End Sub 'Main
End Class 'StrongNameIdentityDemo

' </Snippet1>

