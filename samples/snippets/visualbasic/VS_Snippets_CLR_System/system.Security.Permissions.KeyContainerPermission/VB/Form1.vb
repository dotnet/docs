'<Snippet1>
Imports System
Imports System.Security
Imports System.Security.Permissions
Imports System.Security.Cryptography



Public Class KeyContainerPermissionDemo
    Private Shared cspParams As New CspParameters()
    Private Shared rsa As New RSACryptoServiceProvider()
    Private Shared providerName As String
    Private Shared providerType As Integer
    Private Shared myKeyContainerName As String
    ' Create three KeyContainerPermissionAccessEntry objects, each with a different constructor.
    '<Snippet2>
    Private Shared keyContainerPermAccEntry1 As _
        New KeyContainerPermissionAccessEntry("MyKeyContainer", KeyContainerPermissionFlags.Create)
    '</Snippet2>
    '<Snippet3>
    Private Shared keyContainerPermAccEntry2 As _
        New KeyContainerPermissionAccessEntry(cspParams, KeyContainerPermissionFlags.Open)
    '</Snippet3>
    '<Snippet4>
    Private Shared keyContainerPermAccEntry3 As _
        New KeyContainerPermissionAccessEntry("Machine", providerName, providerType, _
            myKeyContainerName, 1, KeyContainerPermissionFlags.Open)

    '</Snippet4>

    Public Shared Function Main() As Integer
        Try
            ' Create a key container for use in the sample.
            GenKey_SaveInContainer("MyKeyContainer")
            ' Initialize property values for creating a KeyContainerPermissionAccessEntry object.
            myKeyContainerName = rsa.CspKeyContainerInfo.KeyContainerName
            providerName = rsa.CspKeyContainerInfo.ProviderName
            providerType = rsa.CspKeyContainerInfo.ProviderType
            cspParams.KeyContainerName = myKeyContainerName
            cspParams.ProviderName = providerName
            cspParams.ProviderType = providerType

            ' Display the KeyContainerPermissionAccessEntry properties using 
            ' the third KeyContainerPermissionAccessEntry object.
            DisplayAccessEntryMembers()
            '<Snippet22>
            ' Add access entry objects to a key container permission.
            Dim keyContainerPerm1 As New KeyContainerPermission(PermissionState.Unrestricted)
            Console.WriteLine("Is the permission unrestricted? " + _
                keyContainerPerm1.IsUnrestricted().ToString())
            keyContainerPerm1.AccessEntries.Add(keyContainerPermAccEntry1)
            keyContainerPerm1.AccessEntries.Add(keyContainerPermAccEntry2)
            '</Snippet22>
            ' Display the permission.
            System.Console.WriteLine(keyContainerPerm1.ToXml().ToString())

            '<Snippet13>
            ' Create an array of KeyContainerPermissionAccessEntry objects
            Dim keyContainerPermAccEntryArray As KeyContainerPermissionAccessEntry() = _
                {keyContainerPermAccEntry1, keyContainerPermAccEntry2}

            ' Create a new KeyContainerPermission using the array.
            Dim keyContainerPerm2 As _
                New KeyContainerPermission(KeyContainerPermissionFlags.AllFlags, keyContainerPermAccEntryArray)
            '</Snippet13>
            DisplayPermissionMembers(keyContainerPerm2, keyContainerPermAccEntryArray)

            ' Demonstrate the effect of a deny for opening a key container.
            DenyOpen()
            ' Demonstrate the deletion of a key container.           
            DeleteContainer()

            Console.WriteLine("Press the Enter key to exit.")
            Console.Read()
            Return 0
            ' Close the current try block that did not expect an exception.
        Catch e As Exception
            Console.WriteLine("Unexpected exception thrown:  " + e.Message)
            Return 0
        End Try

    End Function 'Main


    Private Shared Sub DisplayAccessEntryMembers()
        '<Snippet5>
        Console.WriteLine(vbLf + "KeycontainerName is " + _
            keyContainerPermAccEntry3.KeyContainerName)
        '</Snippet5>
        '<Snippet6>
        Console.WriteLine("KeySpec is " + IIf(1 = keyContainerPermAccEntry3.KeySpec, _
            "AT_KEYEXCHANGE ", "AT_SIGNATURE"))
        '</Snippet6>
        '<Snippet7>
        Console.WriteLine("KeyStore is " + keyContainerPermAccEntry3.KeyStore)
        '</Snippet7>
        '<Snippet8>
        Console.WriteLine("ProviderName is " + keyContainerPermAccEntry3.ProviderName)
        '</Snippet8>
        '<Snippet9>
        Console.WriteLine("ProviderType is " + IIf(1 = keyContainerPermAccEntry3.ProviderType, _
            "PROV_RSA_FULL", keyContainerPermAccEntry3.ProviderType.ToString()))
        '</Snippet9>
        '<Snippet10>
        Console.WriteLine("Hashcode = " + keyContainerPermAccEntry3.GetHashCode().ToString())
        '</Snippet10>
        '<Snippet11>
        Console.WriteLine("Are the KeyContainerPermissionAccessEntry objects equal? " + _
            keyContainerPermAccEntry3.Equals(keyContainerPermAccEntry2).ToString())

    End Sub 'DisplayAccessEntryMembers
    '</Snippet11>

    Private Shared Sub DisplayPermissionMembers(ByVal keyContainerPermParam As _
        KeyContainerPermission, ByVal keyContainerPermAccEntryArrayParam() _
        As KeyContainerPermissionAccessEntry)
        Dim keyContainerPerm2 As KeyContainerPermission = keyContainerPermParam
        Dim keyContainerPermAccEntryArray As KeyContainerPermissionAccessEntry() = _
            keyContainerPermAccEntryArrayParam
        ' Display the KeyContainerPermission properties.
        '<Snippet12>
        Console.WriteLine(vbLf + "Flags value is " + keyContainerPerm2.Flags.ToString())
        '</Snippet12>
        '<Snippet14>
        Dim keyContainerPerm3 As KeyContainerPermission = _
            CType(keyContainerPerm2.Copy(), KeyContainerPermission)
        Console.WriteLine("Is the copy equal to the original? " + _
            keyContainerPerm3.Equals(keyContainerPerm2).ToString())
        '</Snippet14>
        '<Snippet15>
        ' Perform an XML roundtrip.
        keyContainerPerm3.FromXml(keyContainerPerm2.ToXml())
        Console.WriteLine("Was the XML roundtrip successful? " + _
            keyContainerPerm3.Equals(keyContainerPerm2).ToString())
        '</Snippet15>
        Dim keyContainerPerm4 As New KeyContainerPermission(KeyContainerPermissionFlags.Open, _
            keyContainerPermAccEntryArray)
        '<Snippet16>
        Dim keyContainerPerm5 As KeyContainerPermission = _
            CType(keyContainerPerm2.Intersect(keyContainerPerm4), KeyContainerPermission)
        Console.WriteLine("Flags value after the intersection is " + _
            keyContainerPerm5.Flags.ToString())
        '</Snippet16>
        '<Snippet17>
        keyContainerPerm5 = CType(keyContainerPerm2.Union(keyContainerPerm4), _
            KeyContainerPermission)
        '</Snippet17>
        '<Snippet18>
        Console.WriteLine("Flags value after the union is " + _
            keyContainerPerm5.Flags.ToString())
        '</Snippet18>
        '<Snippet19>
        Console.WriteLine("Is one permission a subset of the other? " + _
            keyContainerPerm4.IsSubsetOf(keyContainerPerm2).ToString())

    End Sub 'DisplayPermissionMembers
    '</Snippet19>

    Private Shared Sub GenKey_SaveInContainer(ByVal containerName As String)
        ' Create the CspParameters object and set the key container 
        ' name used to store the RSA key pair.
        cspParams = New CspParameters()

        cspParams.KeyContainerName = containerName

        ' Create a new instance of RSACryptoServiceProvider that accesses
        ' the key container identified by the containerName parameter.
        rsa = New RSACryptoServiceProvider(cspParams)

        ' Display the key information to the console.
        Console.WriteLine(vbLf + "Key added to container: " + vbLf + "  {0}", _
            rsa.ToXmlString(True))

    End Sub 'GenKey_SaveInContainer

    Private Shared Sub GetKeyFromContainer(ByVal containerName As String)
        Try
            cspParams = New CspParameters()
            cspParams.KeyContainerName = containerName

            ' Create a new instance of RSACryptoServiceProvider that accesses
            ' the key container identified by the containerName parameter.
            ' If the key container does not exist, a new one is created.
            rsa = New RSACryptoServiceProvider(cspParams)

            ' Use the rsa object to access the key. 
            ' Display the key information to the console.
            Console.WriteLine(vbLf + "Key retrieved from container : " + _
                vbLf + " {0}", rsa.ToXmlString(True))
            Console.WriteLine("KeycontainerName is " + rsa.CspKeyContainerInfo.KeyContainerName)
            Console.WriteLine("ProviderName is " + rsa.CspKeyContainerInfo.ProviderName)
            Console.WriteLine("ProviderType is " + IIf(1 = _
                rsa.CspKeyContainerInfo.ProviderType, "PROV_RSA_FULL", _
                rsa.CspKeyContainerInfo.ProviderType.ToString()))
        Catch e As Exception
            Console.WriteLine("Exception thrown:  " + e.Message)
        End Try

    End Sub 'GetKeyFromContainer

    Private Shared Sub DeleteKeyContainer(ByVal containerName As String)
        ' Create the CspParameters object and set the key container 
        ' name used to store the RSA key pair.
        cspParams = New CspParameters()
        cspParams.KeyContainerName = containerName

        ' Create a new instance of RSACryptoServiceProvider that accesses
        ' the key container.
        rsa = New RSACryptoServiceProvider(cspParams)

        ' Do not persist the key entry, effectively deleting the key.
        rsa.PersistKeyInCsp = False

        ' Call Clear to release the key container resources.
        rsa.Clear()
        Console.WriteLine(vbLf + "Key container released.")

    End Sub 'DeleteKeyContainer

    Private Shared Sub DenyOpen()
        Try
            '<Snippet20>
            ' Create a KeyContainerPermission with the right to open the key container.
            Dim keyContainerPerm As New KeyContainerPermission(KeyContainerPermissionFlags.Open)

            '</Snippet20>
            ' Demonstrate the results of a deny for an open action.
            keyContainerPerm.Deny()

            ' The next line causes an exception to be thrown when the infrastructure code attempts 
            ' to open the key container.
            Dim info As New CspKeyContainerInfo(cspParams)
        Catch e As Exception
            Console.WriteLine("Expected exception thrown: " + e.Message)
        End Try

        ' Revert the deny.
        CodeAccessPermission.RevertDeny()

    End Sub 'DenyOpen

    Private Shared Sub DeleteContainer()
        Try
            ' Create a KeyContainerPermission with the right to create a key container.
            Dim keyContainerPerm As New KeyContainerPermission(KeyContainerPermissionFlags.Create)

            ' Deny the ability to create a key container.
            ' This deny is used to show the key container has been successfully deleted.
            keyContainerPerm.Deny()

            ' Retrieve the key from the container.
            ' This code executes successfully because the key container already exists.
            ' The deny for permission to create a key container does not affect this method call.
            GetKeyFromContainer("MyKeyContainer")

            ' Delete the key and the container.
            DeleteKeyContainer("MyKeyContainer")

            ' Attempt to obtain the key from the deleted key container.
            ' This time the method call results in an exception because of
            ' an attempt to create a new key container.
            Console.WriteLine(vbLf + _
                "Attempt to create a new key container with create permission denied.")
            GetKeyFromContainer("MyKeyContainer")
        Catch e As CryptographicException
            Console.WriteLine("Expected exception thrown: " + e.Message)
        End Try

    End Sub 'DeleteContainer
End Class 'KeyContainerPermissionDemo
'</Snippet1>