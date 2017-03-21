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