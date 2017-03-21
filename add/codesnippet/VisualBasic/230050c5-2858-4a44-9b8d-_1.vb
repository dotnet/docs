    Public Sub Receive(ByVal iv() As Byte, ByVal encryptedSessionKey() As Byte, ByVal encryptedMessage() As Byte)

        Dim aes = New AesCryptoServiceProvider()
        Try
            aes.IV = iv

            ' Decrypt the session key
            Dim keyDeformatter As New RSAPKCS1KeyExchangeDeformatter(rsaKey)
            aes.Key = keyDeformatter.DecryptKeyExchange(encryptedSessionKey)

            ' Decrypt the message
            Dim plaintext As New MemoryStream()
            Try
                Dim cs As New CryptoStream(plaintext, aes.CreateDecryptor(), CryptoStreamMode.Write)
                Try
                    cs.Write(encryptedMessage, 0, encryptedMessage.Length)
                    cs.Close()

                    Dim message As String = Encoding.UTF8.GetString(plaintext.ToArray())
                    Console.WriteLine(message)
                Finally
                    cs.Dispose()
                End Try
            Finally
                plaintext.Dispose()
            End Try
        Finally
            aes.Dispose()
        End Try

    End Sub 'Receive