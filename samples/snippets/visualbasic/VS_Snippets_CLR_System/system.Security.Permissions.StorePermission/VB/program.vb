'<SNIPPET1>
Imports System
Imports System.Security.Permissions
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Security
Imports System.IO

<Assembly: StorePermissionAttribute(SecurityAction.RequestMinimum, Flags:=StorePermissionFlags.DeleteStore)> 

Public Class X509store2

    Public Shared Sub Main(ByVal args() As String)
        '<Snippet2>
        Console.WriteLine("Creating a permission with Flags = OpenStore.")
        Dim sp As New System.Security.Permissions.StorePermission(StorePermissionFlags.OpenStore)
        '</Snippet2>
        'Create a new X509 store named teststore from the local certificate store.
        'You must put in a valid path to a certificate in the following constructor.
        Dim certificate As New X509Certificate2("c:\certificates\*****.cer")
        ' Deny the permission to open a store.
        sp.Deny()
        ' The following code results in an exception due to an attempt to open a store.
        AddToStore(certificate)
        ' Remove the deny for opening a store.
        CodeAccessPermission.RevertDeny()
        ' The following code results in an exception due to an attempt to add a certificate.
        ' The exception is thrown due to a StorePermissionAttribute on the method denying AddToStore permission.
        AddToStore(certificate)
        ' The current code is not affected by the attribute in the previously called method, so the following
        ' intructions execute without an exception.
        Dim store As New X509Store("teststore", StoreLocation.CurrentUser)
        store.Open(OpenFlags.ReadWrite)
        store.Add(certificate)

        ' Demonstrate the behavior of the class members.
        ShowMembers()

        Console.WriteLine("Press the Enter key to exit.")
        Console.ReadKey()
        Return

    End Sub 'Main

    '<Snippet8>
    'Deny the permission the ability to add to a store.
    <StorePermission(SecurityAction.Deny, Flags:=StorePermissionFlags.AddToStore)> _
    Private Shared Sub AddToStore(ByVal cert As X509Certificate2)
        Try
            Dim store As New X509Store("teststore", StoreLocation.CurrentUser)
            store.Open(OpenFlags.ReadWrite)
            ' The following attempt to add a certificate results in an exception being thrown.
            store.Add(cert)
            Return
        Catch e As SecurityException
            Console.WriteLine("Security exception thrown when attempting: " + _
            CType(e.FirstPermissionThatFailed, System.Security.Permissions.StorePermission).Flags)
            Return
        End Try

    End Sub 'AddToStore

    '</Snippet8>
    ' The following method is intended to demonstrate only the behavior of 
    ' StorePermission class members,and not their practical usage.  Most properties 
    ' and methods in this class are used for the resolution and enforcement of
    ' security policy by the security infrastructure code.
    Private Shared Sub ShowMembers()
        Console.WriteLine("Creating first permission with Flags = OpenStore.")

        Dim sp1 As New System.Security.Permissions.StorePermission(StorePermissionFlags.OpenStore)

        Console.WriteLine("Creating second permission with Flags = AllFlags.")

        Dim sp2 As New System.Security.Permissions.StorePermission(StorePermissionFlags.AllFlags)

        Console.WriteLine("Creating third permission as Unrestricted.")
        '<Snippet9>
        Dim sp3 As New System.Security.Permissions.StorePermission(PermissionState.Unrestricted)
        '</Snippet9>
        Console.WriteLine("Creating fourth permission with a permission state of none.")

        Dim sp4 As New System.Security.Permissions.StorePermission(PermissionState.None)
        '<Snippet3>
        Dim rc As Boolean = sp2.IsSubsetOf(sp3)
        Console.WriteLine("Is the permission with complete store access (AllFlags) a subset of " + _
        vbLf + vbTab + "the permission with an Unrestricted permission state? " + _
        IIf(rc, "Yes", "No"))
        rc = sp1.IsSubsetOf(sp2)
        Console.WriteLine("Is the permission with OpenStore access a subset of the permission with " + _
        vbLf + vbTab + "complete store access (AllFlags)? " + IIf(rc, "Yes", "No"))
        '</Snippet3>
        '<Snippet4>
        rc = sp3.IsUnrestricted()
        Console.WriteLine("Is the third permission unrestricted? " + IIf(rc, "Yes", "No"))
        '</Snippet4>
        '<Snippet5>
        Console.WriteLine("Copying the second permission to the fourth permission.")
        sp4 = CType(sp2.Copy(), System.Security.Permissions.StorePermission)
        rc = sp4.Equals(sp2)
        Console.WriteLine("Is the fourth permission equal to the second permission? " + _
        IIf(rc, "Yes", "No"))
        '</Snippet5>
        '<Snippet10>
        Console.WriteLine("Creating the intersection of the second and first permissions.")
        sp4 = CType(sp2.Intersect(sp1), System.Security.Permissions.StorePermission)
        Console.WriteLine("Value of the Flags property is: " + sp4.Flags.ToString())

        '</Snippet10>
        '<Snippet6>
        Console.WriteLine("Creating the union of the second and first permissions.")
        sp4 = CType(sp2.Union(sp1), System.Security.Permissions.StorePermission)
        Console.WriteLine("Result of the union of the second permission with the first:  " + _
        sp4.Flags)

        '</Snippet6>
        '<Snippet7>
        Console.WriteLine("Using an XML roundtrip to reset the fourth permission.")
        sp4.FromXml(sp2.ToXml())
        rc = sp4.Equals(sp2)
        Console.WriteLine("Does the XML roundtrip result equal the original permission? " + _
        IIf(rc, "Yes", "No"))
        '</Snippet7>
    End Sub
End Class 'X509store2
'</Snippet1>