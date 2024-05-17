'<snippet0>

Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.IdentityModel.Claims
Imports System.IdentityModel.Policy
Imports System.IdentityModel.Selectors
Imports System.IdentityModel.Tokens
Imports System.IO
Imports System.Security.Permissions
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Description
Imports System.ServiceModel.Security
Imports System.ServiceModel.Security.Tokens
Imports System.Xml

Namespace Microsoft.ServiceModel.Samples

    '<snippet5>
    Public Class Constants
        Public Const CreditCardNumberClaim As String = "http://samples.microsoft.com/wcf/security/Extensibility/Claims/CreditCardNumber"
        Public Const CreditCardTokenType As String = "http://samples.microsoft.com/wcf/security/Extensibility/Tokens/CreditCardToken"

        Friend Const CreditCardTokenPrefix As String = "cct"
        Friend Const CreditCardTokenNamespace As String = "http://samples.microsoft.com/wcf/security/Extensibility/"
        Friend Const CreditCardTokenName As String = "CreditCardToken"
        Friend Const Id As String = "Id"
        Friend Const WsUtilityPrefix As String = "wsu"
        Friend Const WsUtilityNamespace As String = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"
        Friend Const CreditCardNumberElementName As String = "CreditCardNumber"
        Friend Const CreditCardIssuerElementName As String = "CreditCardIssuer"
        Friend Const CreditCardExpirationElementName As String = "Expires"
    End Class
    '</snippet5>

    '<snippet4>
    Public Class CreditCardInfo

        Private _cardNumber As String
        Private _cardIssuer As String
        Private _expirationDate As DateTime

        Public Sub New(ByVal cardNumber As String, ByVal cardIssuer As String, _
                       ByVal expirationDate As DateTime)
            Me._cardNumber = cardNumber
            Me._cardIssuer = cardIssuer
            Me._expirationDate = expirationDate
        End Sub

        Public ReadOnly Property CardNumber() As String
            Get
                Return Me._cardNumber
            End Get
        End Property

        Public ReadOnly Property CardIssuer() As String
            Get
                Return Me._cardIssuer
            End Get
        End Property

        Public ReadOnly Property ExpirationDate() As DateTime
            Get
                Return Me._expirationDate
            End Get
        End Property

    End Class
    '</snippet4>

    '<snippet1>
    Friend Class CreditCardToken
        Inherits SecurityToken

        Private _cardInfo As CreditCardInfo
        Private _effectiveTime As DateTime = DateTime.UtcNow
        Private _id As String
        Private _securityKeys As ReadOnlyCollection(Of SecurityKey)

        Public Sub New(ByVal cardInfo As CreditCardInfo)
            Me.New(cardInfo, Guid.NewGuid().ToString())
        End Sub

        Public Sub New(ByVal cardInfo As CreditCardInfo, _
                       ByVal id As String)
            If cardInfo Is Nothing Then
                Throw New ArgumentNullException("cardInfo")
            End If
            If id Is Nothing Then
                Throw New ArgumentNullException("id")
            End If

            Me._cardInfo = cardInfo
            Me._id = id
            ' The credit card token is not capable of any cryptography.
            Me._securityKeys = New ReadOnlyCollection(Of SecurityKey)(New List(Of SecurityKey)())
        End Sub

        Public ReadOnly Property CardInfo() As CreditCardInfo
            Get
                Return Me._cardInfo
            End Get
        End Property

        Public Overrides ReadOnly Property SecurityKeys() As ReadOnlyCollection(Of SecurityKey)
            Get
                Return Me._securityKeys
            End Get
        End Property

        Public Overrides ReadOnly Property ValidFrom() As DateTime
            Get
                Return Me._effectiveTime
            End Get
        End Property

        Public Overrides ReadOnly Property ValidTo() As DateTime
            Get
                Return Me._cardInfo.ExpirationDate
            End Get
        End Property

        Public Overrides ReadOnly Property Id() As String
            Get
                Return Me._id
            End Get
        End Property
    End Class
    '</snippet1>

    '<snippet2>
    Public Class CreditCardTokenParameters
        Inherits SecurityTokenParameters

        Public Sub New()
        End Sub

        Protected Sub New(ByVal other As CreditCardTokenParameters)
            MyBase.New(other)
        End Sub

        Protected Overrides Function CloneCore() As SecurityTokenParameters
            Return New CreditCardTokenParameters(Me)
        End Function

        Protected Overrides Sub InitializeSecurityTokenRequirement(ByVal requirement As SecurityTokenRequirement)
            requirement.TokenType = Constants.CreditCardTokenType
            Return
        End Sub

        ' A credit card token has no cryptography, no windows identity, and supports only client authentication.
        Protected Overrides ReadOnly Property HasAsymmetricKey() As Boolean
            Get
                Return False
            End Get
        End Property

        Protected Overrides ReadOnly Property SupportsClientAuthentication() As Boolean
            Get
                Return True
            End Get
        End Property

        Protected Overrides ReadOnly Property SupportsClientWindowsIdentity() As Boolean
            Get
                Return False
            End Get
        End Property

        Protected Overrides ReadOnly Property SupportsServerAuthentication() As Boolean
            Get
                Return False
            End Get
        End Property

        Protected Overrides Function CreateKeyIdentifierClause(ByVal token As SecurityToken, _
                                                               ByVal referenceStyle As SecurityTokenReferenceStyle) As SecurityKeyIdentifierClause
            If referenceStyle = SecurityTokenReferenceStyle.Internal Then
                Return token.CreateKeyIdentifierClause(Of LocalIdKeyIdentifierClause)()
            Else
                Throw New NotSupportedException("External references are not supported for credit card tokens")
            End If
        End Function

    End Class
    '</snippet2>

    '<snippet3>
    Public Class CreditCardSecurityTokenSerializer
        Inherits WSSecurityTokenSerializer

        Public Sub New(ByVal version As SecurityTokenVersion)
            MyBase.New()
        End Sub

        Protected Overrides Function CanReadTokenCore(ByVal reader As XmlReader) As Boolean
            Dim localReader = XmlDictionaryReader.CreateDictionaryReader(reader)
            If reader Is Nothing Then
                Throw New ArgumentNullException("reader")
            End If
            If reader.IsStartElement(Constants.CreditCardTokenName, _
                                     Constants.CreditCardTokenNamespace) Then
                Return True
            End If
            Return MyBase.CanReadTokenCore(reader)
        End Function

        Protected Overrides Function ReadTokenCore(ByVal reader As XmlReader, _
                                                   ByVal tokenResolver As SecurityTokenResolver) As SecurityToken
            If reader Is Nothing Then
                Throw New ArgumentNullException("reader")
            End If
            If reader.IsStartElement(Constants.CreditCardTokenName, _
                                     Constants.CreditCardTokenNamespace) Then

                Dim id = reader.GetAttribute(Constants.Id, _
                                             Constants.WsUtilityNamespace)
                reader.ReadStartElement()

                ' Read the credit card number.
                Dim creditCardNumber = reader.ReadElementString(Constants.CreditCardNumberElementName, _
                                                                Constants.CreditCardTokenNamespace)

                ' Read the expiration date.
                Dim expirationTimeString = reader.ReadElementString(Constants.CreditCardExpirationElementName, _
                                                                    Constants.CreditCardTokenNamespace)
                Dim expirationTime As DateTime = XmlConvert.ToDateTime(expirationTimeString, _
                                                                       XmlDateTimeSerializationMode.Utc)

                ' Read the issuer of the credit card.
                Dim creditCardIssuer = reader.ReadElementString(Constants.CreditCardIssuerElementName, _
                                                                Constants.CreditCardTokenNamespace)
                reader.ReadEndElement()

                Dim cardInfo As New CreditCardInfo(creditCardNumber, _
                                                   creditCardIssuer, _
                                                   expirationTime)

                Return New CreditCardToken(cardInfo, id)
            Else
                Return WSSecurityTokenSerializer.DefaultInstance.ReadToken(reader, _
                                                                           tokenResolver)
            End If
        End Function

        Protected Overrides Function CanWriteTokenCore(ByVal token As SecurityToken) As Boolean
            If TypeOf token Is CreditCardToken Then
                Return True
            Else
                Return MyBase.CanWriteTokenCore(token)
            End If
        End Function

        Protected Overrides Sub WriteTokenCore(ByVal writer As XmlWriter, _
                                               ByVal token As SecurityToken)
            If writer Is Nothing Then
                Throw New ArgumentNullException("writer")
            End If
            If token Is Nothing Then
                Throw New ArgumentNullException("token")
            End If

            Dim c = TryCast(token, CreditCardToken)
            If c IsNot Nothing Then
                With writer
                    .WriteStartElement(Constants.CreditCardTokenPrefix, _
                                       Constants.CreditCardTokenName, _
                                       Constants.CreditCardTokenNamespace)
                    .WriteAttributeString(Constants.WsUtilityPrefix, _
                                          Constants.Id, _
                                          Constants.WsUtilityNamespace, _
                                          token.Id)
                    .WriteElementString(Constants.CreditCardNumberElementName, _
                                        Constants.CreditCardTokenNamespace, _
                                        c.CardInfo.CardNumber)
                    .WriteElementString(Constants.CreditCardExpirationElementName, _
                                        Constants.CreditCardTokenNamespace, _
                                        XmlConvert.ToString(c.CardInfo.ExpirationDate, _
                                                            XmlDateTimeSerializationMode.Utc))
                    .WriteElementString(Constants.CreditCardIssuerElementName, _
                                        Constants.CreditCardTokenNamespace, _
                                        c.CardInfo.CardIssuer)
                    .WriteEndElement()
                    .Flush()
                End With
            Else
                MyBase.WriteTokenCore(writer, token)
            End If
        End Sub

    End Class
    '</snippet3>

    '<snippet6>
    Friend Class CreditCardTokenProvider
        Inherits SecurityTokenProvider

        Private creditCardInfo As CreditCardInfo

        Public Sub New(ByVal creditCardInfo As CreditCardInfo)
            MyBase.New()
            If creditCardInfo Is Nothing Then
                Throw New ArgumentNullException("creditCardInfo")
            End If
            Me.creditCardInfo = creditCardInfo
        End Sub

        Protected Overrides Function GetTokenCore(ByVal timeout As TimeSpan) As SecurityToken
            Return TryCast(New CreditCardToken(Me.creditCardInfo), SecurityToken)
        End Function

    End Class
    '</snippet6>

    '<snippet7>
    Friend Class CreditCardTokenAuthenticator
        Inherits SecurityTokenAuthenticator

        Private creditCardsFile As String

        Public Sub New(ByVal creditCardsFile As String)
            Me.creditCardsFile = creditCardsFile
        End Sub

        Protected Overrides Function CanValidateTokenCore(ByVal token As SecurityToken) As Boolean
            Return (TypeOf token Is CreditCardToken)
        End Function

        Protected Overrides Function ValidateTokenCore(ByVal token As SecurityToken) As ReadOnlyCollection(Of IAuthorizationPolicy)

            Dim creditCardToken = TryCast(token, CreditCardToken)

            If creditCardToken.CardInfo.ExpirationDate < DateTime.UtcNow Then
                Throw New SecurityTokenValidationException("The credit card has expired")
            End If
            If Not IsCardNumberAndExpirationValid(creditCardToken.CardInfo) Then
                Throw New SecurityTokenValidationException("Unknown or invalid credit card")
            End If

            ' The credit card token has only 1 claim: the card number. The issuer for the claim is the
            ' credit card issuer.
            Dim cardIssuerClaimSet As New DefaultClaimSet(New Claim(ClaimTypes.Name, _
                                                                    creditCardToken.CardInfo.CardIssuer, _
                                                                    Rights.PossessProperty))
            Dim cardClaimSet As New DefaultClaimSet(cardIssuerClaimSet, _
                                                    New Claim(Constants.CreditCardNumberClaim, _
                                                              creditCardToken.CardInfo.CardNumber, _
                                                              Rights.PossessProperty))
            Dim policies As New List(Of IAuthorizationPolicy)(1)
            policies.Add(New CreditCardTokenAuthorizationPolicy(cardClaimSet))
            Return policies.AsReadOnly()
        End Function

        ' This helper method checks whether a given credit card entry is present in the user database.
        Private Function IsCardNumberAndExpirationValid(ByVal cardInfo As CreditCardInfo) As Boolean
            Try
                Using myStreamReader As New StreamReader(Me.creditCardsFile)
                    Dim line = String.Empty
                    line = myStreamReader.ReadLine()
                    Do While line IsNot Nothing
                        Dim splitEntry() = line.Split("#"c)
                        If splitEntry(0) = cardInfo.CardNumber Then
                            Dim expirationDateString = splitEntry(1).Trim()
                            Dim expirationDateOnFile As DateTime = DateTime.Parse(expirationDateString, _
                                                                                  System.Globalization.DateTimeFormatInfo.InvariantInfo, _
                                                                                  System.Globalization.DateTimeStyles.AdjustToUniversal)
                            If cardInfo.ExpirationDate = expirationDateOnFile Then
                                Dim issuer = splitEntry(2)
                                Return issuer.Equals(cardInfo.CardIssuer, _
                                                     StringComparison.InvariantCultureIgnoreCase)
                            Else
                                Return False
                            End If
                        End If
                        line = myStreamReader.ReadLine()
                    Loop
                    Return False
                End Using
            Catch e As Exception
                Throw New Exception("BookStoreService: Error while retrieving credit card information from User DB " & e.ToString())
            End Try
        End Function

    End Class
    '</snippet7>

    '<snippet12>
    Public Class CreditCardTokenAuthorizationPolicy
        Implements IAuthorizationPolicy

        Private _id As String
        Private _issuer As ClaimSet
        Private _issuedClaimSets As IEnumerable(Of ClaimSet)

        Public Sub New(ByVal issuedClaims As ClaimSet)
            If issuedClaims Is Nothing Then
                Throw New ArgumentNullException("issuedClaims")
            End If
            Me._issuer = issuedClaims.Issuer
            Me._issuedClaimSets = New ClaimSet() {issuedClaims}
            Me._id = Guid.NewGuid().ToString()
        End Sub

        Public ReadOnly Property Issuer() As ClaimSet Implements IAuthorizationPolicy.Issuer
            Get
                Return Me._issuer
            End Get
        End Property

        Public ReadOnly Property Id() As String Implements System.IdentityModel.Policy.IAuthorizationComponent.Id
            Get
                Return Me._id
            End Get
        End Property

        Public Function Evaluate(ByVal context As EvaluationContext, _
                                 ByRef state As Object) As Boolean Implements IAuthorizationPolicy.Evaluate
            For Each issuance In Me._issuedClaimSets
                context.AddClaimSet(Me, issuance)
            Next issuance

            Return True
        End Function

    End Class
    '</snippet12>

    '<snippet8>
    Public Class CreditCardClientCredentialsSecurityTokenManager
        Inherits ClientCredentialsSecurityTokenManager

        Private creditCardClientCredentials As CreditCardClientCredentials

        Public Sub New(ByVal creditCardClientCredentials As CreditCardClientCredentials)
            MyBase.New(creditCardClientCredentials)
            Me.creditCardClientCredentials = creditCardClientCredentials
        End Sub

        Public Overrides Function CreateSecurityTokenProvider(ByVal tokenRequirement As SecurityTokenRequirement) As SecurityTokenProvider

            If tokenRequirement.TokenType = Constants.CreditCardTokenType Then
                ' Handle this token for Custom.
                Return New CreditCardTokenProvider(Me.creditCardClientCredentials.CreditCardInfo)
            ElseIf TypeOf tokenRequirement Is InitiatorServiceModelSecurityTokenRequirement Then
                ' Return server certificate.
                If tokenRequirement.TokenType = SecurityTokenTypes.X509Certificate Then
                    Return New X509SecurityTokenProvider(creditCardClientCredentials.ServiceCertificate.DefaultCertificate)
                End If
            End If
            Return MyBase.CreateSecurityTokenProvider(tokenRequirement)
        End Function

        Public Overloads Overrides Function CreateSecurityTokenSerializer(ByVal version As SecurityTokenVersion) As SecurityTokenSerializer
            Return New CreditCardSecurityTokenSerializer(version)
        End Function

    End Class
    '</snippet8>

    '<snippet9>
    Public Class CreditCardServiceCredentialsSecurityTokenManager
        Inherits ServiceCredentialsSecurityTokenManager

        Private creditCardServiceCredentials As CreditCardServiceCredentials

        Public Sub New(ByVal creditCardServiceCredentials As CreditCardServiceCredentials)
            MyBase.New(creditCardServiceCredentials)
            Me.creditCardServiceCredentials = creditCardServiceCredentials
        End Sub

        Public Overrides Function CreateSecurityTokenAuthenticator(ByVal tokenRequirement As SecurityTokenRequirement, _
                                                                   <System.Runtime.InteropServices.Out()> ByRef outOfBandTokenResolver As SecurityTokenResolver) As SecurityTokenAuthenticator
            If tokenRequirement.TokenType = Constants.CreditCardTokenType Then
                outOfBandTokenResolver = Nothing
                Return New CreditCardTokenAuthenticator(creditCardServiceCredentials.CreditCardDataFile)
            End If
            Return MyBase.CreateSecurityTokenAuthenticator(tokenRequirement, outOfBandTokenResolver)
        End Function

        Public Overrides Function CreateSecurityTokenSerializer(ByVal version As SecurityTokenVersion) As SecurityTokenSerializer
            Return New CreditCardSecurityTokenSerializer(version)
        End Function

    End Class
    '</snippet9>

    '<snippet10>
    Public Class CreditCardClientCredentials
        Inherits ClientCredentials

        Private _creditCardInfo As CreditCardInfo

        Public Sub New(ByVal creditCardInfo As CreditCardInfo)
            MyBase.New()
            If creditCardInfo Is Nothing Then
                Throw New ArgumentNullException("creditCardInfo")
            End If

            Me._creditCardInfo = creditCardInfo
        End Sub

        Public ReadOnly Property CreditCardInfo() As CreditCardInfo
            Get
                Return Me._creditCardInfo
            End Get
        End Property

        Protected Overrides Function CloneCore() As ClientCredentials
            Return New CreditCardClientCredentials(Me._creditCardInfo)
        End Function

        Public Overrides Function CreateSecurityTokenManager() As SecurityTokenManager
            Return New CreditCardClientCredentialsSecurityTokenManager(Me)
        End Function

    End Class
    '</snippet10>

    '<snippet11>
    Public Class CreditCardServiceCredentials
        Inherits ServiceCredentials

        Private creditCardFile As String

        Public Sub New(ByVal creditCardFile As String)
            MyBase.New()
            If creditCardFile Is Nothing Then
                Throw New ArgumentNullException("creditCardFile")
            End If

            Me.creditCardFile = creditCardFile
        End Sub

        Public ReadOnly Property CreditCardDataFile() As String
            Get
                Return Me.creditCardFile
            End Get
        End Property

        Protected Overrides Function CloneCore() As ServiceCredentials
            Return New CreditCardServiceCredentials(Me.creditCardFile)
        End Function

        Public Overrides Function CreateSecurityTokenManager() As SecurityTokenManager
            Return New CreditCardServiceCredentialsSecurityTokenManager(Me)
        End Function

    End Class
    '</snippet11>

    '<snippet13>
    Public NotInheritable Class BindingHelper

        Private Sub New()
        End Sub

        Public Shared Function CreateCreditCardBinding() As Binding
            Dim httpTransport As New HttpTransportBindingElement()

            ' The message security binding element is configured to require a credit card
            ' token that is encrypted with the service's certificate. 
            Dim messageSecurity As New SymmetricSecurityBindingElement()
            messageSecurity.EndpointSupportingTokenParameters.SignedEncrypted.Add(New CreditCardTokenParameters())
            Dim x509ProtectionParameters As New X509SecurityTokenParameters()
            x509ProtectionParameters.InclusionMode = SecurityTokenInclusionMode.Never
            messageSecurity.ProtectionTokenParameters = x509ProtectionParameters
            Return New CustomBinding(messageSecurity, httpTransport)
        End Function

    End Class
    '</snippet13>
End Namespace
'</snippet0>
