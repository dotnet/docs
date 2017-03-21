        ' Create the encrypted key exchange data from the specified input
        ' data. This method uses the RSACryptoServiceProvider only. To
        ' support additional providers or provide custom decryption logic,
        ' add logic to this member.
        Public Overrides Function DecryptKeyExchange(
            ByVal rgbData() As Byte) As Byte()

            Dim decryptedBytes() As Byte

            If (Not rsaKey Is Nothing) Then
                If (TypeOf (rsaKey) Is RSACryptoServiceProvider) Then
                    Dim rsaProvider As RSACryptoServiceProvider
                    rsaProvider = CType(rsaKey, RSACryptoServiceProvider)

                    decryptedBytes = rsaProvider.Decrypt(rgbData, True)
                End If

                ' Add custom decryption logic here.

            Else
                Throw New CryptographicUnexpectedOperationException(
                    "Cryptography_MissingKey")
            End If

            Return decryptedBytes
        End Function