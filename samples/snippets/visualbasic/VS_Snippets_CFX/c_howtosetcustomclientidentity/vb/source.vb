Imports System.Security.Cryptography.X509Certificates
Imports System.IdentityModel.Claims
Imports System.IdentityModel.Policy
Imports System.ServiceModel
Imports System.ServiceModel.Security
Imports System.ServiceModel.Security.Tokens
Imports System.ServiceModel.Description
Imports System.ServiceModel.Dispatcher
Imports System.ServiceModel.Channels
Imports System.Security.Permissions

Namespace Microsoft.ServiceModel.Samples
    <System.Diagnostics.DebuggerStepThroughAttribute(), _
    System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
    Public Class CalculatorClient
        Inherits System.ServiceModel.ClientBase(Of ICalculator)
        Implements ICalculator

        Shared Sub Main()
            ' ...
        End Sub

        Public Sub New()
        End Sub

        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub

        Public Sub New(ByVal endpointConfigurationName As String, _
                       ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub

        Public Sub New(ByVal endpointConfigurationName As String, _
                       ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub

        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, _
                       ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub

        Public Function Add(ByVal n1 As Double, _
                            ByVal n2 As Double) As Double Implements ICalculator.Add
            Return MyBase.Channel.Add(n1, n2)
        End Function

        Public Function Subtract(ByVal n1 As Double, _
                                 ByVal n2 As Double) As Double Implements ICalculator.Subtract
            Return MyBase.Channel.Subtract(n1, n2)
        End Function

        Public Function Multiply(ByVal n1 As Double, _
                                 ByVal n2 As Double) As Double Implements ICalculator.Multiply
            Return MyBase.Channel.Multiply(n1, n2)
        End Function

        Public Function Divide(ByVal n1 As Double, _
                               ByVal n2 As Double) As Double Implements ICalculator.Divide
            Return MyBase.Channel.Divide(n1, n2)
        End Function

    End Class

    Friend Class Client

        Public Shared Sub CallServiceCustomClientIdentity(ByVal endpointName As String)
            ' Create a custom binding that sets a custom IdentityVerifier. 
            Dim customSecurityBinding = CreateCustomSecurityBinding()
            ' Call the service with DNS identity, setting a custom EndpointIdentity that checks that the certificate
            ' returned from the service contains an organization name of Contoso in the subject name; that is, O=Contoso. 
            Dim serviceAddress As New EndpointAddress(New Uri("http://localhost:8003/servicemodelsamples/service/dnsidentity"), _
                                                      New OrgEndpointIdentity("O=Contoso"))
            '<snippet4>
            Using client As New CalculatorClient(customSecurityBinding, serviceAddress)
                '</snippet4>

                With client.ClientCredentials.ServiceCertificate
                    .SetDefaultCertificate(StoreLocation.CurrentUser, StoreName.TrustedPeople, _
                                           X509FindType.FindBySubjectDistinguishedName, _
                                           "CN=identity.com, O=Contoso")
                    ' Setting the certificateValidationMode to PeerOrChainTrust means that if the certificate 
                    ' is in the user's Trusted People store, then it will be trusted without performing a
                    ' validation of the certificate's issuer chain. This setting is used here for convenience so that the 
                    ' sample can be run without having to have certificates issued by a certificate authority (CA).
                    ' This setting is less secure than the default, ChainTrust. The security implications of this 
                    ' setting should be carefully considered before using PeerOrChainTrust in production code. 
                    .Authentication.CertificateValidationMode = X509CertificateValidationMode.PeerOrChainTrust
                End With

                Console.WriteLine("Calling Endpoint: {0}", endpointName)

                ' Call the Add service operation.
                Dim value1 = 100.0R
                Dim value2 = 15.99R
                Dim result = client.Add(value1, value2)
                Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result)
                Console.WriteLine()

                ' Call the Subtract service operation.
                value1 = 145.0R
                value2 = 76.54R
                result = client.Subtract(value1, value2)
                Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result)
            End Using

        End Sub

        ' Create a custom binding using a WsHttpBinding.
        '<snippet3>
        Public Shared Function CreateCustomSecurityBinding() As Binding
            Dim binding As New WSHttpBinding(SecurityMode.Message)

            With binding.Security.Message
                'Clients are anonymous to the service.
                .ClientCredentialType = MessageCredentialType.None
                'Secure conversation is turned off for simplification. If secure conversation is turned on, then 
                'you also need to set the IdentityVerifier on the secureconversation bootstrap binding.
                .EstablishSecurityContext = False
            End With
            ' Get the SecurityBindingElement and cast to a SymmetricSecurityBindingElement to set the IdentityVerifier.
            Dim outputBec = binding.CreateBindingElements()
            Dim ssbe = CType(outputBec.Find(Of SecurityBindingElement)(), SymmetricSecurityBindingElement)

            'Set the Custom IdentityVerifier.
            ssbe.LocalClientSettings.IdentityVerifier = New CustomIdentityVerifier()

            Return New CustomBinding(outputBec)
        End Function
        '</snippet3>
    End Class

    ' This custom EndpointIdentity stores an organization name as a string value.
    '<snippet6>
    Public Class OrgEndpointIdentity
        Inherits EndpointIdentity
        Private orgClaim As String

        Public Sub New(ByVal orgName As String)
            orgClaim = orgName
        End Sub

        Public Property OrganizationClaim() As String
            Get
                Return orgClaim
            End Get
            Set(ByVal value As String)
                orgClaim = value
            End Set
        End Property
    End Class
    '</snippet6>

    ' This custom IdentityVerifier uses the supplied OrgEndpointIdentity to check that
    ' X.509 certificate's distinguished name claim contains the organization name; for example, O=Contoso. 
    '<snippet5>
    Friend Class CustomIdentityVerifier
        Inherits IdentityVerifier
        '<snippet1>

        Public Overrides Function CheckAccess(ByVal identity As EndpointIdentity, _
                                              ByVal authContext As AuthorizationContext) As Boolean

            Dim returnvalue = False
            For Each claimset In authContext.ClaimSets
                For Each claim In claimset
                    If claim.ClaimType = "http://schemas.microsoft.com/ws/2005/05/identity/claims/x500distinguishedname" Then
                        Dim name = CType(claim.Resource, X500DistinguishedName)
                        If name.Name.Contains((CType(identity, OrgEndpointIdentity)).OrganizationClaim) Then
                            Console.WriteLine("Claim Type: {0}", claim.ClaimType)
                            Console.WriteLine("Right: {0}", claim.Right)
                            Console.WriteLine("Resource: {0}", claim.Resource)
                            Console.WriteLine()
                            returnvalue = True
                        End If
                    End If
                Next claim
            Next claimset
            Return returnvalue

        End Function
        '</snippet1>

        '<snippet2>
        Public Overrides Function TryGetIdentity(ByVal reference As EndpointAddress, _
                                                 <System.Runtime.InteropServices.Out()> ByRef identity As EndpointIdentity) As Boolean
            Return IdentityVerifier.CreateDefault().TryGetIdentity(reference, identity)
        End Function

        '</snippet2>
    End Class
    '</snippet5>

    ' Define a service contract.
    <ServiceContract(Namespace:="http://Microsoft.ServiceModel.Samples")> _
    Public Interface ICalculator

        <OperationContract()> _
        Function Add(ByVal n1 As Double, _
                     ByVal n2 As Double) As Double

        <OperationContract()> _
        Function Subtract(ByVal n1 As Double, _
                          ByVal n2 As Double) As Double

        <OperationContract()> _
        Function Multiply(ByVal n1 As Double, _
                          ByVal n2 As Double) As Double

        <OperationContract()> _
        Function Divide(ByVal n1 As Double, _
                        ByVal n2 As Double) As Double

    End Interface

    ' This service class implements the service contract.
    ' Added code to write output to the console window.
    Public Class CalculatorService
        Implements ICalculator

        Public Function Add(ByVal n1 As Double, _
                            ByVal n2 As Double) As Double Implements ICalculator.Add
            Dim result = n1 + n2
            Console.WriteLine("Received Add({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result
        End Function

        Public Function Subtract(ByVal n1 As Double, _
                                 ByVal n2 As Double) As Double Implements ICalculator.Subtract
            Dim result = n1 - n2
            Console.WriteLine("Received Subtract({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result
        End Function

        Public Function Multiply(ByVal n1 As Double, _
                                 ByVal n2 As Double) As Double Implements ICalculator.Multiply
            Dim result = n1 * n2
            Console.WriteLine("Received Multiply({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result
        End Function

        Public Function Divide(ByVal n1 As Double, _
                               ByVal n2 As Double) As Double Implements ICalculator.Divide
            Dim result = n1 / n2
            Console.WriteLine("Received Divide({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result
        End Function

    End Class
End Namespace

Namespace part2
    '<snippet7>
    Public Class CustomIdentityVerifier
        Inherits IdentityVerifier
        ' Code to be added.

        Public Overrides Function CheckAccess(ByVal identity As EndpointIdentity, _
                                              ByVal authContext As AuthorizationContext) As Boolean
            Throw New Exception("The method or operation is not implemented.")
        End Function

        Public Overrides Function TryGetIdentity(ByVal reference As EndpointAddress, _
                                                 <System.Runtime.InteropServices.Out()> ByRef identity As EndpointIdentity) As Boolean
            Throw New Exception("The method or operation is not implemented.")
        End Function
    End Class
    '</snippet7>
End Namespace
