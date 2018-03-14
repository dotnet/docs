' This sample demonstrates the IsSubsetOf, Union, Intersect, Copy, ToXml and FromXml methods
' of the ReflectionPermission class.
'<Snippet1>
Imports System
Imports System.Security
Imports System.Security.Permissions



Public Class ReflectionPermissionDemo

    ' Demonstrate all methods.
    Public Shared Sub Main(ByVal args() As String)
        IsSubsetOfDemo()
        CopyDemo()
        UnionDemo()
        IntersectDemo()
        ToFromXmlDemo()
        Console.WriteLine("Press the Enter key to exit.")
        Console.ReadLine()

    End Sub 'Main

    ' IsSubsetOf determines whether the current permission is a subset of the specified permission.
    '<Snippet2>
    Private Shared Sub IsSubsetOfDemo()

        Dim memberAccessPerm As New ReflectionPermission(ReflectionPermissionFlag.MemberAccess)
        '<Snippet8>
        Dim restrictedMemberAccessPerm As New ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess)
        '</Snippet8>
        If restrictedMemberAccessPerm.IsSubsetOf(memberAccessPerm) Then
            Console.WriteLine(restrictedMemberAccessPerm.Flags + " is a subset of " + memberAccessPerm.Flags)
        Else
            Console.WriteLine(restrictedMemberAccessPerm.Flags.ToString() + _
            " is not a subset of " + memberAccessPerm.Flags.ToString())
        End If

    End Sub 'IsSubsetOfDemo

    '</Snippet2>
    ' Union creates a new permission that is the union of the current permission and the specified permission.
    '<Snippet3>
    Private Shared Sub UnionDemo()
        Dim memberAccessPerm As New ReflectionPermission(ReflectionPermissionFlag.MemberAccess)
        Dim restrictedMemberAccessPerm As New ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess)
        Dim reflectionPerm3 As ReflectionPermission = _
                CType(memberAccessPerm.Union(restrictedMemberAccessPerm), ReflectionPermission)
        If reflectionPerm3 Is Nothing Then
            Console.WriteLine("The union of " + memberAccessPerm.Flags.ToString() + " and " + _
            restrictedMemberAccessPerm.Flags.ToString() + " is null.")
        Else
            Console.WriteLine("The union of " + memberAccessPerm.Flags.ToString() + _
            " and " + restrictedMemberAccessPerm.Flags.ToString() + " = " + _
            CType(reflectionPerm3, ReflectionPermission).Flags.ToString())
        End If

    End Sub 'UnionDemo


    '</Snippet3>
    ' Intersect creates and returns a new permission that is the intersection of the current
    ' permission and the permission specified.
    '<Snippet4>
    Private Shared Sub IntersectDemo()
        Dim memberAccessPerm As New ReflectionPermission(ReflectionPermissionFlag.MemberAccess)
        Dim restrictedMemberAccessPerm As New ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess)
        Dim reflectionPerm3 As ReflectionPermission = CType(memberAccessPerm.Intersect(restrictedMemberAccessPerm), ReflectionPermission)
        If Not (reflectionPerm3 Is Nothing) Then
            Console.WriteLine("The intersection of " + memberAccessPerm.Flags.ToString() + _
            " and " + restrictedMemberAccessPerm.Flags.ToString() + " = " + _
            CType(reflectionPerm3, ReflectionPermission).Flags.ToString())
        Else
            Console.WriteLine("The intersection of " + memberAccessPerm.Flags.ToString + " and " + _
                restrictedMemberAccessPerm.Flags.ToString() + " is null.")
        End If

    End Sub 'IntersectDemo


    '</Snippet4>
    'Copy creates and returns an identical copy of the current permission.
    '<Snippet5>
    Private Shared Sub CopyDemo()
        Dim memberAccessPerm As New ReflectionPermission(ReflectionPermissionFlag.MemberAccess)
        Dim restrictedMemberAccessPerm As ReflectionPermission = CType(memberAccessPerm.Copy(), ReflectionPermission)
        Console.WriteLine("Result of copy = " + restrictedMemberAccessPerm.ToString())

    End Sub 'CopyDemo

    '</Snippet5>
    ' ToXml creates an XML encoding of the permission and its current state;
    ' FromXml reconstructs a permission with the specified state from the XML encoding.
    '<Snippet6>
    Private Shared Sub ToFromXmlDemo()
        Dim memberAccessPerm As New ReflectionPermission(ReflectionPermissionFlag.MemberAccess)
        '<Snippet7>
        Dim restrictedMemberAccessPerm As New ReflectionPermission(PermissionState.None)
        '</Snippet7>
        restrictedMemberAccessPerm.FromXml(memberAccessPerm.ToXml())
        Console.WriteLine("Result of ToFromXml = " + restrictedMemberAccessPerm.ToString())

    End Sub 'ToFromXmlDemo
End Class 'ReflectionPermissionDemo
'</Snippet6>

' This code example creates the following output:
'RestrictedMemberAccess is not a subset of MemberAccess
'Result of copy = <IPermission class="System.Security.Permissions.ReflectionPermi
'ssion, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0
'89"
'version="1"
'Flags="MemberAccess"/>
'The union of MemberAccess and RestrictedMemberAccess = MemberAccess, RestrictedM
'emberAccess
'The intersection of MemberAccess and RestrictedMemberAccess is null.
'Result of ToFromXml = <IPermission class="System.Security.Permissions.Reflection
'Permission, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561
'934e089"
'version="1"
'Flags="MemberAccess"/>
'Press the Enter key to exit.
'</Snippet1>
