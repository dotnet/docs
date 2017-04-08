'-----------------------------------------------------------------------------
' Copyright (c) Microsoft Corporation.  All rights reserved.
'-----------------------------------------------------------------------------
Imports System

Imports System.Collections.Generic
Imports System.Collections.ObjectModel

Imports System.IdentityModel.Claims
Imports System.IdentityModel.Policy
Imports System.IdentityModel.Tokens

Imports System.Configuration
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.InteropServices
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Security
Imports System.ServiceModel.Security.Tokens
Imports System.Security.Permissions
Imports System.Xml
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates



<Assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution:=True)> 
Namespace Microsoft.ServiceModel.Samples.Federation
    <ServiceBehavior(IncludeExceptionDetailInFaults:=True)> _
    Public Class BookStoreSTS
        Inherits SecurityTokenService

        '/ <summary>
        '/ Sets up the BookStoreSTS by loading relevant Application Settings.
        '/ </summary>
        Public Sub New()
            MyBase.New(ServiceConstants.SecurityTokenServiceName, FederationUtilities.GetX509TokenFromCert(ServiceConstants.CertStoreName, ServiceConstants.CertStoreLocation, ServiceConstants.CertDistinguishedName), FederationUtilities.GetX509TokenFromCert(ServiceConstants.CertStoreName, ServiceConstants.CertStoreLocation, ServiceConstants.TargetDistinguishedName))

        End Sub 'New

        '/ <summary>
        '/ Overrides the GetIssuedClaims from the SecurityTokenService base class.
        '/ Checks whether the caller can purchase the book specified in the RST and if so,
        '/ issues a purchase authorized claim.
        '/ </summary>

        '<snippet1>
        Protected Overrides Function GetIssuedClaims(ByVal RST As RequestSecurityToken) As Collection(Of SamlAttribute)

            Dim rstAppliesTo As EndpointAddress = RST.AppliesTo

            If rstAppliesTo Is Nothing Then
                Throw New InvalidOperationException("No AppliesTo EndpointAddress in RequestSecurityToken")
            End If

            Dim bookName As String = rstAppliesTo.Headers.FindHeader(Constants.BookNameHeaderName, Constants.BookNameHeaderNamespace).GetValue(Of String)()

            If String.IsNullOrEmpty(bookName) Then
                Throw New FaultException("The book name was not specified in the RequestSecurityToken")
            End If
            EnsurePurchaseLimitSufficient(bookName)

            Dim samlAttributes As New Collection(Of SamlAttribute)()

            Dim claimSet As ClaimSet
            For Each claimSet In ServiceSecurityContext.Current.AuthorizationContext.ClaimSets
                ' Copy Name claims from the incoming credentials into the set of claims we're going to issue
                Dim nameClaims As IEnumerable(Of Claim) = claimSet.FindClaims(ClaimTypes.Name, Rights.PossessProperty)
                If Not (nameClaims Is Nothing) Then
                    Dim nameClaim As Claim
                    For Each nameClaim In nameClaims
                        samlAttributes.Add(New SamlAttribute(nameClaim))
                    Next nameClaim
                End If
            Next claimSet
            ' add a purchase authorized claim
            samlAttributes.Add(New SamlAttribute(New Claim(Constants.PurchaseAuthorizedClaim, bookName, Rights.PossessProperty)))
            Return samlAttributes

        End Function
        '</snippet1>
        Public Shared Sub Main()

        End Sub 'Main 

        '/ <summary>
        '/ Wrapper for the Application level check performed at the BookStoreSTS for 
        '/ the existence of a required purchase limit. 
        '/ </summary>
        Private Shared Sub EnsurePurchaseLimitSufficient(ByVal bookName As String)
            If Not CheckIfPurchaseLimitMet(bookName) Then
                Throw New FaultException(String.Format("Purchase limit not sufficient to purchase '{0}'", bookName))
            End If

        End Sub 'EnsurePurchaseLimitSufficient


        '/ <summary>
        '/ Helper method to get book price from the Books Database.
        '/ </summary>
        '/ <param name="bookID">ID of the book intended for purchase.</param>
        '/ <returns>Price of the book with the given ID.</returns>
        Private Shared Function GetBookPrice(ByVal bookName As String) As Double
            Dim myStreamReader As New StreamReader(ServiceConstants.BookDB)
            Try
                Dim line As String = ""
                line = myStreamReader.ReadLine()
                While Not (Not line Is Nothing)
                    Dim splitEntry As String() = line.Split("#"c)
                    If splitEntry(1).Trim().Equals(bookName.Trim(), StringComparison.OrdinalIgnoreCase) Then
                        Return [Double].Parse(splitEntry(3))
                    End If
                    line = myStreamReader.ReadLine()
                End While
                ' invalid bookName - throw
                Throw New FaultException("Invalid Book Name " + bookName)

            Finally
                myStreamReader.Dispose()
            End Try

        End Function 'GetBookPrice


        '/ <summary>
        '/ Application level check for claims at the BookStoreSTS.
        '/ </summary>
        '/ <param name="bookID">ID of the book intended for purchase.</param>
        '/ <returns>True on success. False on failure.</returns>
        Private Shared Function CheckIfPurchaseLimitMet(ByVal bookID As String) As Boolean
            '' Extract the AuthorizationContext from the ServiceSecurityContext
            'Dim authContext As AuthorizationContext = OperationContext.Current.ServiceSecurityContext.AuthorizationContext

            '' If there are no Claims in the AuthorizationContext, return false.
            '' The issued token used to authenticate should contain claims. 
            'If authContext.ClaimSets Is Nothing Then
            '    Return False
            'End If
            '' If there is more than two ClaimSets in the AuthorizationContext, return false.
            '' The issued token used to authenticate should only contain two sets of claims.
            'If authContext.ClaimSets.Count <> 2 Then
            '    Return False
            'End If
            'Dim claimsets As New List(Of ClaimSet)(authContext.ClaimSets)
            'Dim myClaimSet As ClaimSet = claimsets.Find(Predicate(Of ClaimSet))
            'Dim certClaimSet As X509CertificateClaimSet = target.Issuer
            'Return Not (certClaimSet Is Nothing) AndAlso certClaimSet.X509Certificate.Subject = "CN=HomeRealmSTS.com"

            '' If the ClaimSet was NOT issued by the HomeRealmSTS then return false.
            '' The BookStoreSTS only accepts requests where the client authenticated using a token
            '' issued by the HomeRealmSTS.
            'If Not IssuedByHomeRealmSTS(myClaimSet) Then
            '    Return False
            'End If
            '' Find all the PurchaseLimit claims.
            'Dim purchaseLimitClaims As IEnumerable(Of Claim) = myClaimSet.FindClaims(Constants.PurchaseLimitClaim, Rights.PossessProperty)

            '' If there are no PurchaseLimit claims, return false.
            '' The HomeRealmSTS issues tokens that contain PurchaseLimit claims for all authorized requests.
            'If purchaseLimitClaims Is Nothing Then
            '    Return False
            'End If
            '' Get the price of the book being purchased...
            'Dim bookPrice As Double = GetBookPrice(bookID)

            '' Iterate through the PurchaseLimit claims and verify that the Resource value is 
            '' greater than or equal to the price of the book being purchased.
            'Dim c As Claim
            'For Each c In purchaseLimitClaims
            '    Dim purchaseLimit As Double = [Double].Parse(c.Resource.ToString())
            '    If purchaseLimit >= bookPrice Then
            '        Return True
            '    End If
            'Next c
            '' If no PurchaseLimit claim had a resource value that was greater than or equal
            '' to the price of the book being purchased, return false.
            Return False

        End Function 'CheckIfPurchaseLimitMet



        '/ <summary>
        '/ Helper function to check whether a SAML token was issued by HomeRealmSTS.
        '/ </summary>
        '/ <returns>True on success. False on failure.</returns>
        Private Shared Function IssuedByHomeRealmSTS(ByVal myClaimSet As ClaimSet) As Boolean
            ' Extract the issuer ClaimSet.
            Dim issuerClaimSet As ClaimSet = myClaimSet.Issuer

            ' If the Issuer is null, return false.
            If issuerClaimSet Is Nothing Then
                Return False
            End If
            ' Find all the Thumbprint claims in the issuer ClaimSet.
            Dim issuerClaims As IEnumerable(Of Claim) = issuerClaimSet.FindClaims(ClaimTypes.Thumbprint, Nothing)

            ' If there are no Thumbprint claims, return false.
            If issuerClaims Is Nothing Then
                Return False
            End If
            ' Get the enumerator for the set of Thumbprint claims...  
            Dim issuerClaimsEnum As IEnumerator(Of Claim) = issuerClaims.GetEnumerator()

            ' ...and set issuerClaim to the first such Claim.
            Dim issuerClaim As Claim = Nothing
            If issuerClaimsEnum.MoveNext() Then
                issuerClaim = issuerClaimsEnum.Current
            End If
            ' If there was no Thumbprint claim, return false.
            If issuerClaim Is Nothing Then
                Return False
            End If
            ' If, despite the preceding checks, the returned claim is not a Thumbprint claim, return false.
            If issuerClaim.ClaimType <> ClaimTypes.Thumbprint Then
                Return False
            End If
            ' If the returned claim does not contain a Resource, return false.
            If issuerClaim.Resource Is Nothing Then
                Return False
            End If
            ' Extract the thumbprint data from the claim.
            Dim issuerThumbprint As Byte() = CType(issuerClaim.Resource, Byte())

            ' Extract the thumbprint for the HomeRealmSTS.com certificate.
            Dim certThumbprint As Byte() = FederationUtilities.GetCertificateThumbprint(ServiceConstants.CertStoreName, ServiceConstants.CertStoreLocation, ServiceConstants.IssuerDistinguishedName)

            ' If the lengths of the two thumbprints are different, return false.
            If issuerThumbprint.Length <> certThumbprint.Length Then
                Return False
            End If
            ' Check the individual bytes of the two thumbprints for equality...
            Dim i As Integer
            For i = 0 To issuerThumbprint.Length
                '... if any byte in the thumbprint from the claim does NOT match the corresponding
                ' byte from the thumbprint in the BookStoreSTS.com certificate, return false.
                If issuerThumbprint(i) <> certThumbprint(i) Then
                    Return False
                End If
            Next i
            ' If we get through all the preceding checks, return true (ClaimSet was issued by HomeRealmSTS.com).
            Return True

        End Function 'IssuedByHomeRealmSTS
    End Class 'BookStoreSTS

    '/ <summary>
    '/ Abstract base class for STS implementations.
    '/ </summary>

    Public MustInherit Class SecurityTokenService
        Implements ISecurityTokenService
        Private stsNameValue As String ' The name of the STS. Used to populate saml:Assertion/@Issuer
        Private issuerTokenValue As SecurityToken ' The SecurityToken used to sign issued tokens
        Private proofKeyEncryptionTokenValue As SecurityToken
        ' The SecurityToken used to encrypt the proof key in the issued token.
        '/ <summary>
        '/ constructor 
        '/ </summary>
        '/ <param name="stsName">The name of the STS. Used to populate saml:Assertion/@Issuer.</param>
        '/ <param name="token">The X509SecurityToken that the STS uses to sign SAML assertions.</param>
        '/ <param name="targetServiceName">The X509SecurityToken that is used to encrypt the proof key in the SAML token.</param>
        Protected Sub New(ByVal stsName As String, ByVal issuerToken As X509SecurityToken, ByVal encryptionToken As X509SecurityToken)
            Me.stsNameValue = stsName
            Me.issuerTokenValue = issuerToken
            Me.proofKeyEncryptionTokenValue = encryptionToken

        End Sub 'New

        '/ <summary>
        '/ The name of the STS.
        '/ </summary>

        Protected ReadOnly Property SecurityTokenServiceName() As String
            Get
                Return Me.stsNameValue
            End Get
        End Property

        '/ <summary>
        '/ The SecurityToken used to sign tokens the STS issues.
        '/ </summary>

        Protected ReadOnly Property IssuerToken() As SecurityToken
            Get
                Return Me.issuerTokenValue
            End Get
        End Property
        '/ <summary>
        '/ The SecurityToken used to encrypt the proof key in the issued token.
        '/ </summary>

        Protected ReadOnly Property ProofKeyEncryptionToken() As SecurityToken
            Get
                Return Me.proofKeyEncryptionTokenValue
            End Get
        End Property

        '/ <summary>
        '/ Abstract method for setting up claims in the SAML token issued by the STS.
        '/ Should be overriden by STS implementations that derive from this base class
        '/ to set up appropriate claims.
        '/ </summary>

        Protected MustOverride Function GetIssuedClaims(ByVal RST As RequestSecurityToken) As Collection(Of SamlAttribute)

        Protected Shared Sub EnsureRequestSecurityTokenAction(ByVal msg As Message)
            If msg Is Nothing Then
                Throw New ArgumentNullException("message")
            End If
            If msg.Headers.Action <> Constants.Trust.Actions.Issue Then
                Throw New InvalidOperationException(String.Format("Bad or Unsupported Action: {0}", msg.Headers.Action))
            End If
        End Sub
        '/ <summary>
        '/ Helper method to create proof token. Creates BinarySecretSecuryToken 
        '/ with the requested number of bits of random key material.
        '/ </summary>
        '/ <param name="keySize">keySize</param>
        '/ <returns>Proof Token</returns>
        Protected Shared Function CreateProofToken(ByVal keySize As Integer) As BinarySecretSecurityToken
            ' Create an array to store the key bytes.
            Dim key(keySize / 8) As Byte
            ' Create some random bytes.
            Dim random As New RNGCryptoServiceProvider()
            random.GetNonZeroBytes(key)
            ' Create a BinarySecretSecurityToken from the random bytes and return it.
            Return New BinarySecretSecurityToken(key)
        End Function
        '/ <summary>
        '/ Helper method to set up the RSTR.
        '/ </summary>
        '/ <param name="rst">RequestSecurityToken</param>
        '/ <param name="keySize">keySize</param>
        '/ <param name="proofToken">proofToken</param>
        '/ <param name="samlToken">The SAML Token to be issued.</param>
        '/ <returns>RequestSecurityTokenResponse</returns>
        Protected Shared Function GetRequestSecurityTokenResponse(ByVal RST As RequestSecurityTokenBase, _
        ByVal keySize As Integer, _
        ByVal proofToken As SecurityToken, _
        ByVal samlToken As SecurityToken, _
        ByVal senderEntropy As Byte(), _
        ByVal stsEntropy As Byte()) As RequestSecurityTokenBase
            Dim rstr As New RequestSecurityTokenResponse()
            rstr.TokenType = Constants.SamlTokenTypeUri
            rstr.RequestedSecurityToken = samlToken
            rstr.RequestedUnattachedReference = samlToken.CreateKeyIdentifierClause(Of SamlAssertionKeyIdentifierClause)()
            rstr.RequestedAttachedReference = samlToken.CreateKeyIdentifierClause(Of SamlAssertionKeyIdentifierClause)()
            rstr.Context = RST.Context
            rstr.KeySize = keySize

            ' If the sender provided entropy then combined entropy is used, so set the IssuerEntropy.
            If Not (senderEntropy Is Nothing) Then
                rstr.IssuerEntropy = New BinarySecretSecurityToken(stsEntropy)
                rstr.ComputeKey = True
                ' Issuer entropy only...
            Else
                rstr.RequestedProofToken = proofToken
            End If

            Return rstr
        End Function

        '/ <summary>
        '/ Virtual method for ProcessRequestSecurityToken.
        '/ Should be overriden by STS implementations that derive from this base class.
        '/ </summary>
        Public Function ProcessRequestSecurityToken(ByVal msg As Message) As Message _
            Implements ISecurityTokenService.ProcessRequestSecurityToken

            EnsureRequestSecurityTokenAction(msg)

            ' Extract the MessageID from the request message.
            Dim requestMessageID As UniqueId = msg.Headers.MessageId
            If requestMessageID Is Nothing Then
                Throw New InvalidOperationException("The request message does not have a message ID.")
            End If
            ' Get the RST from the message.
            Dim rst As RequestSecurityToken = RequestSecurityToken.CreateFrom(msg.GetReaderAtBodyContents())

            ' Set up the claims to be issued.
            Dim samlAttributes As Collection(Of SamlAttribute) = GetIssuedClaims(rst)

            ' Get the key size, default to 192.
            Dim keySize As Integer = IIf(rst.KeySize <> 0, rst.KeySize, 192) 'TODO: For performance reasons this should be changed to nested IF statements

            ' Create proof token.
            ' Get requestor entropy, if any.
            Dim senderEntropy As Byte() = Nothing
            Dim entropyToken As SecurityToken = rst.RequestorEntropy
            If Not (entropyToken Is Nothing) Then
                senderEntropy = CType(entropyToken, BinarySecretSecurityToken).GetKeyBytes()
            End If

            Dim key As Byte() = Nothing
            Dim stsEntropy As Byte() = Nothing

            ' If the sender provided entropy, then use combined entropy.
            If Not (senderEntropy Is Nothing) Then
                ' Create an array to store the entropy bytes.
                stsEntropy = New Byte(keySize / 8) {}
                ' Create some random bytes.
                Dim random As New RNGCryptoServiceProvider()
                random.GetNonZeroBytes(stsEntropy)
                ' Compute the combined key.
                key = RequestSecurityTokenResponse.ComputeCombinedKey(senderEntropy, stsEntropy, keySize)
                ' Issuer entropy only...
            Else
                ' Create an array to store the entropy bytes.
                key = New Byte(keySize / 8) {}
                ' Create some random bytes.
                Dim random As New RNGCryptoServiceProvider()
                random.GetNonZeroBytes(key)
            End If

            ' Create a BinarySecretSecurityToken to be the proof token, based on the key material
            ' in key. The key is the combined key in the combined entropy case, or the issuer entropy
            ' otherwise.
            Dim proofToken As New BinarySecretSecurityToken(key)

            ' Create a SAML token, valid for around 10 hours.
            Dim samlToken As SamlSecurityToken = SamlTokenCreator.CreateSamlToken(Me.stsNameValue, proofToken, Me.IssuerTokenValue, Me.ProofKeyEncryptionTokenValue, New SamlConditions(DateTime.UtcNow - TimeSpan.FromMinutes(5), DateTime.UtcNow + TimeSpan.FromHours(10)), samlAttributes)

            ' Set up RSTR.
            Dim rstr As RequestSecurityTokenBase = GetRequestSecurityTokenResponse(rst, keySize, proofToken, samlToken, senderEntropy, stsEntropy)

            ' Create a message from the RSTR.
            Dim rstrMessage As Message = Message.CreateMessage(msg.Version, Constants.Trust.Actions.IssueReply, rstr)

            ' Set the RelatesTo of response message to the MessageID of request message.
            rstrMessage.Headers.RelatesTo = requestMessageID

            ' Return the created message.
            Return rstrMessage

        End Function
    End Class
    <ServiceContract(Name:="SecurityTokenService", [Namespace]:="http://tempuri.org")> _
    Public Interface ISecurityTokenService
        <OperationContract(Action:=Constants.Trust.Actions.Issue, ReplyAction:=Constants.Trust.Actions.IssueReply)> _
        Function ProcessRequestSecurityToken(ByVal msg As Message) As Message
    End Interface 'ISecurityTokenService
    '/ <summary>
    '/ Abstract base class that contains properties that are shared by RST and RSTR classes.
    '/ </summary>
    <ComVisible(False)> _
    Public MustInherit Class RequestSecurityTokenBase
        Inherits BodyWriter
        ' Private members
        Private m_context As String
        Private m_tokenType As String
        Private m_keySize As Integer
        Private m_appliesTo As EndpointAddress


        ' Constructors
        '/ <summary>
        '/ Default constructor
        '/ </summary>
        Protected Sub New()
            MyClass.New(String.Empty, String.Empty, 0, Nothing)

        End Sub 'New


        '/ <summary>
        '/ Parameterized constructor
        '/ </summary>
        '/ <param name="context">The value of the wst:RequestSecurityToken/@Context attribute in the request message, if any.</param>
        '/ <param name="tokenType">The content of the wst:RequestSecurityToken/wst:TokenType element in the request message, if any.</param>
        '/ <param name="keySize">The content of the wst:RequestSecurityToken/wst:KeySize element in the request message, if any.</param>
        '/ <param name="appliesTo">An EndpointRefernece that corresponds to the content of the wst:RequestSecurityToken/wsp:AppliesTo element in the request message, if any.</param>
        Protected Sub New(ByVal context As String, ByVal tokenType As String, ByVal keySize As Integer, ByVal appliesTo As EndpointAddress)
            MyBase.New(True)
            Me.m_context = context
            Me.m_tokenType = tokenType
            Me.m_keySize = keySize
            Me.m_appliesTo = appliesTo

        End Sub 'New

        ' Public properties
        '/ <summary>
        '/ Context for the RST/RSTR exchange. 
        '/ The value of the wst:RequestSecurityToken/@Context attribute from RequestSecurityToken messages.
        '/ The value of the wst:RequestSecurityTokenResponse/@Context attribute from RequestSecurityTokenResponse messages.        
        '/ </summary>

        Public Property Context() As String
            Get
                Return m_context
            End Get
            Set(ByVal value As String)
                m_context = value
            End Set
        End Property
        '/ <summary>
        '/ The type of token requested or returned.
        '/ The value of the wst:RequestSecurityToken/wst:TokenType element from RequestSecurityToken messages.
        '/ The value of the wst:RequestSecurityTokenResponse/wst:TokenType element from RequestSecurityTokenResponse messages.       
        '/ </summary>

        Public Property TokenType() As String
            Get
                Return m_tokenType
            End Get
            Set(ByVal value As String)
                m_tokenType = value
            End Set
        End Property

        '/ <summary>
        '/ The size of the requested proof key.
        '/ The value of the wst:RequestSecurityToken/wst:KeySize element from RequestSecurityToken messages.
        '/ The value of the wst:RequestSecurityTokenResponse/wst:KeySize element from RequestSecurityTokenResponse messages.       
        '/ </summary>

        Public Property KeySize() As Integer
            Get
                Return m_keySize
            End Get
            Set(ByVal value As Integer)
                m_keySize = value
            End Set
        End Property
        '/ <summary>
        '/ The EndpointAddress a token is being requested or returned for. 
        '/ The content of the wst:RequestSecurityToken/wsp:AppliesTo element from RequestSecurityToken messages.
        '/ The content of the wst:RequestSecurityTokenResponse/wsp:AppliesTo element from RequestSecurityTokenResponse messages.       
        '/ </summary>public int KeySize

        Public Property AppliesTo() As EndpointAddress
            Get
                Return m_appliesTo
            End Get
            Set(ByVal value As EndpointAddress)
                m_appliesTo = value
            End Set
        End Property
    End Class 'RequestSecurityTokenBase '/ <summary>.
    '/ A class that represents a RequestSecurityToken message according to February 2005 WS-Trust
    '/ </summary>
    <ComVisible(False)> _
    Public Class RequestSecurityToken
        Inherits RequestSecurityTokenBase
        ' Private members
        Private requestorEntropyValue As SecurityToken


        ' Constructors
        '/ <summary>
        '/ Default constructor
        '/ </summary>
        Public Sub New()
            MyClass.New(String.Empty, String.Empty, 0, Nothing, Nothing)

        End Sub 'New


        '/ <summary>
        '/ Parameterized constructor
        '/ </summary>
        '/ <param name="context">The value of the wst:RequestSecurityToken/@Context attribute.</param>
        '/ <param name="tokenType">The content of the wst:RequestSecurityToken/wst:TokenType element.</param>
        '/ <param name="keySize">The content of the wst:RequestSecurityToken/wst:KeySize element.</param>
        '/ <param name="appliesTo">An EndpointReference that corresponds to the content of the wst:RequestSecurityToken/wsp:AppliesTo element.</param>
        '/ <param name="entropy">A SecurityToken that represents entropy provided by the requestor in the wst:RequestSecurityToken/wst:Entropy element.</param>        
        Public Sub New(ByVal context As String, ByVal tokenType As String, ByVal keySize As Integer, ByVal appliesTo As EndpointAddress, ByVal entropy As SecurityToken)
            MyBase.New(context, tokenType, keySize, appliesTo) ' Pass first 4 params to base class
            Me.requestorEntropy = entropy

        End Sub 'New

        ' Public properties
        '/ <summary>
        '/ The SecurityToken that represents entropy provided by the requestor.
        '/ Null if the requestor did not provide entropy.
        '/ </summary>

        Public Property RequestorEntropy() As SecurityToken
            Get
                Return requestorEntropyValue
            End Get
            Set(ByVal value As SecurityToken)
                requestorEntropyValue = value
            End Set
        End Property

        ' Static methods
        '/ <summary>
        '/ Reads a wst:RequestSecurityToken element, its attributes and children and 
        '/ creates a RequestSecurityToken instance with the appropriate values.
        '/ </summary>
        '/ <param name="xr">An XmlReader positioned on wst:RequestSecurityToken.</param>
        '/ <returns>A RequestSecurityToken instance, initialized with the data read from the XmlReader.</returns>
        Public Shared Function CreateFrom(ByVal xr As XmlReader) As RequestSecurityToken
            Return ProcessRequestSecurityTokenElement(xr)

        End Function 'CreateFrom


        ' Methods of BodyWriter
        '/ <summary>
        '/ Writes out an XML representation of the instance.
        '/ Provided here for completeness. Not actually called by this sample.
        '/ </summary>
        '/ <param name="writer">The writer to be used to write out the XML content.</param>
        Protected Overrides Sub OnWriteBodyContents(ByVal writer As XmlDictionaryWriter)
            ' Write out the wst:RequestSecurityToken start tag.
            writer.WriteStartElement(Constants.Trust.Elements.RequestSecurityToken, Constants.Trust.NamespaceUri)

            ' If we have a non-null, non-empty tokenType...
            If Not (Me.TokenType Is Nothing) AndAlso Me.TokenType.Length > 0 Then
                ' Write out the wst:TokenType start tag.
                writer.WriteStartElement(Constants.Trust.Elements.TokenType, Constants.Trust.NamespaceUri)
                ' Write out the tokenType string.
                writer.WriteString(Me.TokenType)
                writer.WriteEndElement() ' wst:TokenType
            End If

            ' If we have a non-null appliesTo...
            If Not (Me.AppliesTo Is Nothing) Then
                ' Write out the wsp:AppliesTo start tag.
                writer.WriteStartElement(Constants.Policy.Elements.AppliesTo, Constants.Policy.NamespaceUri)
                ' Write the appliesTo in WS-Addressing 1.0 format.
                Me.AppliesTo.WriteTo(AddressingVersion.WSAddressing10, writer)
                writer.WriteEndElement() ' wsp:AppliesTo
            End If

            ' If the requestor provided entropy.
            If Not (Me.requestorEntropyValue Is Nothing) Then
                ' Write out the wst:Entropy start tag.
                writer.WriteStartElement(Constants.Trust.Elements.Entropy, Constants.Trust.NamespaceUri)

                ' Make the requesterEntropy SecurityToken into a BinarySecretSecurityToken.
                Dim bsst As BinarySecretSecurityToken = CType(Me.requestorEntropy, BinarySecretSecurityToken)

                ' If requesterEntropy is a BinarySecretSecurityToken.
                If Not (bsst Is Nothing) Then
                    ' Write out the wst:BinarySecret start tag.
                    writer.WriteStartElement(Constants.Trust.Elements.BinarySecret, Constants.Trust.NamespaceUri)

                    ' Get the entropy bytes.
                    Dim key As Byte() = bsst.GetKeyBytes()

                    ' Write them out as base64.
                    writer.WriteBase64(key, 0, key.Length)
                    writer.WriteEndElement() ' wst:BinarySecret
                End If

                writer.WriteEndElement() ' wst:Entropy
            End If

            ' If there is a specified keySize...
            If Me.KeySize > 0 Then
                ' Write the wst:KeySize start tag.
                writer.WriteStartElement(Constants.Trust.Elements.KeySize, Constants.Trust.NamespaceUri)
                ' Write the keySize.
                writer.WriteValue(Me.KeySize)
                writer.WriteEndElement() ' wst:KeySize
            End If

            writer.WriteEndElement()
            ' wst:RequestSecurityToken
        End Sub 'OnWriteBodyContents



        ' Private methods
        '/ <summary>
        '/ Reads the wst:RequestSecurityToken element.
        '/ </summary>
        '/ <param name="xr">An XmlReader, positioned on the start tag of wst:RequestSecurityToken.</param>
        '/ <returns>A RequestSecurityToken instance, initialized with the data read from the XmlReader.</returns>
        Private Shared Function ProcessRequestSecurityTokenElement(ByVal xr As XmlReader) As RequestSecurityToken
            ' If the provided XmlReader is null, throw an exception.
            If xr Is Nothing Then
                Throw New ArgumentNullException("xr")
            End If
            ' If the wst:RequestSecurityToken element is empty, then throw an exception.
            If xr.IsEmptyElement Then
                Throw New ArgumentException("wst:RequestSecurityToken element was empty. Unable to create RequestSecurityToken object")
            End If
            ' Store the initial depth so this function can be exited when the corresponding end-tag is reached.
            Dim initialDepth As Integer = xr.Depth

            ' Extract the @Context attribute value.                        
            Dim context As String = xr.GetAttribute(Constants.Trust.Attributes.Context, String.Empty)

            ' Set up some default values.
            Dim tokenType As String = String.Empty
            Dim keySize As Integer = 0
            Dim appliesTo As EndpointAddress = Nothing
            Dim entropy As SecurityToken = Nothing

            ' Enter a read loop...
            While xr.Read()
                ' Process element start tags
                If XmlNodeType.Element = xr.NodeType Then
                    ' Process WS-Trust elements.
                    If Constants.Trust.NamespaceUri = xr.NamespaceURI Then
                        If Constants.Trust.Elements.TokenType = xr.LocalName AndAlso Not xr.IsEmptyElement Then
                            xr.Read()
                            tokenType = xr.ReadContentAsString()
                        ElseIf Constants.Trust.Elements.KeySize = xr.LocalName AndAlso Not xr.IsEmptyElement Then
                            xr.Read()
                            keySize = xr.ReadContentAsInt()
                        ElseIf Constants.Trust.Elements.Entropy = xr.LocalName AndAlso Not xr.IsEmptyElement Then
                            entropy = ProcessEntropyElement(xr)
                        End If
                        ' Process WS-Policy elements.
                    ElseIf Constants.Policy.NamespaceUri = xr.NamespaceURI Then
                        If Constants.Policy.Elements.AppliesTo = xr.LocalName AndAlso Not xr.IsEmptyElement Then
                            appliesTo = ProcessAppliesToElement(xr)
                        End If
                    End If
                End If

                ' Look for the end-tag that corresponds to the start-tag that the reader was positioned 
                ' on when the method was called. When it is found, break out of the read loop.
                If Constants.Trust.Elements.RequestSecurityToken = xr.LocalName AndAlso Constants.Trust.NamespaceUri = xr.NamespaceURI AndAlso xr.Depth = initialDepth AndAlso XmlNodeType.EndElement = xr.NodeType Then
                    Exit While
                End If
            End While
            ' Construct a new RequestSecurityToken based on the values read and return it
            Return New RequestSecurityToken(context, tokenType, keySize, appliesTo, entropy)

        End Function 'ProcessRequestSecurityTokenElement


        '/ <summary>
        '/ Reads a wst:Entropy element and constructs a SecurityToken.
        '/ Assumes that the provided entropy is never more than 1Kb in size.
        '/ </summary>
        '/ <param name="xr">An XmlReader positioned on the start tag of wst:Entropy.</param>
        '/ <returns>A SecurityToken that contains the entropy value.</returns>
        Private Shared Function ProcessEntropyElement(ByVal xr As XmlReader) As SecurityToken
            ' If the provided XmlReader is null, throw an exception.
            If xr Is Nothing Then
                Throw New ArgumentNullException("xr")
            End If
            ' If the wst:Entropy element is empty, then throw an exception.
            If xr.IsEmptyElement Then
                Throw New ArgumentException("wst:Entropy element was empty. Unable to create SecurityToken object")
            End If
            ' Store the initial depth so this function can be exited when the corresponding end-tag is reached.
            Dim initialDepth As Integer = xr.Depth

            ' Set the return value to null.
            Dim st As SecurityToken = Nothing

            ' Enter a read loop...
            While xr.Read()
                ' Look for a non-empty wst:BinarySecret element.
                If Constants.Trust.Elements.BinarySecret = xr.LocalName AndAlso Constants.Trust.NamespaceUri = xr.NamespaceURI AndAlso Not xr.IsEmptyElement AndAlso XmlNodeType.Element = xr.NodeType Then
                    ' Allocate a 1024 byte buffer for the entropy.
                    Dim temp(1023) As Byte
                    ' Move reader to the content of wst:BinarySecret element...
                    xr.Read()

                    ' ...and read that content as base64. Store the actual number of bytes we get.                    
                    Dim nBytes As Integer = xr.ReadContentAsBase64(temp, 0, temp.Length)

                    ' Allocate a new array of the correct size to hold the provided entropy.
                    Dim entropy(nBytes) As Byte

                    ' Copy the entropy from the temporary array into the new array.
                    Dim i As Integer
                    For i = 0 To nBytes
                        entropy(i) = temp(i)
                    Next i
                    ' Create new BinarySecretSecurityToken from the provided entropy.
                    st = New BinarySecretSecurityToken(entropy)
                End If

                ' Look for the end-tag that corresponds to the start-tag that the reader was positioned 
                ' on when the method was called. When it is found, break out of the read loop.
                If Constants.Trust.Elements.Entropy = xr.LocalName AndAlso Constants.Trust.NamespaceUri = xr.NamespaceURI AndAlso xr.Depth = initialDepth AndAlso XmlNodeType.EndElement = xr.NodeType Then
                    Exit While
                End If
            End While
            ' Return the SecurityToken.
            Return st

        End Function 'ProcessEntropyElement


        '/ <summary>
        '/ Reads a wsp:AppliesTo element.
        '/ </summary>
        '/ <param name="xr">An XmlReader positioned on the start tag of wsp:AppliesTo.</param>
        '/ <returns>An EndpointAddress.</returns>
        Private Shared Function ProcessAppliesToElement(ByVal xr As XmlReader) As EndpointAddress
            ' If the provided XmlReader is null, throw an exception.
            If xr Is Nothing Then
                Throw New ArgumentNullException("xr")
            End If
            ' If the wsp:AppliesTo element is empty, then throw an exception.
            If xr.IsEmptyElement Then
                Throw New ArgumentException("wsp:AppliesTo element was empty. Unable to create EndpointAddress object")
            End If
            ' Store the initial depth so  this function can be exited when the corresponding end-tag is found.
            Dim initialDepth As Integer = xr.Depth

            ' Set the return value to null.
            Dim ea As EndpointAddress = Nothing

            ' Enter a read loop...
            While xr.Read()
                ' Look for a WS-Addressing 1.0 Endpoint Reference...
                If Constants.Addressing.Elements.EndpointReference = xr.LocalName AndAlso Constants.Addressing.NamespaceUri = xr.NamespaceURI AndAlso Not xr.IsEmptyElement AndAlso XmlNodeType.Element = xr.NodeType Then
                    ' Create a DataContractSerializer for an EndpointAddress10.
                    Dim dcs As New DataContractSerializer(GetType(EndpointAddress10))
                    ' Read the EndpointAddress10 from the DataContractSerializer.
                    Dim ea10 As EndpointAddress10 = CType(dcs.ReadObject(xr, False), EndpointAddress10)
                    ' Convert the EndpointAddress10 into an EndpointAddress.
                    ea = ea10.ToEndpointAddress()
                End If

                ' Look for the end-tag that corresponds to the start-tag the reader was positioned 
                ' on when the method was called. When it is found, break out of the read loop.
                If Constants.Policy.Elements.AppliesTo = xr.LocalName AndAlso Constants.Policy.NamespaceUri = xr.NamespaceURI AndAlso xr.Depth = initialDepth AndAlso XmlNodeType.EndElement = xr.NodeType Then
                    Exit While
                End If
            End While
            ' Return the EndpointAddress.
            Return ea

        End Function 'ProcessAppliesToElement
    End Class 'RequestSecurityToken

    Public Class Constants
        Public Const BookNameHeaderNamespace As String = "http://tempuri.org/"
        Public Const BookNameHeaderName As String = "BookName"
        Public Const PurchaseClaimNamespace As String = "http://tempuri.org/"
        Public Const PurchaseAuthorizedClaim As String = PurchaseClaimNamespace + "PurchaseAuthorizedClaim"
        Public Const PurchaseLimitClaim As String = PurchaseClaimNamespace + "PurchaseLimitClaim"
        Public Const SamlTokenTypeUri As String = "http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV1.1"

        ' Various constants for WS-Trust.

        Public Class Trust
            Public Const NamespaceUri As String = "http://schemas.xmlsoap.org/ws/2005/02/trust"


            Public Class Actions
                Public Const Issue As String = "http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue"
                Public Const IssueReply As String = "http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/Issue"
            End Class 'Actions


            Public Class Attributes
                Public Const Context As String = "Context"
            End Class 'Attributes


            Public Class Elements
                Public Const KeySize As String = "KeySize"
                Public Const Entropy As String = "Entropy"
                Public Const BinarySecret As String = "BinarySecret"
                Public Const RequestSecurityToken As String = "RequestSecurityToken"
                Public Const RequestSecurityTokenResponse As String = "RequestSecurityTokenResponse"
                Public Const TokenType As String = "TokenType"
                Public Const RequestedSecurityToken As String = "RequestedSecurityToken"
                Public Const RequestedAttachedReference As String = "RequestedAttachedReference"
                Public Const RequestedUnattachedReference As String = "RequestedUnattachedReference"
                Public Const RequestedProofToken As String = "RequestedProofToken"
                Public Const ComputedKey As String = "ComputedKey"
            End Class 'Elements


            Public Class ComputedKeyAlgorithms
                Public Const PSHA1 As String = "http://schemas.xmlsoap.org/ws/2005/02/trust/CK/PSHA1"
            End Class 'ComputedKeyAlgorithms
        End Class 'Trust

        ' Various constants for WS-Policy.

        Public Class Policy
            Public Const NamespaceUri As String = "http://schemas.xmlsoap.org/ws/2004/09/policy"


            Public Class Elements
                Public Const AppliesTo As String = "AppliesTo"
            End Class 'Elements
        End Class 'Policy

        ' Various constants for WS-Addressing.

        Public Class Addressing
            Public Const NamespaceUri As String = "http://www.w3.org/2005/08/addressing"


            Public Class Elements
                Public Const EndpointReference As String = "EndpointReference"
            End Class 'Elements
        End Class 'Addressing
    End Class 'Constants
    '/ <summary>
    '/ A class that represents a RequestSecurityTokenResponse message according to February 2005 WS-Trust.
    '/ </summary>
    <ComVisible(False)> _
    Public Class RequestSecurityTokenResponse
        Inherits RequestSecurityTokenBase
        ' Private members
        Private requestedSecurityTokenValue As SecurityToken
        Private requestedProofTokenValue As SecurityToken
        Private issuerEntropyValue As SecurityToken
        Private requestedAttachedReferenceValue As SecurityKeyIdentifierClause
        Private requestedUnattachedReferenceValue As SecurityKeyIdentifierClause
        Private computeKeyValue As Boolean


        ' Constructors
        '/ <summary>
        '/ Default constructor
        '/ </summary>
        Public Sub New()
            MyClass.New(String.Empty, String.Empty, 0, Nothing, Nothing, Nothing, False)

        End Sub 'New


        '/ <summary>
        '/ Parameterized constructor
        '/ </summary>
        '/ <param name="context">The value of the wst:RequestSecurityTokenResponse/@Context attribute.</param>
        '/ <param name="tokenType">The content of the wst:RequestSecurityTokenResponse/wst:TokenType element.</param>
        '/ <param name="keySize">The content of the wst:RequestSecurityTokenResponse/wst:KeySize element. </param>
        '/ <param name="appliesTo">An EndpointReference that corresponds to the content of the wst:RequestSecurityTokenResponse/wsp:AppliesTo element.</param>
        '/ <param name="requestedSecurityToken">The requested security token</param>
        '/ <param name="requestedProofToken">The proof token associated with the requested security token</param>
        '/ <param name="computeKey">A boolean that specifies whether a key value must be computed.</param>
        Public Sub New(ByVal context As String, ByVal tokenType As String, ByVal keySize As Integer, ByVal appliesTo As EndpointAddress, ByVal requestedSecurityToken As SecurityToken, ByVal requestedProofToken As SecurityToken, ByVal computeKey As Boolean)
            MyBase.New(context, tokenType, keySize, appliesTo) ' Pass first 4 params to base class
            Me.requestedSecurityTokenValue = requestedSecurityToken
            Me.requestedProofTokenValue = requestedProofToken
            Me.computeKeyValue = computeKey

        End Sub 'New

        ' public properties
        '/ <summary>
        '/ The requested SecurityToken.
        '/ </summary>

        Public Property RequestedSecurityToken() As SecurityToken
            Get
                Return requestedSecurityTokenValue
            End Get
            Set(ByVal value As SecurityToken)
                requestedSecurityTokenValue = value
            End Set
        End Property
        '/ <summary>
        '/ A SecurityToken that represents the proof token associated with 
        '/ the requested SecurityToken.
        '/ </summary>

        Public Property RequestedProofToken() As SecurityToken
            Get
                Return requestedProofTokenValue
            End Get
            Set(ByVal value As SecurityToken)
                requestedProofTokenValue = value
            End Set
        End Property
        '/ <summary>
        '/ A SecurityKeyIdentifierClause that can be used to refer to the requested 
        '/ SecurityToken when that token is present in messages.
        '/ </summary>

        Public Property RequestedAttachedReference() As SecurityKeyIdentifierClause
            Get
                Return requestedAttachedReferenceValue
            End Get
            Set(ByVal value As SecurityKeyIdentifierClause)
                requestedAttachedReferenceValue = value
            End Set
        End Property
        '/ <summary>
        '/ A SecurityKeyIdentifierClause that can be used to refer to the requested 
        '/ SecurityToken when that token is present in messages.
        '/ </summary>

        Public Property RequestedUnattachedReference() As SecurityKeyIdentifierClause
            Get
                Return requestedUnattachedReferenceValue
            End Get
            Set(ByVal value As SecurityKeyIdentifierClause)
                requestedUnattachedReferenceValue = value
            End Set
        End Property
        '/ <summary>
        '/ The SecurityToken that represents entropy provided by the issuer.
        '/ Null if the issuer did not provide entropy.
        '/ </summary>

        Public Property IssuerEntropy() As SecurityToken
            Get
                Return issuerEntropyValue
            End Get
            Set(ByVal value As SecurityToken)
                issuerEntropyValue = value
            End Set
        End Property
        '/ <summary>
        '/ Indicates whether a key must be computed (typically from the combination of issuer and requestor entropy).
        '/ </summary>

        Public Property ComputeKey() As Boolean
            Get
                Return computeKeyValue
            End Get
            Set(ByVal value As Boolean)
                computeKeyValue = value
            End Set
        End Property

        ' public methods
        '/ <summary>
        '/ Static method that computes a combined key from issuer and requestor entropy using PSHA1 according to WS-Trust.
        '/ </summary>
        '/ <param name="requestorEntropy">Entropy provided by the requestor.</param>
        '/ <param name="issuerEntropy">Entropy provided by the issuer.</param>
        '/ <param name="keySize">Size of required key, in bits.</param>
        '/ <returns>Array of bytes that contains key material.</returns>
        Public Shared Function ComputeCombinedKey(ByVal requestorEntropy() As Byte, ByVal issuerEntropy() As Byte, ByVal keySize As Integer) As Byte()
            Dim kha As KeyedHashAlgorithm = New HMACSHA1(requestorEntropy, True)

            Dim key(keySize / 8) As Byte ' Final key
            Dim a As Byte() = issuerEntropy ' A(0)
            Dim b(kha.HashSize / 8 + a.Length) As Byte ' Buffer for A(i) + seed
            Dim i As Integer

            While i < key.Length
                ' Calculate A(i+1).                
                kha.Initialize()
                a = kha.ComputeHash(a)

                ' Calculate A(i) + seed
                a.CopyTo(b, 0)
                issuerEntropy.CopyTo(b, a.Length)
                kha.Initialize()
                Dim result As Byte() = kha.ComputeHash(b)

                Dim j As Integer
                For j = 0 To result.Length
                    If i < key.Length Then
                        i += 1
                        key(i) = result(j)
                    Else
                        Exit For
                    End If
                Next j
            End While
            Return key

        End Function 'ComputeCombinedKey


        ' Methods of BodyWriter        
        '/ <summary>
        '/ Writes out an XML representation of the instance.
        '/ </summary>
        '/ <param name="writer">The writer to be used to write out the XML content.</param>
        Protected Overrides Sub OnWriteBodyContents(ByVal writer As XmlDictionaryWriter)
            ' Write out the wst:RequestSecurityTokenResponse start tag.
            writer.WriteStartElement(Constants.Trust.Elements.RequestSecurityTokenResponse, Constants.Trust.NamespaceUri)

            ' If we have a non-null, non-empty tokenType...
            If Not (Me.TokenType Is Nothing) AndAlso Me.TokenType.Length > 0 Then
                ' Write out the wst:TokenType start tag.
                writer.WriteStartElement(Constants.Trust.Elements.TokenType, Constants.Trust.NamespaceUri)
                ' Write out the tokenType string.
                writer.WriteString(Me.TokenType)
                writer.WriteEndElement() ' wst:TokenType
            End If

            ' Create a serializer that knows how to write out security tokens.
            Dim ser As New WSSecurityTokenSerializer()

            ' If we have a requestedSecurityToken...
            If Not (Me.requestedSecurityToken Is Nothing) Then
                ' Write out the wst:RequestedSecurityToken start tag.
                writer.WriteStartElement(Constants.Trust.Elements.RequestedSecurityToken, Constants.Trust.NamespaceUri)
                ' Write out the requested token using the serializer.
                ser.WriteToken(writer, requestedSecurityToken)
                writer.WriteEndElement() ' wst:RequestedSecurityToken
            End If

            ' If we have a requestedAttachedReference...
            If Not (Me.requestedAttachedReference Is Nothing) Then
                ' Write out the wst:RequestedAttachedReference start tag.
                writer.WriteStartElement(Constants.Trust.Elements.RequestedAttachedReference, Constants.Trust.NamespaceUri)
                ' Write out the reference using the serializer.
                ser.WriteKeyIdentifierClause(writer, Me.requestedAttachedReference)
                writer.WriteEndElement() ' wst:RequestedAttachedReference
            End If

            ' If we have a requestedUnattachedReference...
            If Not (Me.requestedUnattachedReference Is Nothing) Then
                ' Write out the wst:RequestedUnattachedReference start tag.
                writer.WriteStartElement(Constants.Trust.Elements.RequestedUnattachedReference, Constants.Trust.NamespaceUri)
                ' Write out the reference using the serializer.
                ser.WriteKeyIdentifierClause(writer, Me.requestedUnattachedReference)
                writer.WriteEndElement() ' wst:RequestedAttachedReference
            End If

            ' If we have a non-null appliesTo...
            If Not (Me.AppliesTo Is Nothing) Then
                ' Write out the wsp:AppliesTo start tag.
                writer.WriteStartElement(Constants.Policy.Elements.AppliesTo, Constants.Policy.NamespaceUri)
                ' Write the appliesTo in WS-Addressing 1.0 format.
                Me.AppliesTo.WriteTo(AddressingVersion.WSAddressing10, writer)
                writer.WriteEndElement() ' wsp:AppliesTo
            End If

            ' If the requestedProofToken is non-null, then the STS provides all the key material...
            If Not (Me.requestedProofToken Is Nothing) Then
                ' Write the wst:RequestedProofToken start tag.
                writer.WriteStartElement(Constants.Trust.Elements.RequestedProofToken, Constants.Trust.NamespaceUri)
                ' Write the proof token using the serializer.
                ser.WriteToken(writer, requestedProofToken)
                writer.WriteEndElement() ' wst:RequestedSecurityToken
            End If

            ' If issuerEntropy is non-null and computeKey is true, then combined entropy is being used...
            If Not (Me.issuerEntropy Is Nothing) AndAlso Me.computeKey Then
                ' Write the wst:RequestedProofToken start tag.
                writer.WriteStartElement(Constants.Trust.Elements.RequestedProofToken, Constants.Trust.NamespaceUri)
                ' Write the wst:ComputeKey start tag.
                writer.WriteStartElement(Constants.Trust.Elements.ComputedKey, Constants.Trust.NamespaceUri)
                ' Write the PSHA1 algorithm value.
                writer.WriteValue(Constants.Trust.ComputedKeyAlgorithms.PSHA1)
                writer.WriteEndElement() ' wst:ComputedKey
                writer.WriteEndElement() ' wst:RequestedSecurityToken
                ' Write the wst:Entropy start tag.
                writer.WriteStartElement(Constants.Trust.Elements.Entropy, Constants.Trust.NamespaceUri)
                ' Write the issuerEntropy out using the serializer.
                ser.WriteToken(writer, Me.issuerEntropy)
                writer.WriteEndElement() ' wst:Entropy
            End If

            writer.WriteEndElement()
            ' wst:RequestSecurityTokenResponse
        End Sub 'OnWriteBodyContents
    End Class 'RequestSecurityTokenResponse

    Public NotInheritable Class FederationUtilities

        '/ <summary>
        '/ Utility method to get a certificate from a given store.
        '/ </summary>
        '/ <param name="storeName">Name of certificate store (for example: My, TrustedPeople).</param>
        '/ <param name="storeLocation">Location of certificate store (for example: LocalMachine, CurrentUser).</param>
        '/ <param name="subjectDistinguishedName">The Subject Distinguished Name of the certificate.</param>
        '/ <returns>The specified X.509 certificate.</returns>
        Shared Function LookupCertificate(ByVal storeName As StoreName, ByVal storeLocation As StoreLocation, ByVal subjectDistinguishedName As String) As X509Certificate2
            Dim store As X509Store = Nothing
            Try
                store = New X509Store(storeName, storeLocation)
                store.Open(OpenFlags.ReadOnly)
                Dim certs As X509Certificate2Collection = store.Certificates.Find(X509FindType.FindBySubjectDistinguishedName, subjectDistinguishedName, False)
                If certs.Count <> 1 Then
                    Throw New Exception(String.Format("FedUtil: Certificate {0} not found or more than one certificate found", subjectDistinguishedName))
                End If
                Return CType(certs(0), X509Certificate2)
            Finally
                If Not (store Is Nothing) Then
                    store.Close()
                End If
            End Try

        End Function 'LookupCertificate 

