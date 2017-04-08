 ' This sample demonstrates the IsSubsetOf, Union, Intersect, Copy, ToXml and FromXml methods
' of the EnvironmentPermission class.
' <Snippet1>
Imports System
Imports System.Security
Imports System.Security.Permissions
Imports System.Collections


Public Class EnvironmentPermissionDemo
    
    ' IsSubsetOf determines whether the current permission is a subset of the specified permission.
    '<Snippet2>
    Private Function IsSubsetOfDemo() As Boolean 
        Dim returnValue As Boolean = True
        Dim envPerm1 As New EnvironmentPermission(EnvironmentPermissionAccess.Read, "windir")
        Dim envPerm2 As New EnvironmentPermission(EnvironmentPermissionAccess.AllAccess, "TEMP")
        If envPerm1.IsSubsetOf(envPerm2) Then
            
            Console.WriteLine("'windir' is a subset of 'TEMP'" + vbLf)
        Else
            Console.WriteLine("windir" + " is not a subset of " + "TEMP" + vbLf)
        End If
        envPerm1.SetPathList(EnvironmentPermissionAccess.Read, "TEMP")
        
        If envPerm1.IsSubsetOf(envPerm2) Then
            
            Console.WriteLine("Read access is a subset of AllAccess" + vbLf)
        Else
            Console.WriteLine("Read access is not a subset of AllAccess" + vbLf)
        End If
        
        Return returnValue
    
    End Function 'IsSubsetOfDemo
    
    '</Snippet2>
    ' Union creates a new permission that is the union of the current permission and the specified permission.
    '<Snippet3>
    Private Function UnionDemo() As Boolean 
        Dim returnValue As Boolean = True
        Dim envIdPerm3 As IPermission
        Dim envPerm1 As New EnvironmentPermission(EnvironmentPermissionAccess.Read, "windir")
        Dim envPerm2 As New EnvironmentPermission(EnvironmentPermissionAccess.Read, "TEMP")
        envIdPerm3 = CType(envPerm1.Union(envPerm2), EnvironmentPermission)
        envIdPerm3 = envPerm1.Union(envPerm2)
        Console.WriteLine("The union of 'windir' and 'TEMP'" + " = " + _
        CType(envIdPerm3, EnvironmentPermission).GetPathList(EnvironmentPermissionAccess.Read).ToString())
        
        Return returnValue
    
    End Function 'UnionDemo
     
    '</Snippet3>
    ' Intersect creates and returns a new permission that is the intersection of
    ' the current permission and the permission specified.
    '<Snippet4>
    Private Function IntersectDemo() As Boolean 
        
        Dim envIdPerm3 As IPermission
        Dim returnValue As Boolean = True
        Dim envPerm1 As New EnvironmentPermission(EnvironmentPermissionAccess.Read, "windir")
        Dim envPerm2 As New EnvironmentPermission(EnvironmentPermissionAccess.Read, "TEMP")
        Try
            envIdPerm3 = CType(envPerm1.Intersect(envPerm2), EnvironmentPermission)
            If Not (envIdPerm3 Is Nothing) AndAlso Not (CType(envIdPerm3, _
            EnvironmentPermission).GetPathList(EnvironmentPermissionAccess.Read) Is Nothing) Then
                Console.WriteLine("The intersection of " + "windir" + " and " + "TEMP" + _
                " = " + CType(envIdPerm3, EnvironmentPermission).GetPathList(EnvironmentPermissionAccess.Read).ToString())
            Else
                Console.WriteLine("The intersection of " + "windir" + " and " + "TEMP" + " is null.")
            End If
        Catch e As Exception
            Console.WriteLine("An exception was thrown for intersection : " + e.Message)
            returnValue = False
        End Try
        
        Return returnValue
    
    End Function 'IntersectDemo
     
    '</Snippet4>
    'Copy creates and returns an identical copy of the current permission.
    '<Snippet5>
    Private Function CopyDemo() As Boolean 
        Dim returnValue As Boolean = True
        '<Snippet9>
        Dim envPerm1 As New EnvironmentPermission(EnvironmentPermissionAccess.Read, "windir")
        '</Snippet9>
        Try
            Dim envPerm2 As EnvironmentPermission = CType(envPerm1.Copy(), EnvironmentPermission)
            If Not (envPerm2 Is Nothing) Then
                Console.WriteLine("Result of copy = " + envPerm2.ToString() + vbLf)
            Else
                Console.WriteLine("Result of copy is null. " + vbLf)
            End If
        Catch e As Exception
            Console.WriteLine(e)
        End Try
        
        Return returnValue
    
    End Function 'CopyDemo
    
    '</Snippet5>
    ' ToXml creates an XML encoding of the permission and its current state; FromXml reconstructs
    ' a permission with the specified state from the XML encoding.
    '<Snippet6>
    Private Function ToFromXmlDemo() As Boolean 
        Dim returnValue As Boolean = True
        Dim envPerm1 As New EnvironmentPermission(EnvironmentPermissionAccess.Read, "windir")
        Dim envPerm2 As New EnvironmentPermission(PermissionState.None)
        envPerm2.FromXml(envPerm1.ToXml())
        Console.WriteLine("Result of ToFromXml = " + envPerm2.ToString() + vbLf)
        
        Return returnValue
    
    End Function 'ToFromXmlDemo
     
    '</Snippet6>
    ' AddPathList adds access for the specified environment variables to the existing state of the permission.
    ' SetPathList Sets the specified access to the specified environment variables to the existing state
    ' of the permission.
    ' GetPathList gets all environment variables with the specified EnvironmentPermissionAccess.
    '<Snippet7> 
    Private Function SetGetPathListDemo() As Boolean 
        Try
            Console.WriteLine("********************************************************" + vbLf)
            '<Snippet8>
            Console.WriteLine("Creating an EnvironmentPermission with AllAccess rights for 'TMP'")
            Dim envPerm1 As New EnvironmentPermission(EnvironmentPermissionAccess.AllAccess, "TMP")
            '</Snippet8>
            Console.WriteLine("Adding 'TEMP' to the write access list, and 'windir' to the read access list.")
            envPerm1.AddPathList(EnvironmentPermissionAccess.Write, "TEMP")
            envPerm1.AddPathList(EnvironmentPermissionAccess.Read, "windir")
            Console.WriteLine("Read access list before SetPathList = " + envPerm1.GetPathList(EnvironmentPermissionAccess.Read))
            Console.WriteLine("Setting read access to 'TMP'")
            envPerm1.SetPathList(EnvironmentPermissionAccess.Read, "TMP")
            Console.WriteLine("Read access list after SetPathList = " + envPerm1.GetPathList(EnvironmentPermissionAccess.Read))
            Console.WriteLine("Write access list = " + envPerm1.GetPathList(EnvironmentPermissionAccess.Write))
            Console.WriteLine("Write access environment variables = " + envPerm1.GetPathList(EnvironmentPermissionAccess.AllAccess))
        Catch e As ArgumentException
            ' EnvironmentPermissionAccess.AllAccess cannot be used as a parameter for GetPathList.
            Console.WriteLine("An ArgumentException occurred as a result of using AllAccess. " + _
            " This property cannot be used as a parameter in GetPathList, because it represents " + _
            "more than one type of environment variable : " + vbLf + e.Message)
        End Try
        
        Return True
    
    End Function 'SetGetPathListDemo
    
    '</Snippet7>
    ' Invoke all demos.
    Public Function RunDemo() As Boolean 
        
        Dim ret As Boolean = True
        Dim retTmp As Boolean
        ' Call IsSubsetOf demo.
        retTmp = IsSubsetOfDemo()
        If retTmp Then

            Console.Out.WriteLine("IsSubset demo completed successfully.")
        Else
            Console.Out.WriteLine("IsSubset demo failed.")
        End If
        ret = retTmp AndAlso ret

      
        ' Call Union demo.
        retTmp = UnionDemo()
        If retTmp Then

            Console.Out.WriteLine("Union demo completed successfully.")
        Else
            Console.Out.WriteLine("Union demo failed.")
        End If
        ret = retTmp AndAlso ret

      
        ' Call Intersect demo.
        retTmp = IntersectDemo()
        If retTmp Then

            Console.Out.WriteLine("Intersect demo completed successfully.")
        Else
            Console.Out.WriteLine("Intersect demo failed.")
        End If
        ret = retTmp AndAlso ret

      

      
        ' Call Copy demo.
        retTmp = CopyDemo()
        If retTmp Then

            Console.Out.WriteLine("Copy demo completed successfully.")
        Else
            Console.Out.WriteLine("Copy demo failed.")
        End If
        ret = retTmp AndAlso ret

      
        ' Call ToFromXml demo.
        retTmp = ToFromXmlDemo()
        If retTmp Then

            Console.Out.WriteLine("ToFromXml demo completed successfully.")
        Else
            Console.Out.WriteLine("ToFromXml demo failed.")
        End If
        ret = retTmp AndAlso ret

      
        ' Call SetGetPathList demo.
        retTmp = SetGetPathListDemo()
        If retTmp Then

            Console.Out.WriteLine("SetGetPathList demo completed successfully.")
        Else
            Console.Out.WriteLine("SetGetPathList demo failed.")
        End If
        ret = retTmp AndAlso ret
        
        Return ret
    
    End Function 'RunDemo
     
    ' Test harness.
    Public Shared Sub Main(ByVal args() As String) 
        Try
            Dim democase As New EnvironmentPermissionDemo()
            Dim ret As Boolean = democase.RunDemo()
            If ret Then
                Console.Out.WriteLine("EnvironmentPermission demo completed successfully.")
                Console.Out.WriteLine("Press the Enter key to exit.")
                Dim consoleInput As String = Console.ReadLine()
                System.Environment.ExitCode = 100
            Else
                Console.Out.WriteLine("EnvironmentPermission demo failed.")
                Console.Out.WriteLine("Press the Enter key to exit.")
                Dim consoleInput As String = Console.ReadLine()
                System.Environment.ExitCode = 101
            End If
        Catch e As Exception
            Console.Out.WriteLine("EnvironmentPermission demo failed.")
            Console.WriteLine(e.ToString())
            Console.Out.WriteLine("Press the Enter key to exit.")
            Dim consoleInput As String = Console.ReadLine()
            System.Environment.ExitCode = 101
        End Try
    
    End Sub 'Main
End Class 'EnvironmentPermissionDemo



'</Snippet1>