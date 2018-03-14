'<Snippet1>
Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text




Class Alice

    Public Shared Sub Main(ByVal args() As String)
        Using bob As New Bob()
            Using rsaKey As New RSACryptoServiceProvider()
                    ' Get Bob's public key
                    rsaKey.ImportCspBlob(bob.key)
                    Dim encryptedSessionKey As Byte() = Nothing
                    Dim encryptedMessage As Byte() = Nothing
                    Dim iv As Byte() = Nothing
                    Send(rsaKey, "Secret message", iv, encryptedSessionKey, encryptedMessage)
                    bob.Receive(iv, encryptedSessionKey, encryptedMessage)
            End Using
        End Using

    End Sub 'Main


    '<Snippet2>
    Private Shared Sub Send(ByVal key As RSA, ByVal secretMessage As String, ByRef iv() As Byte, ByRef encryptedSessionKey() As Byte, ByRef encryptedMessage() As Byte)
        Using aes = New AesCryptoServiceProvider()

            iv = aes.IV

            ' Encrypt the session key
            Dim keyFormatter As New RSAOAEPKeyExchangeFormatter(key)
            encryptedSessionKey = keyFormatter.CreateKeyExchange(aes.Key, GetType(Aes))

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
    Implements IDisposable
    Public key() As Byte
    Private rsaKey As New RSACryptoServiceProvider()

    Public Sub New()
        key = rsaKey.ExportCspBlob(False)

    End Sub 'New

    '<Snippet3>
    Public Sub Receive(ByVal iv() As Byte, ByVal encryptedSessionKey() As Byte, ByVal encryptedMessage() As Byte)

        Using aes = New AesCryptoServiceProvider()

            aes.IV = iv

            ' Decrypt the session key
            Dim keyDeformatter As New RSAOAEPKeyExchangeDeformatter(rsaKey)
            aes.Key = keyDeformatter.DecryptKeyExchange(encryptedSessionKey)

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

    End Sub 'Receive
    '</Snippet3>
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        rsaKey.Dispose()
    End Sub 'Dispose
End Class 'Bob
'</Snippet1>