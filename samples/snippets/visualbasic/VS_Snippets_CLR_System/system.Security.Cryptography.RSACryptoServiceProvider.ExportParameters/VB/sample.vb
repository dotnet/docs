Imports System
Imports System.Security.Cryptography

Class RSACSPSample


    Shared Sub Main()
        ' <Snippet1>
        Try

            'Create a new RSACryptoServiceProvider object. 
            Dim RSA As New RSACryptoServiceProvider()

            'Export the key information to an RSAParameters object.
			'Pass false to export the public key information or pass
			'true to export public and private key information.
            Dim RSAParams As RSAParameters = RSA.ExportParameters(False)


        Catch e As CryptographicException
            'Catch this exception in case the encryption did
            'not succeed.
            Console.WriteLine(e.Message)
        End Try
        ' </Snippet1>
    End Sub
End Class