#Region "GetX509TokenFromCert()"

        '/ <summary>
        '/ Utility method to get an X.509 token from a given certificate.
        '/ </summary>
        '/ <param name="storeName">Name of certificate store (for example: My, TrustedPeople).</param>
        '/ <param name="storeLocation">Location of certificate store (for example: LocalMachine, CurrentUser).</param>
        '/ <param name="subjectDistinguishedName">The Subject Distinguished Name of the certificate.</param>
        '/ <returns>The corresponding X.509 Token.</returns>
        Public Shared Function GetX509TokenFromCert(ByVal storeName As StoreName, ByVal storeLocation As StoreLocation, ByVal subjectDistinguishedName As String) As X509SecurityToken
            Dim certificate As X509Certificate2 = LookupCertificate(storeName, storeLocation, subjectDistinguishedName)
            Dim t As New X509SecurityToken(certificate)
            Return t

        End Function 'GetX509TokenFromCert
#End Region

#Region "GetCertificateThumbprint"

        '/ <summary>
        '/ Utility method to get an X.509 Certificate thumbprint.
        '/ </summary>
        '/ <param name="storeName">Name of certificate store (for example: My, TrustedPeople).</param>
        '/ <param name="storeLocation">Location of certificate store (for example: LocalMachine, CurrentUser).</param>
        '/ <param name="subjectDistinguishedName">The Subject Distinguished Name of the certificate.</param>
        '/ <returns>The corresponding X.509 certificate thumbprint.</returns>
        Public Shared Function GetCertificateThumbprint(ByVal storeName As StoreName, ByVal storeLocation As StoreLocation, ByVal subjectDistinguishedName As String) As Byte()
            Dim certificate As X509Certificate2 = LookupCertificate(storeName, storeLocation, subjectDistinguishedName)
            Return certificate.GetCertHash()

        End Function 'GetCertificateThumbprint

