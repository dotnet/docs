' <Snippet1>
Imports System
Imports System.Security
Imports System.Security.Permissions



Public Class ZoneIdentityPermissionDemo

    Public Shared Sub Main(ByVal args() As String)
        IsSubsetOfDemo()
        CopyDemo()
        UnionDemo()
        IntersectDemo()
        ToFromXmlDemo()

    End Sub 'Main


    ' <Snippet2>
    ' IsSubsetOf determines whether the current permission is a subset of the specified permission.
    Private Shared Sub IsSubsetOfDemo()
        '<Snippet8>
        Dim zoneIdPerm1 As New ZoneIdentityPermission(SecurityZone.Intranet)
        '</Snippet8>
        Dim zoneIdPerm2 As New ZoneIdentityPermission(SecurityZone.MyComputer)

        If zoneIdPerm1.IsSubsetOf(zoneIdPerm2) Then
            Console.WriteLine(zoneIdPerm1.SecurityZone.ToString() + " is a subset of " + zoneIdPerm2.SecurityZone.ToString())
        Else
            Console.WriteLine(zoneIdPerm1.SecurityZone.ToString() + " is not a subset of " + zoneIdPerm2.SecurityZone.ToString())
        End If

        If zoneIdPerm2.IsSubsetOf(zoneIdPerm1) Then
            Console.WriteLine(zoneIdPerm2.SecurityZone.ToString() + " is a subset of " + zoneIdPerm1.SecurityZone.ToString())
        Else
            Console.WriteLine(zoneIdPerm2.SecurityZone.ToString() + " is not a subset of " + zoneIdPerm1.SecurityZone.ToString())
        End If

    End Sub 'IsSubsetOfDemo

    ' </Snippet2>
    ' <Snippet3>
    ' Union creates a new permission that is the union of the current permission
    ' and the specified permission.
    Private Shared Sub UnionDemo()
        Dim zoneIdPerm1 As New ZoneIdentityPermission(SecurityZone.Intranet)
        Dim zoneIdPerm2 As New ZoneIdentityPermission(SecurityZone.MyComputer)
        Dim p3 As ZoneIdentityPermission = CType(zoneIdPerm1.Union(zoneIdPerm2), ZoneIdentityPermission)
        Try
            If Not (p3 Is Nothing) Then
                Console.WriteLine("The union of " + zoneIdPerm1.SecurityZone.ToString() + " and " + vbLf + vbTab + zoneIdPerm2.SecurityZone.ToString() + " is " + vbLf + vbTab + p3.SecurityZone.ToString() + vbLf)

            Else
                Console.WriteLine("The union of " + zoneIdPerm1.SecurityZone.ToString() + " and " + vbLf + vbTab + zoneIdPerm2.SecurityZone.ToString() + " is null." + vbLf)
            End If
        Catch e As SystemException
            Console.WriteLine("The union of " + zoneIdPerm1.SecurityZone.ToString() + " and " + vbLf + vbTab + zoneIdPerm2.SecurityZone.ToString() + " failed.")

            Console.WriteLine(e.Message)
        End Try

    End Sub 'UnionDemo

    ' </Snippet3>
    ' <Snippet4>
    ' Intersect creates and returns a new permission that is the intersection of the
    ' current permission and the permission specified.
    Private Shared Sub IntersectDemo()

        Dim zoneIdPerm1 As New ZoneIdentityPermission(SecurityZone.Intranet)
        Dim zoneIdPerm2 As New ZoneIdentityPermission(SecurityZone.MyComputer)
        Dim p3 As ZoneIdentityPermission = CType(zoneIdPerm1.Intersect(zoneIdPerm2), ZoneIdentityPermission)

        If Not (p3 Is Nothing) Then
            Console.WriteLine("The intersection of " + zoneIdPerm1.SecurityZone.ToString() + " and " + vbLf + vbTab + zoneIdPerm2.SecurityZone.ToString() + " is " + p3.SecurityZone.ToString() + vbLf)

        Else
            Console.WriteLine("The intersection of " + zoneIdPerm1.SecurityZone.ToString() + " and " + vbLf + vbTab + zoneIdPerm2.SecurityZone.ToString() + " is null." + vbLf)
        End If

    End Sub 'IntersectDemo



    '</Snippet4>
    '<Snippet5>
    'Copy creates and returns an identical copy of the current permission.
    Private Shared Sub CopyDemo()

        Dim zoneIdPerm1 As New ZoneIdentityPermission(SecurityZone.Intranet)
        '<Snippet7>
        Dim zoneIdPerm2 As New ZoneIdentityPermission(PermissionState.None)
        '</Snippet7>
        zoneIdPerm2 = CType(zoneIdPerm1.Copy(), ZoneIdentityPermission)
        If Not (zoneIdPerm2 Is Nothing) Then
            Console.WriteLine("The copy succeeded:  " + zoneIdPerm2.ToString() + " " + vbLf)
        End If

    End Sub 'CopyDemo

    '</Snippet5>
    '<Snippet6>
    ' ToXml creates an XML encoding of the permission and its current state; FromXml reconstructs a
    ' permission with the specified state from the XML encoding.
    Private Shared Sub ToFromXmlDemo()


        Dim zoneIdPerm1 As New ZoneIdentityPermission(SecurityZone.Intranet)
        Dim zoneIdPerm2 As New ZoneIdentityPermission(PermissionState.None)
        zoneIdPerm2.FromXml(zoneIdPerm1.ToXml())
        Dim result As Boolean = zoneIdPerm2.Equals(zoneIdPerm1)
        If result Then
            Console.WriteLine("Result of ToFromXml = " + zoneIdPerm2.ToString())
        Else
            Console.WriteLine(zoneIdPerm2.ToString())
            Console.WriteLine(zoneIdPerm1.ToString())
        End If

    End Sub 'ToFromXmlDemo 
End Class 'ZoneIdentityPermissionDemo
'</Snippet6>

' </Snippet1>
' This code example creates the following output:

'Intranet is not a subset of MyComputer
'MyComputer is not a subset of Intranet
'The copy succeeded:  <IPermission class="System.Security.Permissions.ZoneIdentit
'yPermission, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c56
'1934e089"
'version="1"
'Zone="Intranet"/>


'The union of Intranet and
'        MyComputer is
'        NoZone

'The intersection of Intranet and
'        MyComputer is null.

'Result of ToFromXml = <IPermission class="System.Security.Permissions.ZoneIdenti
'tyPermission, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c5
'61934e089"
'version="1"
'Zone="Intranet"/>