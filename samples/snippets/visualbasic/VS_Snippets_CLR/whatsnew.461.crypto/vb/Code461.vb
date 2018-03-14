' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates

Public Class Net461Code
    Public Shared Function SignECDsaSha512(data As Byte(), cert As X509Certificate2) As Byte()
        Using privateKey As ECDsa = cert.GetECDsaPrivateKey()
            Return privateKey.SignData(data, HashAlgorithmName.SHA512)
        End Using
    End Function

    Public Shared Function SignECDsaSha512(data As Byte, privateKey As ECDsa) As Byte()
        Return privateKey.SignData(data, HashAlgorithmName.SHA512)
    End Function
End Class
' </Snippet1>