#End Region


        Private Sub New()

        End Sub 'New
    End Class 'FederationUtilities

    Public NotInheritable Class SamlTokenCreator

        '/ <summary>
        '/ Creates a SAML token with the input parameters.
        '/ </summary>
        '/ <param name="stsName">Name of the STS issuing the SAML token.</param>
        '/ <param name="proofToken">Associated Proof Token</param>
        '/ <param name="issuerToken">Associated Issuer Token</param>
        '/ <param name="proofKeyEncryptionToken">Token to encrypt the proof key with.</param>
        '/ <param name="samlConditions">The Saml Conditions to be used in the construction of the SAML token.</param>
        '/ <param name="samlAttributes">The Saml Attributes to be used in the construction of the SAML token.</param>
        '/ <returns>A SAML Token</returns>
        Public Shared Function CreateSamlToken(ByVal stsName As String, _
                                               ByVal proofToken As BinarySecretSecurityToken, _
                                               ByVal issuerToken As SecurityToken, _
                                               ByVal proofKeyEncryptionToken As SecurityToken, _
                                               ByVal Conditions As SamlConditions, _
                                               ByVal samlAttributes As IEnumerable(Of SamlAttribute)) As SamlSecurityToken
            ' Create a security token reference to the issuer certificate. 
            Dim skic As SecurityKeyIdentifierClause = issuerToken.CreateKeyIdentifierClause(Of X509ThumbprintKeyIdentifierClause)()
            Dim issuerKeyIdentifier As New SecurityKeyIdentifier(skic)

            ' Create an encrypted key clause that contains the encrypted proof key.
            Dim wrappedKey As Byte() = proofKeyEncryptionToken.SecurityKeys(0).EncryptKey(SecurityAlgorithms.RsaOaepKeyWrap, proofToken.GetKeyBytes())
            Dim encryptingTokenClause As SecurityKeyIdentifierClause = proofKeyEncryptionToken.CreateKeyIdentifierClause(Of X509ThumbprintKeyIdentifierClause)()
            Dim encryptedKeyClause As New EncryptedKeyIdentifierClause(wrappedKey, SecurityAlgorithms.RsaOaepKeyWrap, New SecurityKeyIdentifier(encryptingTokenClause))
            Dim proofKeyIdentifier As New SecurityKeyIdentifier(encryptedKeyClause)

            ' Create a comfirmationMethod for HolderOfKey.
            Dim confirmationMethods As New List(Of String)()
            confirmationMethods.Add(SamlConstants.HolderOfKey)

            ' Create a SamlSubject with proof key and confirmation method from above.
            Dim samlSubject As New SamlSubject(Nothing, Nothing, Nothing, confirmationMethods, Nothing, proofKeyIdentifier)

            ' Create a SamlAttributeStatement from the passed in SamlAttribute collection and the SamlSubject from above.
            Dim samlAttributeStatement As New SamlAttributeStatement(samlSubject, samlAttributes)

            ' Put the SamlAttributeStatement into a list of SamlStatements.
            Dim samlSubjectStatements As New List(Of SamlStatement)()
            samlSubjectStatements.Add(samlAttributeStatement)

            ' Create a SigningCredentials instance from the key associated with the issuerToken.
            Dim signingCredentials As New SigningCredentials(issuerToken.SecurityKeys(0), SecurityAlgorithms.RsaSha1Signature, SecurityAlgorithms.Sha1Digest, issuerKeyIdentifier)

            ' Create a SamlAssertion from the list of SamlStatements previously created and the passed in
            ' SamlConditions.
            Dim samlAssertion As New SamlAssertion("_" + Guid.NewGuid().ToString(), stsName, DateTime.UtcNow, Conditions, New SamlAdvice(), samlSubjectStatements)
            ' Set the SigningCredentials for the SamlAssertion.
            samlAssertion.SigningCredentials = signingCredentials

            ' Create a SamlSecurityToken from the SamlAssertion and return it.
            Return New SamlSecurityToken(samlAssertion)
        End Function
        Private Sub New()
        End Sub
    End Class

    Class ServiceConstants
        ' Issuer name placed into issued tokens.
        Friend Const SecurityTokenServiceName As String = "BookStore STS"

        ' Statics for location of certificates.
        Friend Shared CertStoreName As StoreName = StoreName.TrustedPeople
        Friend Shared CertStoreLocation As StoreLocation = StoreLocation.LocalMachine

        ' Statics initialized from app.config.
        Friend Shared CertDistinguishedName As String
        Friend Shared TargetDistinguishedName As String
        Friend Shared IssuerDistinguishedName As String
        Friend Shared BookDB As String

        '/ <summary>
        '/ Helper function to load Application Settings from configuration.
        '/ </summary>
        Public Shared Sub LoadAppSettings()
            BookDB = ConfigurationManager.AppSettings("bookDB")
            CheckIfLoaded(BookDB)
            BookDB = String.Format("{0}\{1}", System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, BookDB)

            CertDistinguishedName = ConfigurationManager.AppSettings("certDistinguishedName")
            CheckIfLoaded(CertDistinguishedName)

            TargetDistinguishedName = ConfigurationManager.AppSettings("targetDistinguishedName")
            CheckIfLoaded(TargetDistinguishedName)

            IssuerDistinguishedName = ConfigurationManager.AppSettings("issuerDistinguishedName")
            CheckIfLoaded(IssuerDistinguishedName)

        End Sub 'LoadAppSettings


        '/ <summary>
        '/ Helper function to check whether a required Application Setting has been specified in configuration.
        '/ Throw an exception if some Application Setting has not been specified.
        '/ </summary>
        Private Shared Sub CheckIfLoaded(ByVal s As String)
            If String.IsNullOrEmpty(s) Then
                Throw New ConfigurationErrorsException("Required Configuration Element(s) missing at BookStoreSTS. Please check the STS configuration file.")
            End If

        End Sub 'CheckIfLoaded

        Private Sub New()

        End Sub 'New
    End Class 'ServiceConstants
End Namespace
