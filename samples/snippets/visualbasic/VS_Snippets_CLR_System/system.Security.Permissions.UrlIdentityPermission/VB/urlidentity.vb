' <Snippet1>
Imports System.Security
Imports System.Security.Permissions



Public Class UrlIdentityPermissionDemo

    Public Shared Sub Main(ByVal args() As String)
        IsSubsetOfDemo()
        CopyDemo()
        IntersectDemo()
        ToFromXmlDemo()

    End Sub


    ' <Snippet2>
    ' IsSubsetOf determines whether the current permission is a subset of the specified permission.
    Private Shared Sub IsSubsetOfDemo()
        '<Snippet8>
        Dim permIdPerm1 As New UrlIdentityPermission("http://www.fourthcoffee.com/process/")
        '</Snippet8>
        Dim permIdPerm2 As New UrlIdentityPermission("http://www.fourthcoffee.com/*")

        If permIdPerm1.IsSubsetOf(permIdPerm2) Then
            Console.WriteLine(permIdPerm1.Url + " is a subset of " + permIdPerm2.Url)
        Else
            Console.WriteLine(permIdPerm1.Url + " is not a subset of " + permIdPerm2.Url)
        End If
        If permIdPerm2.IsSubsetOf(permIdPerm1) Then
            Console.WriteLine(permIdPerm2.Url + " is a subset of " + permIdPerm1.Url)
        Else
            Console.WriteLine(permIdPerm2.Url + " is not a subset of " + permIdPerm1.Url)
        End If

    End Sub

    ' </Snippet3>
    ' <Snippet4>
    ' Intersect creates and returns a new permission that is the intersection of the
    ' current permission and the permission specified.
    Private Shared Sub IntersectDemo()

        Dim permIdPerm1 As New UrlIdentityPermission("http://www.fourthcoffee.com/process/")
        Dim permIdPerm2 As New UrlIdentityPermission("http://www.fourthcoffee.com/*")
        Dim p3 As UrlIdentityPermission = CType(permIdPerm1.Intersect(permIdPerm2), UrlIdentityPermission)

        If Not (p3 Is Nothing) Then
            Console.WriteLine("The intersection of " + permIdPerm1.Url + " and " + vbLf + vbTab + permIdPerm2.Url + " is " + p3.Url + vbLf)

        Else
            Console.WriteLine("The intersection of " + permIdPerm1.Url + " and " + vbLf + vbTab + permIdPerm2.Url + " is null." + vbLf)
        End If

    End Sub



    '</Snippet4>
    '<Snippet5>
    'Copy creates and returns an identical copy of the current permission.
    Private Shared Sub CopyDemo()

        Dim permIdPerm1 As New UrlIdentityPermission("http://www.fourthcoffee.com/process/*")
        '<Snippet7>
        Dim permIdPerm2 As New UrlIdentityPermission(PermissionState.None)
        '</Snippet7>
        permIdPerm2 = CType(permIdPerm1.Copy(), UrlIdentityPermission)
        If Not (permIdPerm2 Is Nothing) Then
            Console.WriteLine("The copy succeeded:  " + permIdPerm2.ToString() + " " + vbLf)
        End If

    End Sub

    '</Snippet5>
    '<Snippet6>
    ' ToXml creates an XML encoding of the permission and its current state; FromXml reconstructs a
    ' permission with the specified state from the XML encoding.
    Private Shared Sub ToFromXmlDemo()


        Dim permIdPerm1 As New UrlIdentityPermission("http://www.fourthcoffee.com/process/*")
        Dim permIdPerm2 As New UrlIdentityPermission(PermissionState.None)
        permIdPerm2.FromXml(permIdPerm1.ToXml())
        Dim result As Boolean = permIdPerm2.Equals(permIdPerm1)
        If result Then
            Console.WriteLine("Result of ToFromXml = " + permIdPerm2.ToString())
        Else
            Console.WriteLine(permIdPerm2.ToString())
            Console.WriteLine(permIdPerm1.ToString())
        End If

    End Sub
End Class
'</Snippet6>

' </Snippet1>
' This code example creates the following output:

'http://www.fourthcoffee.com/process/ is a subset of http://www.fourthcoffee.com/
'*
'http://www.fourthcoffee.com/* is not a subset of http://www.fourthcoffee.com/pro
'cess/
'The copy succeeded:  <IPermission class="System.Security.Permissions.UrlIdentity
'Permission, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561
'934e089"
'version="1"
'Url="http://www.fourthcoffee.com/process/*"/>


'The union of http://www.fourthcoffee.com/process/ and
'        http://www.fourthcoffee.com/* failed.
'The operation is ambiguous because the permission represents multiple identities
'.
'The intersection of http://www.fourthcoffee.com/process/ and
'        http://www.fourthcoffee.com/* is http://www.fourthcoffee.com/process/

'Result of ToFromXml = <IPermission class="System.Security.Permissions.UrlIdentit
'yPermission, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c56
'1934e089"
'version="1"
'Url="http://www.fourthcoffee.com/process/*"/>