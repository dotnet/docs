' This sample demonstrates how to extend the KeyedHashAlgorithm class.
'<Snippet3>
Imports System
Imports System.Security.Cryptography

Namespace Contoso
    Public Class ContosoKeyedHash
        Inherits KeyedHashAlgorithm

        Dim keyedCrypto As KeyedHashAlgorithm

        Public Sub New(ByVal rgbKey() As Byte)
            Me.New("System.Security.Cryptography.KeyedHashAlgorithm", rgbKey)
        End Sub

        Public Sub New(ByVal keyedHashName As String, ByVal rgbKey() As Byte)
            ' Make sure we know which algorithm to use
            If (Not rgbKey Is Nothing) Then
                KeyValue = rgbKey
                HashSizeValue = 160

                ' Create a KeyedHashAlgorithm encryptor
                If (keyedHashName Is Nothing) Then
                    '<Snippet2>
                    keyedCrypto = KeyedHashAlgorithm.Create()
                    '</Snippet2>
                Else
                    '<Snippet1>
                    keyedCrypto = KeyedHashAlgorithm.Create(keyedHashName)
                    '</Snippet1>
                End If

                '                keyedCrypto.Key = rgbKey
            Else
                Throw New ArgumentNullException("rgbKey")
            End If
        End Sub

        ' Override abstract methods from the HashAlgorithm class.
        Public Overrides Sub Initialize()

        End Sub

        ' Override the Key property to use the local key from keyedCrypto.
        '<Snippet22>
        Public Overrides Property Key() As Byte()
            Get
                Return CType(keyedCrypto.Key.Clone(), Byte())
            End Get
            Set(ByVal Value As Byte())
                keyedCrypto.Key = CType(Value.Clone(), Byte())
            End Set
        End Property
        '</Snippet22>

        Protected Overrides Sub HashCore( _
            ByVal rgbData() As Byte, _
            ByVal ibStart As Integer, _
            ByVal cbSize As Integer)

        End Sub
        Protected Overrides Function HashFinal() As Byte()
            Dim returnBytes(0) As Byte
            Return returnBytes
        End Function
    End Class
End Namespace

'</Snippet3>