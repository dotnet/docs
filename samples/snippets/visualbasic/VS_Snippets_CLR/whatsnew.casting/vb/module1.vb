Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates

Module Module1
   Sub Main()
      EncryptWithCasting()
      EncryptWithoutCasting()

      Console.ReadLine()
   End Sub


   Private Sub EncryptWithCasting()
      Dim data() As Byte = {1, 2, 4, 8, 16, 32, 64, 128}
      Dim cert As X509Certificate2 = New X509Certificate2()
      Try
         ' <Snippet1>
         Dim rsa As RSACryptoServiceProvider = CType(cert.PrivateKey, RSACryptoServiceProvider)
         Dim oaepEncrypted() As Byte = rsa.Encrypt(data, True)
         Dim pkcs1Encrypted() As Byte = rsa.Encrypt(data, False)
         ' </Snippet1>

      Catch e As Exception
         Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message)
      End Try
   End Sub

   Private Sub EncryptWithoutCasting()
      Dim data() As Byte = {1, 2, 4, 8, 16, 32, 64, 128}
      Dim cert As X509Certificate2 = New X509Certificate2()

      ' <Snippet2>
      Dim rsa As RSA = cert.GetRSAPrivateKey()
      If rsa Is Nothing Then
         Throw New InvalidOperationException("An RSA certificate was expected")
       End If

      Dim oaepEncrypted() As Byte = rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA1)
      Dim pkcs1Encrypted() As Byte = rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1)
      ' </Snippet2>
   End Sub
End Module
