'<Snippet1>
Imports System
Imports System.Security.Permissions
Imports System.Security.Cryptography
Imports System.Security
Imports System.IO



Public Class DataProtect
    ' Create a byte array for additional entropy when using the
    ' Protect and Unprotect methods.
    Private Shared s_aditionalEntropy As Byte() = {9, 8, 7, 6, 5}

    Private Shared encryptedSecret() As Byte
    Private Shared originalData() As Byte

    Public Shared Sub Main(ByVal args() As String)
        '<Snippet2>
        Console.WriteLine("Creating a permission with the Flags property =" + " ProtectData.")
        Dim sp As New DataProtectionPermission(DataProtectionPermissionFlags.ProtectData)
        sp.PermitOnly()
        '</Snippet2>
        ' Protect the data
        ProtectData()
        ' This should fail without the correct permission
        UnprotectData()
        ' Revert the permission that limited access
        CodeAccessPermission.RevertPermitOnly()

        ' This should now work.
        UnprotectData()
        ' Demonstrate the behavior of the class members.
        ShowMembers()

        Console.WriteLine("Press the Enter key to exit.")
        Console.ReadKey()
        Return

    End Sub 'Main


    ' The following method is intended to demonstrate only the behavior of
    ' DataProtectionPermission class members,and not their practical usage.
    ' Most properties and methods in this class are used for the resolution
    ' and enforcement of security policy by the security infrastructure code.
    Private Shared Sub ShowMembers()
        Console.WriteLine("Creating four DataProtectionPermissions")
        Console.WriteLine("Creating the first permission with the Flags " + "property = ProtectData.")
        Dim sp1 As New DataProtectionPermission(DataProtectionPermissionFlags.ProtectData)

        Console.WriteLine("Creating the second permission with the Flags " + "property = AllFlags.")

        Dim sp2 As New DataProtectionPermission(DataProtectionPermissionFlags.AllFlags)

        Console.WriteLine("Creating the third permission with a permission " + "state = Unrestricted.")
        '<Snippet9>
        Dim sp3 As New DataProtectionPermission(PermissionState.Unrestricted)
        '</Snippet9>
        Console.WriteLine("Creating the fourth permission with a permission" + " state = None.")

        Dim sp4 As New DataProtectionPermission(PermissionState.None)
        '<Snippet3>
        Dim rc As Boolean = sp2.IsSubsetOf(sp3)
        Console.WriteLine("Is the permission with all flags set (AllFlags) " + "a subset of " + vbLf + " " + vbTab + "the permission with an Unrestricted " + "permission state? " + IIf(rc, "Yes", "No")) 'TODO: For performance reasons this should be changed to nested IF statements
        rc = sp1.IsSubsetOf(sp2)
        Console.WriteLine("Is the permission with ProtectData access a " + "subset of the permission with " + vbLf + vbTab + "AllFlags set? " + IIf(rc, "Yes", "No")) 'TODO: For performance reasons this should be changed to nested IF statements
        '</Snippet3>
        '<Snippet4>
        rc = sp3.IsUnrestricted()
        Console.WriteLine("Is the third permission unrestricted? " + IIf(rc, "Yes", "No")) 'TODO: For performance reasons this should be changed to nested IF statements
        '</Snippet4>
        '<Snippet5>
        Console.WriteLine("Copying the second permission to the fourth " + "permission.")
        sp4 = CType(sp2.Copy(), DataProtectionPermission)
        rc = sp4.Equals(sp2)
        Console.WriteLine("Is the fourth permission equal to the second " + "permission? " + IIf(rc, "Yes", "No")) 'TODO: For performance reasons this should be changed to nested IF statements
        '</Snippet5>
        '<Snippet10>
        Console.WriteLine("Creating the intersection of the second and " + "first permissions.")
        sp4 = CType(sp2.Intersect(sp1), DataProtectionPermission)
        Console.WriteLine("The value of the Flags property is: " + sp4.Flags.ToString())
        '</Snippet10>
        '<Snippet6>
        Console.WriteLine("Creating the union of the second and first " + "permissions.")
        sp4 = CType(sp2.Union(sp1), DataProtectionPermission)
        Console.WriteLine("Result of the union of the second permission with the first: " + sp4.Flags.ToString())
        '</Snippet6>
        '<Snippet7>
        Console.WriteLine("Using an XML round trip to reset the fourth " + "permission.")
        sp4.FromXml(sp2.ToXml())
        rc = sp4.Equals(sp2)
        Console.WriteLine("Does the XML round trip result equal the " + "original permission? " + IIf(rc, "Yes", "No")) 'TODO: For performance reasons this should be changed to nested IF statements

    End Sub 'ShowMembers

    '</Snippet7>

    ' Create a simple byte array containing data to be encrypted.
    Public Shared Sub ProtectData()
        Dim secret As Byte() = {0, 1, 2, 3, 4, 1, 2, 3, 4}

        'Encrypt the data.
        encryptedSecret = Protect(secret)
        Console.WriteLine("The encrypted byte array is:")
        If Not (encryptedSecret Is Nothing) Then
            PrintValues(encryptedSecret)
        End If

    End Sub 'ProtectData


    ' Decrypt the data and store in a byte array.
    Public Shared Sub UnprotectData()
        originalData = Unprotect(encryptedSecret)
        If Not (originalData Is Nothing) Then
            Console.WriteLine(vbCr + vbLf + "The original data is:")
            PrintValues(originalData)
        End If

    End Sub 'UnprotectData


    ' Encrypt data in the specified byte array.
    Public Shared Function Protect(ByVal data() As Byte) As Byte()
        Try
            ' Encrypt the data using DataProtectionScope.CurrentUser.
            ' The result can be decrypted only by the user who encrypted
            ' the data.
            Return ProtectedData.Protect(data, s_aditionalEntropy, DataProtectionScope.CurrentUser)
        Catch e As CryptographicException
            Console.WriteLine("Data was not encrypted. " + "An error has occurred.")
            Console.WriteLine(e.ToString())
            Return Nothing
        Catch e As SecurityException
            Console.WriteLine("Insufficient permissions. " + "An error has occurred.")
            Console.WriteLine(e.ToString())
            Return Nothing
        End Try

    End Function 'Protect


    ' Decrypt data in the specified byte array.
    Public Shared Function Unprotect(ByVal data() As Byte) As Byte()
        Try
            'Decrypt the data using DataProtectionScope.CurrentUser.
            Return ProtectedData.Unprotect(data, s_aditionalEntropy, DataProtectionScope.CurrentUser)
        Catch e As CryptographicException
            Console.WriteLine("Data was not decrypted. " + "An error has occurred.")
            Console.WriteLine(e.ToString())
            Return Nothing
        Catch e As SecurityException
            Console.WriteLine("Insufficient permissions. " + "An error has occurred.")
            Console.WriteLine(e.ToString())
            Return Nothing
        End Try

    End Function 'Unprotect


    Public Shared Sub PrintValues(ByVal myArr() As [Byte])
        Dim i As [Byte]
        For Each i In myArr
            Console.Write(vbTab + "{0}", i)
        Next i
        Console.WriteLine()

    End Sub 'PrintValues
End Class 'DataProtect 


'</Snippet1>