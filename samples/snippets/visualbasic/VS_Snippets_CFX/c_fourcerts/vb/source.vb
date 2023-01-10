'<snippet0>
Imports System.IdentityModel.Selectors
Imports System.IdentityModel.Tokens
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Permissions
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.ServiceModel.Security
Imports System.ServiceModel.Security.Tokens
Imports System.ServiceModel.Channels
Imports System.IdentityModel.Policy

Namespace Microsoft.ServiceModel.Samples
    '<snippet1>
    Public Class MyClientCredentials
        Inherits ClientCredentials

        Private clientSigningCert As X509Certificate2
        Private clientEncryptingCert As X509Certificate2
        Private serviceSigningCert As X509Certificate2
        Private serviceEncryptingCert As X509Certificate2

        Public Sub New()
        End Sub

        Protected Sub New(ByVal other As MyClientCredentials)
            MyBase.New(other)
            Me.clientEncryptingCert = other.clientEncryptingCert
            Me.clientSigningCert = other.clientSigningCert
            Me.serviceEncryptingCert = other.serviceEncryptingCert
            Me.serviceSigningCert = other.serviceSigningCert
        End Sub

        Public Property ClientSigningCertificate() As X509Certificate2
            Get
                Return Me.clientSigningCert
            End Get
            Set(ByVal value As X509Certificate2)
                Me.clientSigningCert = value
            End Set
        End Property

        Public Property ClientEncryptingCertificate() As X509Certificate2
            Get
                Return Me.clientEncryptingCert
            End Get
            Set(ByVal value As X509Certificate2)
                Me.clientEncryptingCert = value
            End Set
        End Property

        Public Property ServiceSigningCertificate() As X509Certificate2
            Get
                Return Me.serviceSigningCert
            End Get
            Set(ByVal value As X509Certificate2)
                Me.serviceSigningCert = value
            End Set
        End Property

        Public Property ServiceEncryptingCertificate() As X509Certificate2
            Get
                Return Me.serviceEncryptingCert
            End Get
            Set(ByVal value As X509Certificate2)
                Me.serviceEncryptingCert = value
            End Set
        End Property

        Public Overrides Function CreateSecurityTokenManager() As SecurityTokenManager
            Return New MyClientCredentialsSecurityTokenManager(Me)
        End Function

        Protected Overrides Function CloneCore() As ClientCredentials
            Return New MyClientCredentials(Me)
        End Function

    End Class
    '</snippet1>

    '<snippet2>
    Friend Class MyClientCredentialsSecurityTokenManager
        Inherits ClientCredentialsSecurityTokenManager

        Private credentials As MyClientCredentials

        Public Sub New(ByVal credentials As MyClientCredentials)
            MyBase.New(credentials)
            Me.credentials = credentials
        End Sub

        Public Overrides Function CreateSecurityTokenProvider(ByVal requirement As SecurityTokenRequirement) As SecurityTokenProvider
            Dim result As SecurityTokenProvider = Nothing
            If requirement.TokenType = SecurityTokenTypes.X509Certificate Then
                Dim direction = requirement.GetProperty(Of MessageDirection)(ServiceModelSecurityTokenRequirement.MessageDirectionProperty)
                If direction = MessageDirection.Output Then
                    If requirement.KeyUsage = SecurityKeyUsage.Signature Then
                        result = New X509SecurityTokenProvider(Me.credentials.ClientSigningCertificate)
                    Else
                        result = New X509SecurityTokenProvider(Me.credentials.ServiceEncryptingCertificate)
                    End If
                Else
                    If requirement.KeyUsage = SecurityKeyUsage.Signature Then
                        result = New X509SecurityTokenProvider(Me.credentials.ServiceSigningCertificate)
                    Else
                        result = New X509SecurityTokenProvider(credentials.ClientEncryptingCertificate)
                    End If
                End If
            Else
                result = MyBase.CreateSecurityTokenProvider(requirement)
            End If

            Return result
        End Function

        Public Overrides Function CreateSecurityTokenAuthenticator(ByVal tokenRequirement As SecurityTokenRequirement, _
                                                                   <System.Runtime.InteropServices.Out()> ByRef outOfBandTokenResolver As SecurityTokenResolver) As SecurityTokenAuthenticator
            Return MyBase.CreateSecurityTokenAuthenticator(tokenRequirement, _
                                                           outOfBandTokenResolver)
        End Function

    End Class
    '</snippet2>

    '<snippet3>
    Public Class MyServiceCredentials
        Inherits ServiceCredentials

        Private clientSigningCert As X509Certificate2
        Private clientEncryptingCert As X509Certificate2
        Private serviceSigningCert As X509Certificate2
        Private serviceEncryptingCert As X509Certificate2

        Public Sub New()
        End Sub

        Protected Sub New(ByVal other As MyServiceCredentials)
            MyBase.New(other)
            Me.clientEncryptingCert = other.clientEncryptingCert
            Me.clientSigningCert = other.clientSigningCert
            Me.serviceEncryptingCert = other.serviceEncryptingCert
            Me.serviceSigningCert = other.serviceSigningCert
        End Sub

        Public Property ClientSigningCertificate() As X509Certificate2
            Get
                Return Me.clientSigningCert
            End Get
            Set(ByVal value As X509Certificate2)
                Me.clientSigningCert = value
            End Set
        End Property

        Public Property ClientEncryptingCertificate() As X509Certificate2
            Get
                Return Me.clientEncryptingCert
            End Get
            Set(ByVal value As X509Certificate2)
                Me.clientEncryptingCert = value
            End Set
        End Property

        Public Property ServiceSigningCertificate() As X509Certificate2
            Get
                Return Me.serviceSigningCert
            End Get
            Set(ByVal value As X509Certificate2)
                Me.serviceSigningCert = value
            End Set
        End Property

        Public Property ServiceEncryptingCertificate() As X509Certificate2
            Get
                Return Me.serviceEncryptingCert
            End Get
            Set(ByVal value As X509Certificate2)
                Me.serviceEncryptingCert = value
            End Set
        End Property

        Public Overrides Function CreateSecurityTokenManager() As SecurityTokenManager
            Return New MyServiceCredentialsSecurityTokenManager(Me)
        End Function

        Protected Overrides Function CloneCore() As ServiceCredentials
            Return New MyServiceCredentials(Me)
        End Function

    End Class
    '</snippet3>

    '<snippet4>
    Friend Class MyServiceCredentialsSecurityTokenManager
        Inherits ServiceCredentialsSecurityTokenManager

        Private credentials As MyServiceCredentials

        Public Sub New(ByVal credentials As MyServiceCredentials)
            MyBase.New(credentials)
            Me.credentials = credentials
        End Sub

        Public Overrides Function CreateSecurityTokenProvider(ByVal requirement As SecurityTokenRequirement) As SecurityTokenProvider
            Dim result As SecurityTokenProvider = Nothing
            If requirement.TokenType = SecurityTokenTypes.X509Certificate Then
                Dim direction = requirement.GetProperty(Of MessageDirection)(ServiceModelSecurityTokenRequirement.MessageDirectionProperty)
                If direction = MessageDirection.Input Then
                    If requirement.KeyUsage = SecurityKeyUsage.Exchange Then
                        result = New X509SecurityTokenProvider(credentials.ServiceEncryptingCertificate)
                    Else
                        result = New X509SecurityTokenProvider(credentials.ClientSigningCertificate)
                    End If
                Else
                    If requirement.KeyUsage = SecurityKeyUsage.Signature Then
                        result = New X509SecurityTokenProvider(credentials.ServiceSigningCertificate)
                    Else
                        result = New X509SecurityTokenProvider(credentials.ClientEncryptingCertificate)
                    End If
                End If
            Else
                result = MyBase.CreateSecurityTokenProvider(requirement)
            End If
            Return result
        End Function

    End Class
    '</snippet4>
    <ServiceContract(Namespace:="http://Microsoft.ServiceModel.Security.Samples")> _
    Public Interface IMyService
        <OperationContract()> _
        Function Hello(ByVal value As String) As String
    End Interface

    Public Interface IMyServiceChannel
        Inherits IMyService, IClientChannel
    End Interface

    Public Class Client

        Shared Sub Main(ByVal args() As String)
            '<snippet5>
            Dim serviceEndpoint As New EndpointAddress(New Uri("http://localhost:6060/service"))

            Dim binding As New CustomBinding()

            Dim securityBE = SecurityBindingElement.CreateMutualCertificateDuplexBindingElement(MessageSecurityVersion.WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10)
            ' Add a custom IdentityVerifier because the service uses two certificates 
            ' (one for signing and one for encryption) and an endpoint identity that 
            ' contains a single identity claim.
            securityBE.LocalClientSettings.IdentityVerifier = New MyIdentityVerifier()
            binding.Elements.Add(securityBE)

            Dim compositeDuplex As New CompositeDuplexBindingElement()

            compositeDuplex.ClientBaseAddress = New Uri("http://localhost:6061/client")

            With binding.Elements
                .Add(compositeDuplex)
                .Add(New OneWayBindingElement())
                .Add(New HttpTransportBindingElement())
            End With

            Using factory As New ChannelFactory(Of IMyServiceChannel)(binding, serviceEndpoint)
                Dim credentials As New MyClientCredentials()
                SetupCertificates(credentials)

                With factory.Endpoint.Behaviors
                    .Remove(GetType(ClientCredentials))
                    .Add(credentials)
                End With

                Dim channel = factory.CreateChannel()
                Console.WriteLine(channel.Hello("world"))
                channel.Close()
            End Using
            ' </snippet5>
        End Sub

        Private Shared Sub SetupCertificates(ByVal credentials As MyClientCredentials)
        End Sub

    End Class
    '<snippet6>
    Friend Class MyIdentityVerifier
        Inherits IdentityVerifier

        Private defaultVerifier As IdentityVerifier

        Public Sub New()
            Me.defaultVerifier = IdentityVerifier.CreateDefault()
        End Sub

        Public Overrides Function CheckAccess(ByVal identity As EndpointIdentity, ByVal authContext As AuthorizationContext) As Boolean
            ' The following implementation is for demonstration only, and
            ' does not perform any checks regarding EndpointIdentity.
            ' Do not use this for production code.
            Return True
        End Function

        Public Overrides Function TryGetIdentity(ByVal reference As EndpointAddress, <System.Runtime.InteropServices.Out()> ByRef identity As EndpointIdentity) As Boolean
            Return Me.defaultVerifier.TryGetIdentity(reference, identity)
        End Function

    End Class
    '</snippet6>
    Friend Class Service
        Implements IMyService

        Shared Sub Main(ByVal args() As String)
            '<snippet7>
            Dim serviceEndpoint As New Uri("http://localhost:6060/service")
            Using host As New ServiceHost(GetType(Service), serviceEndpoint)
                Dim binding As New CustomBinding()

                With binding.Elements
                    .Add(SecurityBindingElement.CreateMutualCertificateDuplexBindingElement(MessageSecurityVersion.WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10))
                    .Add(New CompositeDuplexBindingElement())
                    .Add(New OneWayBindingElement())
                    .Add(New HttpTransportBindingElement())
                End With

                Dim credentials As New MyServiceCredentials()
                SetupCertificates(credentials)
                With host.Description.Behaviors
                    .Remove(GetType(ServiceCredentials))
                    .Add(credentials)
                End With

                Dim endpoint = host.AddServiceEndpoint(GetType(IMyService), binding, "")
                host.Open()

                Console.WriteLine("Service started, press ENTER to stop...")
                Console.ReadLine()
            End Using
            '</snippet7>
        End Sub

        Private Shared Sub SetupCertificates(ByVal credentials As MyServiceCredentials)
        End Sub

#Region "IMyService Members"

        Public Function Hello(ByVal value As String) As String Implements IMyService.Hello
            Return "Hello " & value
        End Function

#End Region
    End Class
End Namespace
'</snippet0>
