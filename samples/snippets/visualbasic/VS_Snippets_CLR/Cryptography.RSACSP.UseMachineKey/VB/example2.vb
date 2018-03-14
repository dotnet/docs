' <SNIPPET2>
Imports System
Imports System.Security.Cryptography

Public Class RSAKeyStoreSample
    Public Shared Sub Main()
        ' Set the static UseMachineKeyStore property to use the machine key
        ' store instead of the user profile key store. All CSP instances not
        ' initialized with CspParameters will use this setting.
        RSACryptoServiceProvider.UseMachineKeyStore = True
        Try
            ' This CSP instance will use the Machine Store as set above and is
            ' initialized with no parameters.
            Using RSAalg As New RSACryptoServiceProvider()
                ShowContainerInfo(RSAalg.CspKeyContainerInfo)
                RSAalg.PersistKeyInCsp = False
            End Using

            Dim cspParams As New CspParameters()

            cspParams.KeyContainerName = "MyKeyContainer"

            ' This CSP instance will use the User Store since cspParams are used.
            Using RSAalg As New RSACryptoServiceProvider(cspParams)
                ShowContainerInfo(RSAalg.CspKeyContainerInfo)
                RSAalg.PersistKeyInCsp = False
            End Using

            cspParams.Flags = cspParams.Flags Or CspProviderFlags.UseMachineKeyStore

            ' This CSP instance will use the Machine Store. Although cspParams are used,
            ' the cspParams.Flags is set to CspProviderFlags.UseMachineKeyStore.
            Using RSAalg As New RSACryptoServiceProvider(cspParams)
                ShowContainerInfo(RSAalg.CspKeyContainerInfo)
                RSAalg.PersistKeyInCsp = False
            End Using
        Catch e As CryptographicException
            Console.WriteLine("Exception: {0}", e.GetType().FullName)
            Console.WriteLine(e.Message)

        End Try
    End Sub

    Public Shared Sub ShowContainerInfo(containerInfo As CspKeyContainerInfo)
        Dim keyStore As String

        Console.WriteLine()
        If containerInfo.MachineKeyStore Then
            keyStore = "Machine Store"
        Else
            keyStore = "User Store"
        End If
        Console.WriteLine("Key Store:     {0}", keyStore)
        Console.WriteLine("Key Provider:  {0}", containerInfo.ProviderName)
        Console.WriteLine("Key Container: ""{0}""", containerInfo.KeyContainerName)
        Console.WriteLine("Generated:     {0}", containerInfo.RandomlyGenerated)
        Console.WriteLine("Key Nubmer:    {0}", containerInfo.KeyNumber)
        Console.WriteLine("Removable Key: {0}", containerInfo.Removable)
    End Sub
End Class
' </SNIPPET2>