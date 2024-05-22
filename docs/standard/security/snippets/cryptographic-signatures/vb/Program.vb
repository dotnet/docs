Imports System.Security.Cryptography
Imports System.Text

Module Program
    Sub Main()

        Dim alg As SHA256 = SHA256.Create()

        Dim data As Byte() = Encoding.UTF8.GetBytes("Hello, from the .NET Docs!")
        Dim hash As Byte() = alg.ComputeHash(data)

        Dim sharedParameters As RSAParameters
        Dim signedHash As Byte()

        ' Generate signature
        Using rsa As RSA = RSA.Create()
            sharedParameters = rsa.ExportParameters(True)
            Dim rsaFormatter As New RSAPKCS1SignatureFormatter(rsa)
            rsaFormatter.SetHashAlgorithm(NameOf(SHA256))

            signedHash = rsaFormatter.CreateSignature(hash)
        End Using

        ' Verify signature
        Using rsa As RSA = RSA.Create()
            rsa.ImportParameters(sharedParameters)

            Dim rsaDeformatter As New RSAPKCS1SignatureDeformatter(rsa)
            rsaDeformatter.SetHashAlgorithm(NameOf(SHA256))

            If rsaDeformatter.VerifySignature(hash, signedHash) Then
                Console.WriteLine("The signature is valid.")
            Else
                Console.WriteLine("The signature is not valid.")
            End If
        End Using
    End Sub
End Module
