' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates

Public Class Net46Code
    Public Shared Function SignECDsaSha512(data As Byte(), cert As X509Certificate2) As Byte()
        ' This would require using cert.Handle and a series of p/invokes to get at the
        ' underlying key, then passing that to a CngKey object, and passing that to
        ' new ECDsa(CngKey).  It's a lot of work.
        Throw New Exception("That's a lot of work...")
    End Function

    Public Shared Function SignECDsaSha512(data As Byte(), privateKey As ECDsa) As Byte()
        ' This way works, but SignData probably better matches what you want.
        Using hasher As SHA512 = SHA512.Create()
            Dim signature1 As Byte() = privateKey.SignHash(hasher.ComputeHash(data))
        End Using

        ' This might not be the ECDsa you got!
        Dim ecDsaCng As ECDsaCng = CType(privateKey, ECDsaCng)
        ecDsaCng.HashAlgorithm = CngAlgorithm.Sha512
        Return ecDsaCng.SignData(data)
    End Function
End Class
' </Snippet2>
