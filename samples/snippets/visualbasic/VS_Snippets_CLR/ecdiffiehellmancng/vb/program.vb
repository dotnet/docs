'<Snippet1>
Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text




Class Alice
    Public Shared alicePublicKey() As Byte


    Public Shared Sub Main(ByVal args() As String)
        Using alice As New ECDiffieHellmanCng()
            alice.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash
            alice.HashAlgorithm = CngAlgorithm.Sha256
            alicePublicKey = alice.PublicKey.ToByteArray()
            Dim bob As New Bob()
            Dim k As CngKey = CngKey.Import(bob.bobPublicKey, CngKeyBlobFormat.EccPublicBlob)
            Dim aliceKey As Byte() = alice.DeriveKeyMaterial(CngKey.Import(bob.bobPublicKey, CngKeyBlobFormat.EccPublicBlob))
            Dim encryptedMessage As Byte() = Nothing
            Dim iv As Byte() = Nothing
            Send(aliceKey, "Secret message", encryptedMessage, iv)
            bob.Receive(encryptedMessage, iv)
        End Using
    End Sub 'Main


    '<Snippet2>
    Private Shared Sub Send(ByVal key() As Byte, ByVal secretMessage As String, ByRef encryptedMessage() As Byte, ByRef iv() As Byte)
        Using aes As New AesCryptoServiceProvider()
            aes.Key = key
            iv = aes.IV

            ' Encrypt the message
            Using ciphertext As New MemoryStream()
                Using cs As New CryptoStream(ciphertext, aes.CreateEncryptor(), CryptoStreamMode.Write)
                    Dim plaintextMessage As Byte() = Encoding.UTF8.GetBytes(secretMessage)
                    cs.Write(plaintextMessage, 0, plaintextMessage.Length)
                    cs.Close()
                    encryptedMessage = ciphertext.ToArray()
                End Using
            End Using
        End Using

    End Sub 'Send 
    '</Snippet2>
End Class 'Alice

Public Class Bob
    Public bobPublicKey() As Byte
    Private bobKey() As Byte

    Public Sub New()
        Using bob As New ECDiffieHellmanCng()

            bob.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash
            bob.HashAlgorithm = CngAlgorithm.Sha256
            bobPublicKey = bob.PublicKey.ToByteArray()
            bobKey = bob.DeriveKeyMaterial(CngKey.Import(Alice.alicePublicKey, CngKeyBlobFormat.EccPublicBlob))
        End Using

    End Sub 'New


    '<Snippet3>
    Public Sub Receive(ByVal encryptedMessage() As Byte, ByVal iv() As Byte)

        Using aes As New AesCryptoServiceProvider()
                aes.Key = bobKey
                aes.IV = iv
                ' Decrypt the message
            Using plaintext As New MemoryStream()
                Using cs As New CryptoStream(plaintext, aes.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(encryptedMessage, 0, encryptedMessage.Length)
                    cs.Close()
                    Dim message As String = Encoding.UTF8.GetString(plaintext.ToArray())
                    Console.WriteLine(message)
                End Using
            End Using
        End Using
'</Snippet3>
    End Sub 'Receive
End Class 'Bob 
'</Snippet1>