'<Snippet1>
' To execute this sample you will need two certification files, MyCert1.cer and MyCert2.cer.
' The certification files can be created using the Certification Creation Tool, MakeCert.exe.
Imports System
Imports System.Security
Imports System.Security.Permissions
Imports System.Security.Cryptography.X509Certificates
Imports System.IO



Public Class PublisherIdentityPermissionDemo
    Private Shared publisherCertificate(1) As X509Certificate
    Private Shared publisherPerm1 As PublisherIdentityPermission
    Private Shared publisherPerm2 As PublisherIdentityPermission

    ' Demonstrate all methods.
    Public Shared Sub Main(ByVal args() As String)
        ' Initialize the PublisherIdentityPermissions for use in the sample
        '<Snippet8>
        Dim fs1 As New FileStream("..\..\..\MyCert1.cer", FileMode.Open)
        Dim certSBytes1(Fix(fs1.Length)) As [Byte]
        fs1.Read(certSBytes1, 0, Fix(fs1.Length))
        publisherCertificate(0) = New X509Certificate(certSBytes1)
        fs1.Close()
        Dim fs2 As New FileStream("..\..\..\MyCert2.cer", FileMode.Open)
        Dim certSBytes2(Fix(fs2.Length)) As [Byte]
        fs2.Read(certSBytes2, 0, Fix(fs2.Length))
        publisherCertificate(1) = New X509Certificate(certSBytes2)
        fs2.Close()

        publisherPerm1 = New PublisherIdentityPermission(publisherCertificate(0))
        publisherPerm2 = New PublisherIdentityPermission(publisherCertificate(1))
        '</Snippet8>
        IsSubsetOfDemo()
        CopyDemo()
        UnionDemo()
        IntersectDemo()
        ToFromXmlDemo()

    End Sub 'Main

    ' IsSubsetOf determines whether the current permission is a subset of the specified permission.
    '<Snippet2>
    Private Shared Sub IsSubsetOfDemo()

        If publisherPerm2.IsSubsetOf(publisherPerm1) Then
            Console.WriteLine(publisherPerm2.Certificate.Subject.ToString() + _
            " is a subset of " + publisherPerm1.Certificate.Subject.ToString())
        Else
            Console.WriteLine(publisherPerm2.Certificate.Subject.ToString() + _
            " is not a subset of " + publisherPerm1.Certificate.Subject.ToString())
        End If

    End Sub 'IsSubsetOfDemo

    '</Snippet2>
    ' Union creates a new permission that is the union of the current permission and the specified permission.
    '<Snippet3>
    Private Shared Sub UnionDemo()
        Dim publisherPerm3 As PublisherIdentityPermission = CType(publisherPerm1.Union(publisherPerm2), PublisherIdentityPermission)
        If publisherPerm3 Is Nothing Then
            Console.WriteLine("The union of " + publisherPerm1.ToString() + " and " _
            + publisherPerm2.Certificate.Subject.ToString() + " is null.")
        Else
            Console.WriteLine("The union of " + publisherPerm1.Certificate.Subject.ToString() + _
            " and " + publisherPerm2.Certificate.Subject.ToString() + " = " + _
            CType(publisherPerm3, PublisherIdentityPermission).Certificate.Subject.ToString())
        End If

    End Sub 'UnionDemo


    '</Snippet3>
    ' Intersect creates and returns a new permission that is the intersection of the current
    ' permission and the permission specified.
    '<Snippet4>
    Private Shared Sub IntersectDemo()
        Dim publisherPerm3 As PublisherIdentityPermission = CType(publisherPerm1.Union(publisherPerm2), PublisherIdentityPermission)
        If Not (publisherPerm3 Is Nothing) Then
            Console.WriteLine("The intersection of " + publisherPerm1.Certificate.Subject.ToString() + " = " + _
            CType(publisherPerm3, PublisherIdentityPermission).Certificate.Subject.ToString())
        Else
            Console.WriteLine("The intersection of " + publisherPerm1.Certificate.Subject.ToString() + _
            " and " + publisherPerm2.Certificate.Subject.ToString() + " is null.")
        End If

    End Sub 'IntersectDemo


    '</Snippet4>
    'Copy creates and returns an identical copy of the current permission.
    '<Snippet5>
    Private Shared Sub CopyDemo()
        '<Snippet7>
        ' Create an empty PublisherIdentityPermission to serve as the target of the copy.
        publisherPerm2 = New PublisherIdentityPermission(PermissionState.None)
        publisherPerm2 = CType(publisherPerm1.Copy(), PublisherIdentityPermission)
        Console.WriteLine("Result of copy = " + publisherPerm2.ToString())

    End Sub 'CopyDemo
    '</Snippet7>
    '</Snippet5>
    ' ToXml creates an XML encoding of the permission and its current state;
    ' FromXml reconstructs a permission with the specified state from the XML encoding.
    '<Snippet6>
    Private Shared Sub ToFromXmlDemo()
        publisherPerm2 = New PublisherIdentityPermission(PermissionState.None)
        publisherPerm2.FromXml(publisherPerm1.ToXml())
        Console.WriteLine("Result of ToFromXml = " + publisherPerm2.ToString())

    End Sub 'ToFromXmlDemo
End Class 'PublisherIdentityPermissionDemo
'</Snippet6>

'</Snippet1>

