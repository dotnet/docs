Imports System
Imports System.Security.Cryptography

 _

Class RSACSPSample


    Shared Sub Main()
        ' <Snippet1>
        Try
            'Create a new RSACryptoServiceProvider object. 
            Using RSA As New RSACryptoServiceProvider()

                'Export the key information to an RSAParameters object.
                'Pass false to export the public key information or pass
                'true to export public and private key information.
                Dim RSAParams As RSAParameters = RSA.ExportParameters(False)

                'Create another RSACryptoServiceProvider object.
                Using RSA2 As New RSACryptoServiceProvider()

                    'Import the the key information from the other 
                    'RSACryptoServiceProvider object.  
                    RSA2.ImportParameters(RSAParams)
                End Using
            End Using

        Catch e As CryptographicException
            'Catch this exception in case the encryption did
            'not succeed.
            Console.WriteLine(e.Message)
        End Try
        ' </Snippet1>
    End Sub
End Class
