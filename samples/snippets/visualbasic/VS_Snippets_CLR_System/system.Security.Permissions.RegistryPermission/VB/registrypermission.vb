' <Snippet1>
' This sample demonstrates the IsSubsetOf, Union, Intersect, Copy, ToXml, FromXml
' GetPathList, AddPathList, and SetPathList methods
' of the RegistryPermission class.

Imports System
Imports System.Security
Imports System.Security.Permissions
Imports System.Collections

Public Class RegistryPermissionDemo
    Private Shared readPerm1 As New RegistryPermission(RegistryPermissionAccess.Read, "HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0")
    Private Shared readPerm2 As New RegistryPermission(RegistryPermissionAccess.Read, "HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION")
    Private Shared readPerm3 As New RegistryPermission(RegistryPermissionAccess.Read, "HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\FloatingPointProcessor\0")
    Private Shared createPerm1 As New RegistryPermission(RegistryPermissionAccess.Create, "HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0")
    Private Shared readPerm4 As IPermission

    Public Shared Sub Main(ByVal args() As String)

        IsSubsetOfDemo()
        UnionDemo()
        IntersectDemo()
        CopyDemo()
        ToFromXmlDemo()
        SetGetPathListDemo()

    End Sub 'Main
    '<Snippet2>
    ' IsSubsetOf determines whether the current permission is a subset of the specified permission.
    Private Shared Function IsSubsetOfDemo() As Boolean

        Dim returnValue As Boolean = True

        If readPerm1.IsSubsetOf(readPerm2) Then

            Console.WriteLine(readPerm1.GetPathList(RegistryPermissionAccess.Read) + vbLf + " is a subset of " + readPerm2.GetPathList(RegistryPermissionAccess.Read) + vbLf)
        Else
            Console.WriteLine(readPerm1.GetPathList(RegistryPermissionAccess.Read) + vbLf + " is not a subset of " + readPerm2.GetPathList(RegistryPermissionAccess.Read) + vbLf)
        End If
        If createPerm1.IsSubsetOf(readPerm1) Then

            Console.WriteLine("RegistryPermissionAccess.Create" + vbLf + " is a subset of " + "RegistryPermissionAccess.Read" + vbLf)
        Else
            Console.WriteLine("RegistryPermissionAccess.Create" + vbLf + " is not a subset of " + "RegistryPermissionAccess.Read" + vbLf)
        End If

        Return returnValue

    End Function 'IsSubsetOfDemo

    '</Snippet2>
    '<Snippet3>
    ' Union creates a new permission that is the union of the current permission and
    ' the specified permission.
    Private Shared Function UnionDemo() As Boolean

        Dim returnValue As Boolean = True
        readPerm3 = CType(readPerm1.Union(readPerm2), RegistryPermission)

        If readPerm3 Is Nothing Then
            Console.WriteLine("The union of " + vbLf + readPerm1.GetPathList(RegistryPermissionAccess.Read) + " " + vbLf + "and " + readPerm2.GetPathList(RegistryPermissionAccess.Read) + " is null.")
        Else
            Console.WriteLine("The union of " + vbLf + readPerm1.GetPathList(RegistryPermissionAccess.Read) + " " + vbLf + "and " + readPerm2.GetPathList(RegistryPermissionAccess.Read) + " = " + vbLf + vbTab + CType(readPerm3, RegistryPermission).GetPathList(RegistryPermissionAccess.Read).ToString())
        End If

        Return returnValue

    End Function 'UnionDemo

    '</Snippet3>
    '<Snippet4>
    ' Intersect creates and returns a new permission that is the intersection of the
    ' current permission and the permission specified.
    Private Shared Function IntersectDemo() As Boolean

        Dim returnValue As Boolean = True

        readPerm3 = CType(readPerm1.Intersect(readPerm2), RegistryPermission)
        If Not (readPerm3 Is Nothing) AndAlso Not (readPerm3.GetPathList(RegistryPermissionAccess.Read) Is Nothing) Then

            Console.WriteLine("The intersection of " + vbLf + readPerm1.GetPathList(RegistryPermissionAccess.Read) + " " + vbLf + "and " + readPerm2.GetPathList(RegistryPermissionAccess.Read) + " = " + vbLf + vbTab + CType(readPerm3, RegistryPermission).GetPathList(RegistryPermissionAccess.Read).ToString())
        Else
            Console.WriteLine("The intersection of " + vbLf + readPerm2.GetPathList(RegistryPermissionAccess.Read) + " " + vbLf + "and " + readPerm2.GetPathList(RegistryPermissionAccess.Read) + " is null. ")
        End If

        Return returnValue

    End Function 'IntersectDemo

    '</Snippet4>
    '<Snippet5>
    'Copy creates and returns an identical copy of the current permission.
    Private Shared Function CopyDemo() As Boolean

        Dim returnValue As Boolean = True
        readPerm4 = CType(readPerm1.Copy(), RegistryPermission)
        If Not (readPerm4 Is Nothing) Then
            Console.WriteLine("Result of copy = " + readPerm4.ToXml().ToString() + vbLf)
        Else
            Console.WriteLine("Result of copy is null. " + vbLf)
        End If
        Return returnValue

    End Function 'CopyDemo

    '</Snippet5>
    '<Snippet6>
    ' ToXml creates an XML encoding of the permission and its current state; FromXml
    ' reconstructs a permission with the specified state from the XML encoding.
    Private Shared Function ToFromXmlDemo() As Boolean

        Dim returnValue As Boolean = True
        '<Snippet7>
        readPerm2 = New RegistryPermission(PermissionState.None)
        readPerm2.FromXml(readPerm1.ToXml())
        Console.WriteLine("Result of ToFromXml = " + readPerm2.ToString() + vbLf)
        '</Snippet7>

        Return returnValue

    End Function 'ToFromXmlDemo

    '</Snippet6>
    '<Snippet9> 
    ' AddPathList adds access for the specified registry variables to the existing state of the permission.
    ' SetPathList sets new access for the specified registry variable names to the existing state of the permission.
    ' GetPathList gets paths for all registry variables with the specified RegistryPermissionAccess.
    Private Shared Function SetGetPathListDemo() As Boolean
        Try
            Console.WriteLine("********************************************************" + vbLf)
            '<Snippet10>
            Dim readPerm1 As RegistryPermission
            Console.WriteLine("Creating RegistryPermission with AllAccess rights for 'HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0'")
            readPerm1 = New RegistryPermission(RegistryPermissionAccess.AllAccess, "HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0")
            '</Snippet10>
            Console.WriteLine("Adding 'HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION' to the write access list, " + "and " + vbLf + " 'HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\FloatingPointProcessor\0' " + "to the read access list.")
            readPerm1.AddPathList(RegistryPermissionAccess.Write, "HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION")
            readPerm1.AddPathList(RegistryPermissionAccess.Read, "HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\FloatingPointProcessor\0")
            Console.WriteLine("Read access list before SetPathList = " + readPerm1.GetPathList(RegistryPermissionAccess.Read))
            Console.WriteLine("Setting read access rights to " + vbLf + "'HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0'")
            readPerm1.SetPathList(RegistryPermissionAccess.Read, "HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0")
            Console.WriteLine("Read access list after SetPathList = " + vbLf + readPerm1.GetPathList(RegistryPermissionAccess.Read))
            Console.WriteLine("Write access = " + vbLf + readPerm1.GetPathList(RegistryPermissionAccess.Write))
            Console.WriteLine("Write access Registry variables = " + vbLf + readPerm1.GetPathList(RegistryPermissionAccess.AllAccess))
        Catch e As ArgumentException
            ' RegistryPermissionAccess.AllAccess can not be used as a parameter for GetPathList.
            Console.WriteLine("An ArgumentException occured as a result of using AllAccess. " + _
            "AllAccess cannot be used as a parameter in GetPathList because it represents more than one " + _
            "type of registry variable access : " + vbLf + e.Message)
        End Try

        Return True

    End Function 'SetGetPathListDemo

    '</Snippet9>

End Class 'RegistryPermissionDemo

'</Snippet1>
