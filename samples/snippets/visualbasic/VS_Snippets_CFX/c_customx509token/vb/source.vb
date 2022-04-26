'<snippet0>

Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.IdentityModel.Selectors
Imports System.IdentityModel.Tokens
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Cryptography.Xml
Imports System.Security.Permissions
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.ServiceModel.Security
Imports System.ServiceModel.Security.Tokens

Namespace Microsoft.ServiceModel.Samples

    '<snippet1>
    Friend Class CustomX509AsymmetricSecurityKey
        Inherits X509AsymmetricSecurityKey

        Private _certificate As X509Certificate2
        Private _thisLock As New Object()
        Private _privateKeyAvailabilityDetermined As Boolean
        Private _privateKey As AsymmetricAlgorithm
        Private _publicKey As PublicKey

        Public Sub New(ByVal certificate As X509Certificate2)
            MyBase.New(certificate)
            Me._certificate = certificate
        End Sub

        Public Overrides ReadOnly Property KeySize() As Integer
            Get
                Return Me.PublicKey.Key.KeySize
            End Get
        End Property

        Private Overloads ReadOnly Property PrivateKey() As AsymmetricAlgorithm
            ' You need to modify this to obtain the private key using a different cryptographic
            ' provider if you do not want to use the default provider.
            Get
                If Not Me._privateKeyAvailabilityDetermined Then
                    SyncLock ThisLock
                        If Not Me._privateKeyAvailabilityDetermined Then
                            Me._privateKey = Me._certificate.PrivateKey
                            Me._privateKeyAvailabilityDetermined = True
                        End If
                    End SyncLock
                End If
                Return Me._privateKey
            End Get
        End Property

        Private Overloads ReadOnly Property PublicKey() As PublicKey
            Get
                If Me._publicKey Is Nothing Then
                    SyncLock ThisLock
                        If Me._publicKey Is Nothing Then
                            Me._publicKey = Me._certificate.PublicKey
                        End If
                    End SyncLock
                End If
                Return Me._publicKey
            End Get
        End Property

        Private Overloads ReadOnly Property ThisLock() As Object
            Get
                Return _thisLock
            End Get
        End Property

        Public Overrides Function DecryptKey(ByVal algorithm As String, _
                                             ByVal keyData() As Byte) As Byte()
            ' You can decrypt the key only if you have the private key in the certificate.
            If Me.PrivateKey Is Nothing Then
                Throw New NotSupportedException("Missing private key")
            End If

            Dim rsa = TryCast(Me.PrivateKey, RSA)
            If rsa Is Nothing Then
                Throw New NotSupportedException("Private key cannot be used with RSA algorithm")
            End If

            ' Support exchange keySpec, AT_EXCHANGE ?
            If rsa.KeyExchangeAlgorithm Is Nothing Then
                Throw New NotSupportedException("Private key does not support key exchange")
            End If

            Select Case algorithm
                Case EncryptedXml.XmlEncRSA15Url
                    Return EncryptedXml.DecryptKey(keyData, rsa, False)

                Case EncryptedXml.XmlEncRSAOAEPUrl
                    Return EncryptedXml.DecryptKey(keyData, rsa, True)

                Case Else
                    Throw New NotSupportedException(String.Format("Algorithm {0} is not supported", algorithm))
            End Select
        End Function

        Public Overrides Function GetAsymmetricAlgorithm(ByVal algorithm As String, _
                                                         ByVal privateKey As Boolean) As AsymmetricAlgorithm
            If privateKey Then
                If Me.PrivateKey Is Nothing Then
                    Throw New NotSupportedException("Missing private key")
                End If

                Select Case algorithm
                    Case SignedXml.XmlDsigDSAUrl
                        If TryCast(Me.PrivateKey, DSA) IsNot Nothing Then
                            Return (TryCast(Me.PrivateKey, DSA))
                        End If
                        Throw New NotSupportedException("Private key cannot be used with DSA")

                    Case SignedXml.XmlDsigRSASHA1Url, EncryptedXml.XmlEncRSA15Url, EncryptedXml.XmlEncRSAOAEPUrl
                        If TryCast(Me.PrivateKey, RSA) IsNot Nothing Then
                            Return (TryCast(Me.PrivateKey, RSA))
                        End If
                        Throw New NotSupportedException("Private key cannot be used with RSA")
                    Case Else
                        Throw New NotSupportedException(String.Format("Algorithm {0} is not supported", algorithm))
                End Select
            Else
                Select Case algorithm
                    Case SignedXml.XmlDsigDSAUrl
                        If TryCast(Me.PublicKey.Key, DSA) IsNot Nothing Then
                            Return (TryCast(Me.PublicKey.Key, DSA))
                        End If
                        Throw New NotSupportedException("Public key cannot be used with DSA")
                    Case SignedXml.XmlDsigRSASHA1Url, EncryptedXml.XmlEncRSA15Url, EncryptedXml.XmlEncRSAOAEPUrl
                        If TryCast(Me.PublicKey.Key, RSA) IsNot Nothing Then
                            Return (TryCast(Me.PublicKey.Key, RSA))
                        End If
                        Throw New NotSupportedException("Public key cannot be used with RSA")
                    Case Else
                        Throw New NotSupportedException(String.Format("Algorithm {0} is not supported", algorithm))
                End Select
            End If
        End Function

        Public Overrides Function GetHashAlgorithmForSignature(ByVal algorithm As String) As HashAlgorithm
            If Not Me.IsSupportedAlgorithm(algorithm) Then
                Throw New NotSupportedException(String.Format("Algorithm {0} is not supported", algorithm))
            End If

            Select Case algorithm
                Case SignedXml.XmlDsigDSAUrl, SignedXml.XmlDsigRSASHA1Url
                    Return New SHA1Managed()
                Case Else
                    Throw New NotSupportedException(String.Format("Algorithm {0} is not supported", algorithm))
            End Select
        End Function

        Public Overrides Function GetSignatureFormatter(ByVal algorithm As String) As AsymmetricSignatureFormatter
            ' The signature can be created only if the private key is present.
            If Me.PrivateKey Is Nothing Then
                Throw New NotSupportedException("Private key is missing")
            End If

            ' Only one of the two algorithms is supported, not both.
            '     XmlDsigDSAUrl = "http://www.w3.org/2000/09/xmldsig#dsa-sha1";
            '     XmlDsigRSASHA1Url = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
            Select Case algorithm
                Case SignedXml.XmlDsigDSAUrl

                    ' Ensure that this is a DSA algorithm object.
                    Dim dsa = (TryCast(Me.PrivateKey, DSA))
                    If dsa Is Nothing Then
                        Throw New NotSupportedException("Private key cannot be used DSA")
                    End If

                    Return New DSASignatureFormatter(dsa)

                Case SignedXml.XmlDsigRSASHA1Url
                    ' Ensure that this is an RSA algorithm object.
                    Dim rsa = (TryCast(Me.PrivateKey, RSA))
                    If rsa Is Nothing Then
                        Throw New NotSupportedException("Private key cannot be used RSA")
                    End If

                    Return New RSAPKCS1SignatureFormatter(rsa)
                Case Else
                    Throw New NotSupportedException(String.Format("Algorithm {0} is not supported", algorithm))
            End Select
        End Function

        Public Overrides Function IsSupportedAlgorithm(ByVal algorithm As String) As Boolean
            Select Case algorithm
                Case SignedXml.XmlDsigDSAUrl
                    Return (TypeOf Me.PublicKey.Key Is DSA)

                Case SignedXml.XmlDsigRSASHA1Url, EncryptedXml.XmlEncRSA15Url, EncryptedXml.XmlEncRSAOAEPUrl
                    Return (TypeOf Me.PublicKey.Key Is RSA)

                Case Else
                    Return False
            End Select
        End Function

    End Class
    '</snippet1>

    '<snippet2>
    Friend Class CustomX509SecurityToken
        Inherits X509SecurityToken

        Private _securityKeys As ReadOnlyCollection(Of SecurityKey)

        Public Sub New(ByVal certificate As X509Certificate2)
            MyBase.New(certificate)
        End Sub

        Public Overrides ReadOnly Property SecurityKeys() As ReadOnlyCollection(Of SecurityKey)
            Get
                If Me._securityKeys Is Nothing Then
                    Dim temp As New List(Of SecurityKey)(1)
                    temp.Add(New CustomX509AsymmetricSecurityKey(Me.Certificate))
                    Me._securityKeys = temp.AsReadOnly()
                End If
                Return Me._securityKeys
            End Get
        End Property

    End Class
    '</snippet2>

    '<snippet3>
    Friend Class CustomX509SecurityTokenProvider
        Inherits SecurityTokenProvider

        Private _certificate As X509Certificate2

        Public Sub New(ByVal certificate As X509Certificate2)
            Me._certificate = certificate
        End Sub

        Protected Overrides Function GetTokenCore(ByVal timeout As TimeSpan) As SecurityToken
            Return New CustomX509SecurityToken(_certificate)
        End Function
    End Class
    '</snippet3>

    '<snippet4>
    Friend Class CustomClientSecurityTokenManager
        Inherits ClientCredentialsSecurityTokenManager

        Private credentials As CustomClientCredentials

        Public Sub New(ByVal credentials As CustomClientCredentials)
            MyBase.New(credentials)
            Me.credentials = credentials
        End Sub

        Public Overrides Function CreateSecurityTokenProvider(ByVal tokenRequirement As SecurityTokenRequirement) _
        As SecurityTokenProvider
            Dim result As SecurityTokenProvider = Nothing

            If tokenRequirement.TokenType = SecurityTokenTypes.X509Certificate Then
                Dim direction = tokenRequirement.GetProperty(Of MessageDirection) _
                (ServiceModelSecurityTokenRequirement.MessageDirectionProperty)
                If direction = MessageDirection.Output Then
                    If tokenRequirement.KeyUsage = SecurityKeyUsage.Signature Then
                        result = New CustomX509SecurityTokenProvider(credentials.ClientCertificate.Certificate)
                    End If
                Else
                    If tokenRequirement.KeyUsage = SecurityKeyUsage.Exchange Then
                        result = New CustomX509SecurityTokenProvider(credentials.ClientCertificate.Certificate)
                    End If
                End If
            End If

            If result Is Nothing Then
                result = MyBase.CreateSecurityTokenProvider(tokenRequirement)
            End If
            Return result
        End Function
    End Class
    '</snippet4>

    '<snippet5>
    Friend Class CustomServiceSecurityTokenManager
        Inherits ServiceCredentialsSecurityTokenManager

        Private credentials As CustomServiceCredentials

        Public Sub New(ByVal credentials As CustomServiceCredentials)
            MyBase.New(credentials)
            Me.credentials = credentials
        End Sub

        Public Overrides Function CreateSecurityTokenProvider(ByVal tokenRequirement As SecurityTokenRequirement) As SecurityTokenProvider
            Dim result As SecurityTokenProvider = Nothing

            If tokenRequirement.TokenType = SecurityTokenTypes.X509Certificate Then
                Dim direction = tokenRequirement.GetProperty(Of MessageDirection) _
                (ServiceModelSecurityTokenRequirement.MessageDirectionProperty)
                If direction = MessageDirection.Input Then
                    If tokenRequirement.KeyUsage = SecurityKeyUsage.Exchange Then
                        result = New CustomX509SecurityTokenProvider(credentials.ServiceCertificate.Certificate)
                    End If
                Else
                    If tokenRequirement.KeyUsage = SecurityKeyUsage.Signature Then
                        result = New CustomX509SecurityTokenProvider(credentials.ServiceCertificate.Certificate)
                    End If
                End If
            End If

            If result Is Nothing Then
                result = MyBase.CreateSecurityTokenProvider(tokenRequirement)
            End If
            Return result
        End Function
    End Class
    '</snippet5>

    '<snippet6>
    Public Class CustomClientCredentials
        Inherits ClientCredentials

        Public Sub New()
        End Sub

        Protected Sub New(ByVal other As CustomClientCredentials)
            MyBase.New(other)
        End Sub

        Protected Overrides Function CloneCore() As ClientCredentials
            Return New CustomClientCredentials(Me)
        End Function

        Public Overrides Function CreateSecurityTokenManager() As SecurityTokenManager
            Return New CustomClientSecurityTokenManager(Me)
        End Function
    End Class
    '</snippet6>

    '<snippet7>
    Public Class CustomServiceCredentials
        Inherits ServiceCredentials

        Public Sub New()
        End Sub

        Protected Sub New(ByVal other As CustomServiceCredentials)
            MyBase.New(other)
        End Sub

        Protected Overrides Function CloneCore() As ServiceCredentials
            Return New CustomServiceCredentials(Me)
        End Function

        Public Overrides Function CreateSecurityTokenManager() As SecurityTokenManager
            Return New CustomServiceSecurityTokenManager(Me)
        End Function

    End Class
    '</snippet7>
End Namespace
'</snippet0>
