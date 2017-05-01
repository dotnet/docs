' This class demonstrates how to extend the AsymmetricKeyExchangeFormatter 
' abstract class.
'<Snippet1>
Imports System
Imports System.Security.Cryptography

Namespace Contoso
    Public Class ContosoFormatter
        Inherits AsymmetricKeyExchangeFormatter

        Private rsaKey As RSA

        ' Default constructor.
        Public Sub New()

        End Sub

        ' Constructor with the public key to use for encryption.
        '<Snippet2>
        Public Sub New(ByVal key As AsymmetricAlgorithm)
            SetKey(key)
        End Sub
        '</Snippet2>

        ' Disallow access to the parameters of the formatter.
        '<Snippet3>
        Public Overrides ReadOnly Property Parameters() As String
            Get
                Return Nothing
            End Get
        End Property
        '</Snippet3>

        '<Snippet4>
        ' Create the encrypted key exchange data from the specified input
        ' data. This method uses the RSACryptoServiceProvider only.
        ' To support additional providers or provide custom encryption logic,
        ' add logic to this member.
        Public Overloads Overrides Function CreateKeyExchange( _
            ByVal sourceData() As Byte) As Byte()

            Dim encryptedData() As Byte
            If (Not rsaKey Is Nothing) Then
                If (TypeOf (rsaKey) Is RSACryptoServiceProvider) Then
                    Dim rsaProvider As RSACryptoServiceProvider
                    rsaProvider = CType(rsaKey, RSACryptoServiceProvider)
                    encryptedData = rsaProvider.Encrypt(sourceData, True)

                End If
            Else
                Throw New CryptographicUnexpectedOperationException( _
                    "Cryptography_MissingKey")
            End If

            Return encryptedData
        End Function
        '</Snippet4>

        ' Set the public key for encyption operations.
        '<Snippet5>
        Public Overrides Sub SetKey(ByVal key As AsymmetricAlgorithm)
            If (Not key Is Nothing) Then
                rsaKey = CType(key, RSA)
            Else
                Throw New ArgumentNullException("key")
            End If
        End Sub
        '</Snippet5>

        '<Snippet6>
        ' The second parameter is not used in the current version.
        ' Simply call the default CreateKeyExchange method.
        Public Overloads Overrides Function CreateKeyExchange( _
                ByVal sourceData() As Byte, _
                ByVal symAlgType As System.Type) As Byte()

            Return CreateKeyExchange(sourceData)
        End Function
        '</Snippet6>
    End Class
End Namespace
'
' This code example produces the following output:
'
' Data to encrypt : Sample Contoso encryption application.
' Encrypted data: @X8*&(^^%I)(*&)(**)()))9UJKJLkj8iu
' Data decrypted : Sample Contoso encryption application.
' 
' This sample completed successfully; press Exit to continue.
'</Snippet1>