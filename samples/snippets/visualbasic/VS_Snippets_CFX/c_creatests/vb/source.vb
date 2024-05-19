Imports System.ServiceModel
Imports System.ServiceModel.Security
Imports System.IdentityModel.Tokens
Imports System.Collections.Generic
Imports System.Security.Permissions
Imports System.ServiceModel.Description
Imports System.ServiceModel.Security.Tokens
Imports System.IdentityModel.Claims
Imports System.ServiceModel.Channels
Imports System.Security.Cryptography.X509Certificates

Namespace CreateSts
    Public Class Test

        ' Used in: How To: Create Security Token Service.
        '<snippet1>
        Sub AddSigningCredentials(ByVal assertion As SamlAssertion, _
            ByVal signingKey As SecurityKey)
            Dim sc As New SigningCredentials(signingKey, _
            SecurityAlgorithms.RsaSha1Signature, SecurityAlgorithms.Sha1Digest)
            assertion.SigningCredentials = sc

        End Sub
        '</snippet1>

        '<snippet2>
        Function EncryptKey(ByVal plainTextKey() As Byte, _
                ByVal encryptingKey As SecurityKey) As Byte()
            Return encryptingKey.EncryptKey(SecurityAlgorithms.RsaOaepKeyWrap, plainTextKey)
        End Function
        '</snippet2>

        '<snippet3>
        Function GetKeyIdentifierForEncryptedKey(ByVal encryptedKey() _
         As Byte, ByVal encryptingToken As SecurityToken) _
            As SecurityKeyIdentifier
            Dim encryptingKeyIdentifier As New SecurityKeyIdentifier( _
                encryptingToken.CreateKeyIdentifierClause(Of X509ThumbprintKeyIdentifierClause)())
            Return New SecurityKeyIdentifier(New EncryptedKeyIdentifierClause( _
                encryptedKey, SecurityAlgorithms.RsaOaepKeyWrap, encryptingKeyIdentifier))
        End Function
        '</snippet3>

        '<snippet4>
        Function CreateSamlSubjectForProofKey( _
            ByVal proofKeyIdentifier As SecurityKeyIdentifier) As SamlSubject
            Dim confirmations As List(Of String) = New List(Of String)()
            confirmations.Add("urn:oasis:names:tc:SAML:1.0:cm:holder-of-key")
            Return New SamlSubject(Nothing, Nothing, "IssuerName", _
                confirmations, Nothing, proofKeyIdentifier)
        End Function
        '</snippet4>

        '<snippet5>
        Function CreateIssuedToken(ByVal assertion As SamlAssertion) As SecurityToken
            Return New SamlSecurityToken(assertion)
        End Function
        '</snippet5>

        '<snippet6>
        Function CreateProofToken(ByVal proofKey() As Byte) As BinarySecretSecurityToken
            Return New BinarySecretSecurityToken(proofKey)

        End Function
        '</snippet6>

        '<snippet7>
        Function CreateTokenReference(ByVal token As SamlSecurityToken) _
            As SecurityKeyIdentifierClause
            Return token.CreateKeyIdentifierClause( _
            Of SamlAssertionKeyIdentifierClause)()
        End Function
        '</snippet7>

        Private Sub CreateClaim()
            '<snippet8>
            Dim myClaim As New Claim(ClaimTypes.GivenName, "Martin", _
            Rights.PossessProperty)
            Dim sa As New SamlAttribute(myClaim)
            '</snippet8>
        End Sub
    End Class
End Namespace

Namespace Client

    Class Test

        Private Sub Run()
            Dim b As New WSHttpBinding()
            Dim ea As New EndpointAddress("http://localhost/Calculator")
            Dim client As New CalculatorClient(b, ea)
            '<snippet9>
            Dim itcc As IssuedTokenClientCredential = client.ClientCredentials.IssuedToken
            '</snippet9>

            '<snippet10>
            itcc.LocalIssuerAddress = New EndpointAddress("http://fabrikam.com/sts")
            '</snippet10>

            Dim a1 As AddressHeader = AddressHeader.CreateAddressHeader("Hello", "World", "hello")
            Dim addressHeaders() As AddressHeader = {a1}

            '<snippet11>
            itcc.LocalIssuerAddress = New EndpointAddress( _
            New Uri("http://fabrikam.com/sts"), addressHeaders)
            '</snippet11>

            '<snippet12>
            itcc.LocalIssuerAddress = New EndpointAddress(New Uri("http://fabrikam.com/sts"), _
            EndpointIdentity.CreateDnsIdentity("fabrikam.com"), addressHeaders)
            '</snippet12>

            '<snippet13>
            itcc.LocalIssuerBinding = New WSHttpBinding("LocalIssuerBinding")
            '</snippet13>            

            Dim myEndpointBehavior As New SynchronousReceiveBehavior()
            '<snippet14>            
            itcc.LocalIssuerChannelBehaviors.Add(myEndpointBehavior)
            '</snippet14>

            '<snippet15>
            itcc.MaxIssuedTokenCachingTime = New TimeSpan(0, 10, 0)
            '</snippet15>

            '<snippet16>
            itcc.IssuedTokenRenewalThresholdPercentage = 80
            '</snippet16>

            '<snippet17>
            itcc.DefaultKeyEntropyMode = SecurityKeyEntropyMode.ServerEntropy
            '</snippet17>

            '<snippet18>
            Dim rcc As X509CertificateRecipientClientCredential = _
            client.ClientCredentials.ServiceCertificate
            '</snippet18>

            Dim cert As New X509Certificate2()

            '<snippet19>
            rcc.ScopedCertificates.Add(New Uri("http://fabrikam.com/sts"), cert)
            '</snippet19>

            '<snippet20>
            rcc.SetScopedCertificate(StoreLocation.CurrentUser, _
                        StoreName.TrustedPeople, _
                        X509FindType.FindBySubjectName, _
                        "FabrikamSTS", _
                        New Uri("http://fabrikam.com/sts"))
            '</snippet20>

        End Sub
    End Class



    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"), System.ServiceModel.ServiceContractAttribute()> _
    Public Interface ICalculator

        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ICalculator/Divide", ReplyAction:="http://tempuri.org/ICalculator/DivideResponse")> _
        Function Divide(ByVal a As Double, ByVal b As Double) As Double

        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ICalculator/CalculateTax", ReplyAction:="http://tempuri.org/ICalculator/CalculateTaxResponse")> _
        Function CalculateTax(ByVal a As Double) As Double
    End Interface

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
    Public Interface ICalculatorChannel
        Inherits ICalculator, System.ServiceModel.IClientChannel
    End Interface

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
    Class CalculatorClient
        Inherits System.ServiceModel.ClientBase(Of ICalculator)
        Implements ICalculator

        Public Sub New()
        End Sub


        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub


        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub


        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub


        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)

        End Sub


        Public Function Divide(ByVal a As Double, ByVal b As Double) As Double Implements ICalculator.Divide
            Return MyBase.Channel.Divide(a, b)
        End Function

        Public Function CalculateTax(ByVal a As Double) As Double Implements _
        ICalculator.CalculateTax
            Return MyBase.Channel.CalculateTax(a)

        End Function
    End Class
End Namespace
