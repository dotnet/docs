'<snippet1>
Imports System
Imports System.Text
Imports System.Security.Cryptography

Namespace RSACryptoServiceProvider_Examples
    Class MyMainClass
        Shared Sub Main()
            Dim toEncrypt() As Byte
            Dim encrypted() As Byte
            Dim signature() As Byte
            'Choose a small amount of data to encrypt.
            Dim original As String = "Hello"
            Dim myAscii As New ASCIIEncoding()

            'Create a sender and receiver.
            Dim mySender As New Sender()
            Dim myReceiver As New Receiver()

            'Convert the data string to a byte array.
            toEncrypt = myAscii.GetBytes(original)

            'Encrypt data using receiver's public key.
            encrypted = mySender.EncryptData(myReceiver.PublicParameters, toEncrypt)

            'Hash the encrypted data and generate a signature on the hash
            ' using the sender's private key.
            signature = mySender.HashAndSign(encrypted)

            Console.WriteLine("Original: {0}", original)

            'Verify the signature is authentic using the sender's public key.
            If myReceiver.VerifyHash(mySender.PublicParameters, encrypted, signature) Then
                'Decrypt the data using the receiver's private key.
                myReceiver.DecryptData(encrypted)
            Else
                Console.WriteLine("Invalid signature")
            End If
        End Sub 'Main
    End Class 'MyMainClass

    Class Sender
        Private rsaPubParams As RSAParameters
        Private rsaPrivateParams As RSAParameters

        Public Sub New()
            Dim rsaCSP As New RSACryptoServiceProvider()

            'Generate public and private key data.
            rsaPrivateParams = rsaCSP.ExportParameters(True)
            rsaPubParams = rsaCSP.ExportParameters(False)
        End Sub 'New

        Public ReadOnly Property PublicParameters() As RSAParameters
            Get
                Return rsaPubParams
            End Get
        End Property

        'Manually performs hash and then signs hashed value.
        Public Function HashAndSign(ByVal encrypted() As Byte) As Byte()
            Dim rsaCSP As New RSACryptoServiceProvider()
            Dim hash As New SHA1Managed()
            Dim hashedData() As Byte

            rsaCSP.ImportParameters(rsaPrivateParams)

            hashedData = hash.ComputeHash(encrypted)
            Return rsaCSP.SignHash(hashedData, CryptoConfig.MapNameToOID("SHA1"))
        End Function 'HashAndSign

        'Encrypts using only the public key data.
        Public Function EncryptData(ByVal rsaParams As RSAParameters, ByVal toEncrypt() As Byte) As Byte()
            Dim rsaCSP As New RSACryptoServiceProvider()

            rsaCSP.ImportParameters(rsaParams)
            Return rsaCSP.Encrypt(toEncrypt, False)
        End Function 'EncryptData
    End Class 'Sender

    Class Receiver
        Private rsaPubParams As RSAParameters
        Private rsaPrivateParams As RSAParameters

        Public Sub New()
            Dim rsaCSP As New RSACryptoServiceProvider()

            'Generate public and private key data.
            rsaPrivateParams = rsaCSP.ExportParameters(True)
            rsaPubParams = rsaCSP.ExportParameters(False)
        End Sub 'New

        Public ReadOnly Property PublicParameters() As RSAParameters
            Get
                Return rsaPubParams
            End Get
        End Property

        'Manually performs hash and then verifies hashed value.
        '<Snippet2>
        Public Function VerifyHash(ByVal rsaParams As RSAParameters, ByVal signedData() As Byte, ByVal signature() As Byte) As Boolean
            Dim rsaCSP As New RSACryptoServiceProvider()
            Dim hash As New SHA1Managed()
            Dim hashedData() As Byte
            Dim dataOK As Boolean

            rsaCSP.ImportParameters(rsaParams)
            dataOK = rsaCSP.VerifyData(signedData, CryptoConfig.MapNameToOID("SHA1"), signature)
            hashedData = hash.ComputeHash(signedData)
            Return rsaCSP.VerifyHash(hashedData, CryptoConfig.MapNameToOID("SHA1"), signature)
        End Function 'VerifyHash
        '</Snippet2>

        'Decrypt using the private key data.
        Public Sub DecryptData(ByVal encrypted() As Byte)
            Dim fromEncrypt() As Byte
            Dim roundTrip As String
            Dim myAscii As New ASCIIEncoding()
            Dim rsaCSP As New RSACryptoServiceProvider()

            rsaCSP.ImportParameters(rsaPrivateParams)
            fromEncrypt = rsaCSP.Decrypt(encrypted, False)
            roundTrip = myAscii.GetString(fromEncrypt)

            Console.WriteLine("RoundTrip: {0}", roundTrip)
        End Sub 'DecryptData
    End Class 'Receiver
End Namespace 'RSACryptoServiceProvider_Examples
'</snippet1>
