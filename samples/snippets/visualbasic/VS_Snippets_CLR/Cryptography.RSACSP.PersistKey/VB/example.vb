' <SNIPPET1>
Imports System.Security.Cryptography

Module RSACSPExample

    Sub Main()

        Dim KeyContainerName As String = "MyKeyContainer"

        'Create a new key and persist it in 
        'the key container.  
        RSAPersistKeyInCSP(KeyContainerName)

        'Delete the key from the key container.
        RSADeleteKeyInCSP(KeyContainerName)
    End Sub


    Sub RSAPersistKeyInCSP(ByVal ContainerName As String)
        Try
            ' Create a new instance of CspParameters.  Pass
            ' 13 to specify a DSA container or 1 to specify
            ' an RSA container.  The default is 1.
            Dim cspParams As New CspParameters

            ' Specify the container name using the passed variable.
            cspParams.KeyContainerName = ContainerName

            'Create a new instance of RSACryptoServiceProvider to generate
            'a new key pair.  Pass the CspParameters class to persist the 
            'key in the container.  The PersistKeyInCsp property is True by 
            'default, allowing the key to be persisted. 
            Dim RSAalg As New RSACryptoServiceProvider(cspParams)

            'Indicate that the key was persisted.
            Console.WriteLine("The RSA key was persisted in the container, ""{0}"".", ContainerName)
        Catch e As CryptographicException
            Console.WriteLine(e.Message)
        End Try
    End Sub


    Sub RSADeleteKeyInCSP(ByVal ContainerName As String)
        Try
            ' Create a new instance of CspParameters.  Pass
            ' 13 to specify a DSA container or 1 to specify
            ' an RSA container.  The default is 1.
            Dim cspParams As New CspParameters

            ' Specify the container name using the passed variable.
            cspParams.KeyContainerName = ContainerName

            'Create a new instance of RSACryptoServiceProvider. 
            'Pass the CspParameters class to use the 
            'key in the container.
            Dim RSAalg As New RSACryptoServiceProvider(cspParams)

            'Explicitly set the PersistKeyInCsp property to False
            'to delete the key entry in the container.
            RSAalg.PersistKeyInCsp = False

            'Call Clear to release resources and delete the key from the container.
            RSAalg.Clear()

            'Indicate that the key was persisted.
            Console.WriteLine("The RSA key was deleted from the container, ""{0}"".", ContainerName)
        Catch e As CryptographicException
            Console.WriteLine(e.Message)
        End Try
    End Sub

End Module
' </SNIPPET1>