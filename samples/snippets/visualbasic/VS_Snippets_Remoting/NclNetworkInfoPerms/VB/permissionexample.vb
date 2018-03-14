 ' NclNetworkInfoPerms
Imports System
Imports System.Net
Imports System.Net.NetworkInformation

Public Class PermissionTest
    
    
    Public Shared Sub CreatePermission() 
        '<Snippet6>
        '<Snippet5>
        '<Snippet2>
        '<Snippet1>
        Dim unrestricted As New System.Net.NetworkInformation.NetworkInformationPermission( _
            System.Security.Permissions.PermissionState.Unrestricted)
        '</Snippet1>
        Console.WriteLine("Is unrestricted? " + unrestricted.IsUnrestricted().ToString())
        '</Snippet2>
        '<Snippet4>
        '<Snippet3>
        Dim read As New System.Net.NetworkInformation.NetworkInformationPermission( _ 
            System.Net.NetworkInformation.NetworkInformationAccess.Read)
        '</Snippet3>
        Dim copyPermission As System.Net.NetworkInformation.NetworkInformationPermission = _
            CType(read.Copy(), System.Net.NetworkInformation.NetworkInformationPermission)
        '</Snippet4>
        Dim unionPermission As System.Net.NetworkInformation.NetworkInformationPermission = _
            CType(read.Union(unrestricted), System.Net.NetworkInformation.NetworkInformationPermission)
        Console.WriteLine("Is subset?" + read.IsSubsetOf(unionPermission).ToString())
        '</Snippet5>
        Dim intersectPermission As System.Net.NetworkInformation.NetworkInformationPermission = _ 
            CType(read.Intersect(unrestricted), _ 
                  System.Net.NetworkInformation.NetworkInformationPermission)
        '</Snippet6>
        '<Snippet7>
        Dim permission As New System.Net.NetworkInformation.NetworkInformationPermission( _
            System.Security.Permissions.PermissionState.None)
        permission.AddPermission(System.Net.NetworkInformation.NetworkInformationAccess.Read)
        Console.WriteLine("Access is {0}", permission.Access)
        '</Snippet7>
    End Sub 'CreatePermission
    
    Public Shared Sub Main() 
        CreatePermission()
    
    End Sub 'Main
End Class 'PermissionTest

