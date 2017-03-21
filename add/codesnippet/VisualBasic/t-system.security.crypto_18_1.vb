Imports System
Imports System.Security.Cryptography

Namespace Contoso
    Public Class ContosoDeformatter
        Inherits AsymmetricKeyExchangeDeformatter

        Private rsaKey As RSA

        ' Default constructor.
        Public Sub New()

        End Sub

        ' Constructor with the public key to use for encryption.
        Public Sub New(ByVal key As AsymmetricAlgorithm)
            SetKey(key)
        End Sub

        ' Set the public key for encyption operations.
        Public Overrides Sub SetKey(ByVal key As AsymmetricAlgorithm)
            If (Not key Is Nothing) Then
                rsaKey = CType(key, RSA)
            Else
                Throw New ArgumentNullException("key")
            End If
        End Sub

        ' Disallow access to the parameters of the formatter.
        Public Overrides ReadOnly Property Parameters() As String
            Get
                Return Nothing
            End Get
            Set(ByVal Value As String)

            End Set
        End Property

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

    End Class
End Namespace
'
' This code example produces the following output:
'
' Data to encrypt : Sample Contoso encryption application.
' Encrypted data: Kh34dfg-(*&834d+3
' Data decrypted : Sample Contoso encryption application.
' 
' This sample completed successfully; press Exit to continue.