' <Snippet1>
Imports System
Imports System.Security.Cryptography

 _

Class DSASample


    Shared Sub Main()
        Try
            'Create a new instance of DSACryptoServiceProvider.
            Dim DSA As New DSACryptoServiceProvider()

            'The hash to sign.
            Dim Hash As Byte() = {59, 4, 248, 102, 77, 97, 142, 201, 210, 12, 224, 93, 25, 41, 100, 197, 213, 134, 130, 135}

            'Create an DSASignatureFormatter object and pass it the 
            'DSACryptoServiceProvider to transfer the key information.
            Dim DSAFormatter As New DSASignatureFormatter(DSA)

            'Set the hash algorithm to SHA1.
            DSAFormatter.SetHashAlgorithm("SHA1")

            'Create a signature for HashValue and return it.
            Dim SignedHash As Byte() = DSAFormatter.CreateSignature(Hash)

            'Create an DSASignatureDeformatter object and pass it the 
            'DSACryptoServiceProvider to transfer the key information.
            Dim DSADeformatter As New DSASignatureDeformatter(DSA)

            'Verify the hash and display the results to the console.
            If DSADeformatter.VerifySignature(Hash, SignedHash) Then
                Console.WriteLine("The signature was verified.")
            Else
                Console.WriteLine("The signature was not verified.")
            End If

        Catch e As CryptographicException
            Console.WriteLine(e.Message)
        End Try
    End Sub
End Class
' </Snippet1>