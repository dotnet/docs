    Private Shared Sub Send(ByVal key As RSA, ByVal secretMessage As String, ByRef iv() As Byte, ByRef encryptedSessionKey() As Byte, ByRef encryptedMessage() As Byte)
        Dim aes = New AesCryptoServiceProvider()
        Try
            iv = aes.IV

            ' Encrypt the session key
            Dim keyFormatter As New RSAPKCS1KeyExchangeFormatter(key)
            encryptedSessionKey = keyFormatter.CreateKeyExchange(aes.Key, GetType(Aes))

            ' Encrypt the message
            Dim ciphertext As New MemoryStream()
            Try
                Dim cs As New CryptoStream(ciphertext, aes.CreateEncryptor(), CryptoStreamMode.Write)
                Try
                    Dim plaintextMessage As Byte() = Encoding.UTF8.GetBytes(secretMessage)
                    cs.Write(plaintextMessage, 0, plaintextMessage.Length)
                    cs.Close()

                    encryptedMessage = ciphertext.ToArray()
                Finally
                    cs.Dispose()
                End Try
            Finally
                ciphertext.Dispose()
            End Try
        Finally
            aes.Dispose()
        End Try

    End Sub 'Send 