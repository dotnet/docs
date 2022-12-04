
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.ServiceModel.Channels
Imports System.Security.Cryptography.X509Certificates
Imports System.Runtime.Serialization
Imports ClientCalculator

Namespace BasicAuthentication

    Public Class BasicService

        Shared Sub Main()
            Try

                MessageSecurityWithKerberosAuth.MyService.Run()
            Catch ex As System.Exception
                Console.WriteLine(ex.Message)
                'Console.WriteLine(ex.InnerException.Message);
                Console.ReadLine()
            End Try

        End Sub

        Private Sub ClientConstructor()
            '<snippet0>
            Dim cc As New CalculatorClient("EndpointConfigurationName")
            '</snippet0>
        End Sub



        Public Shared Sub Run()
            '<snippet1>
            ' Create the binding.
            Dim binding As New WSHttpBinding()
            binding.Security.Mode = SecurityMode.Transport
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic

            ' Create the URI for the endpoint.
            Dim httpUri As New Uri("https://localhost/Calculator")

            ' Create the service host and add an endpoint.
            Dim myServiceHost As New ServiceHost(GetType(ServiceModel.Calculator), httpUri)
            myServiceHost.AddServiceEndpoint(GetType(ServiceModel.ICalculator), binding, "")

            ' Open the service.
            myServiceHost.Open()
            Console.WriteLine("Listening...")
            Console.WriteLine("Press Enter to exit.")
            Console.ReadLine()

            ' Close the service.
            myServiceHost.Close()
            '</snippet1>
        End Sub

        Public Shared Sub ClientRun()

            '<snippet2>
            ' Create the binding.
            Dim myBinding As New WSHttpBinding()
            myBinding.Security.Mode = SecurityMode.Transport
            myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic

            ' Create the endpoint address. Note that the machine name
            ' must match the subject or DNS field of the X.509 certificate
            ' used to authenticate the service.
            Dim ea As New EndpointAddress("https://machineName/Calculator")

            ' Create the client. The code for the calculator
            ' client is not shown here. See the sample applications
            ' for examples of the calculator code.
            Dim cc As New CalculatorClient(myBinding, ea)

            ' The client must provide a user name and password. The code
            ' to return the user name and password is not shown here. Use
            ' a database to store the user name and passwords, or use the
            ' ASP.NET Membership provider database.
            cc.ClientCredentials.UserName.UserName = ReturnUsername()
            cc.ClientCredentials.UserName.Password = ReturnPassword()

            ' Begin using the client.
            Try
                cc.Open()

                Console.WriteLine(cc.Add(100, 11))
                Console.ReadLine()

                ' Close the client.
                cc.Close()
            Catch tex As TimeoutException
                Console.WriteLine(tex.Message)
                cc.Abort()
            Catch cex As CommunicationException
                Console.WriteLine(cex.Message)
                cc.Abort()
            Finally
                Console.WriteLine("Closed the client")
                Console.ReadLine()
            End Try
            '</snippet2>


        End Sub


        Private Shared Function ReturnUsername() As String
            Return ""

        End Function 'ReturnUsername


        Private Shared Function ReturnPassword() As String
            Return "not"

        End Function 'ReturnPassword
    End Class
End Namespace 'BasicAuthentication
Namespace SecuredUsingWindows
    Public Class WindowsService

        Public Shared Sub Run()
            '<snippet3>
            ' Create the binding.
            Dim binding As New NetTcpBinding()
            binding.Security.Mode = SecurityMode.Transport
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows

            ' Create the URI for the endpoint.
            Dim netTcpUri As New Uri("net.tcp://localhost:8008/Calculator")

            ' Create the service host and add an endpoint.
            Dim myServiceHost As New ServiceHost(GetType(ServiceModel.Calculator), netTcpUri)
            myServiceHost.AddServiceEndpoint(GetType(ServiceModel.ICalculator), binding, "")

            ' Open the service.
            myServiceHost.Open()
            Console.WriteLine("Listening...")
            Console.ReadLine()

            ' Close the service.
            myServiceHost.Close()
            '</snippet3>

        End Sub


        Public Shared Sub RunClient()
            '<snippet4>
            ' Create the binding.
            Dim myBinding As New NetTcpBinding()
            myBinding.Security.Mode = SecurityMode.Transport
            myBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows

            ' Create the endpoint address.
            Dim myEndpointAddress As New EndpointAddress("net.tcp://localhost:8008/Calculator")

            ' Create the client. The code for the calculator client
            ' is not shown here. See the sample applications
            ' for examples of the calculator code.
            Dim cc As New CalculatorClient(myBinding, myEndpointAddress)
            cc.Open()
            ' Begin using the client.
            Try
                cc.Open()

                Console.WriteLine(cc.Add(100, 11))
                Console.ReadLine()

                ' Close the client.
                cc.Close()
            Catch tex As TimeoutException
                Console.WriteLine(tex.Message)
                cc.Abort()
            Catch cex As CommunicationException
                Console.WriteLine(cex.Message)
                cc.Abort()
            Finally
                Console.WriteLine("Closed the client")
                Console.ReadLine()
            End Try
            '</snippet4>

        End Sub

        Private Shared Function ReturnUsername() As String
            Return ""

        End Function 'ReturnUsername


        Private Shared Function ReturnPassword() As String
            Return "not"

        End Function 'ReturnPassword
    End Class
End Namespace 'SecuredUsingWindows
Namespace SecuredByTransportWithAnonymousClient

    Public Class MyService

        Public Shared Sub Run()
            '<snippet5>
            ' Create the binding.
            Dim binding As New WSHttpBinding()
            binding.Security.Mode = SecurityMode.Transport
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None

            ' Create the URI for the endpoint.
            Dim httpUri As New Uri("https://localhost/Calculator")

            ' Create the service host and add an endpoint.
            Dim myServiceHost As New ServiceHost(GetType(ServiceModel.Calculator), httpUri)
            myServiceHost.AddServiceEndpoint(GetType(ServiceModel.ICalculator), binding, "")

            ' Open the service host.
            myServiceHost.Open()
            Console.WriteLine("Press Enter to exit....")
            Console.ReadLine()

            ' Close the service.
            myServiceHost.Close()
            '</snippet5>
        End Sub



        Public Shared Sub RunClient()
            '<snippet6>
            ' Create the binding.
            Dim myBinding As New WSHttpBinding()
            myBinding.Security.Mode = SecurityMode.Transport
            myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None

            ' Create the endpoint address. Note that the machine name
            ' must match the subject or DNS field of the X.509 certificate
            ' used to authenticate the service.
            Dim ea As New EndpointAddress("https://machineName/Calculator")

            ' Create the client. The code for the calculator
            ' client is not shown here. See the sample applications
            ' for examples of the calculator code.
            Dim cc As New CalculatorClient(myBinding, ea)

            ' Begin using the client.
            Try
                cc.Open()

                Console.WriteLine(cc.Add(100, 11))
                Console.ReadLine()

                ' Close the client.
                cc.Close()
            Catch tex As TimeoutException
                Console.WriteLine(tex.Message)
                cc.Abort()
            Catch cex As CommunicationException
                Console.WriteLine(cex.Message)
                cc.Abort()
            Finally
                Console.WriteLine("Closed the client")
                Console.ReadLine()
            End Try
            '</snippet6>
        End Sub
    End Class
End Namespace 'SecuredByTransportWithAnonymousClient

Namespace SecuredTransferUsingCertificates

    Public Class MyService

        Public Shared Sub Run()
            '<snippet7>
            ' Create the binding.
            Dim binding As New WSHttpBinding()
            binding.Security.Mode = SecurityMode.Transport
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate

            ' Create the URI for the endpoint.
            Dim httpUri As New Uri("https://localhost/Calculator")

            ' Create the service and add an endpoint.
            Dim myServiceHost As New ServiceHost(GetType(ServiceModel.Calculator), httpUri)
            myServiceHost.AddServiceEndpoint(GetType(ServiceModel.ICalculator), binding, "")

            ' Open the service.
            myServiceHost.Open()
            Console.WriteLine("Listening...")
            Console.ReadLine()

            ' Close the service.
            myServiceHost.Close()
            '</snippet7>
        End Sub



        Private Sub ClientRun()
            '<snippet14>
            ' Create the binding.
            Dim myBinding As New WSHttpBinding()
            myBinding.Security.Mode = SecurityMode.Transport
            myBinding.Security.Transport.ClientCredentialType = _
                HttpClientCredentialType.Certificate

            ' Create the endpoint address. Note that the machine name
            ' must match the subject or DNS field of the X.509 certificate
            ' used to authenticate the service.
            Dim ea As New EndpointAddress("https://localhost/Calculator")

            ' Create the client. The code for the calculator
            ' client is not shown here. See the sample applications
            ' for examples of the calculator code.
            Dim cc As New CalculatorClient(myBinding, ea)

            ' The client must specify a certificate trusted by the server.
            cc.ClientCredentials.ClientCertificate.SetCertificate( _
            StoreLocation.CurrentUser, StoreName.My, X509FindType.FindBySubjectName, "contoso.com")

            ' Begin using the client.
            Try
                cc.Open()

                Console.WriteLine(cc.Add(100, 11))
                Console.ReadLine()

                ' Close the client.
                cc.Close()
            Catch tex As TimeoutException
                Console.WriteLine(tex.Message)
                cc.Abort()
            Catch cex As CommunicationException
                Console.WriteLine(cex.Message)
                cc.Abort()
            Finally
                Console.WriteLine("Closed the client")
                Console.ReadLine()
            End Try
            '</snippet14>
        End Sub
    End Class
End Namespace 'SecuredTransferUsingCertificates

Namespace SecuredUsingMessageSecurityWithAnonClient

    Public Class SecureService

        Public Shared Sub Run()
            '<snippet8>
            ' Create the binding.
            Dim binding As New WSHttpBinding()
            binding.Security.Mode = SecurityMode.Message
            binding.Security.Message.ClientCredentialType = _
                MessageCredentialType.None

            ' Create the URI for the endpoint.
            Dim httpUri As New Uri("http://localhost/Calculator")

            ' Create the service host and add an endpoint.
            Dim myServiceHost As New ServiceHost(GetType(ServiceModel.Calculator), httpUri)
            myServiceHost.AddServiceEndpoint(GetType(ServiceModel.ICalculator), binding, "")

            ' Specify a certificate to authenticate the service.
            myServiceHost.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, _
            StoreName.My, X509FindType.FindByThumbprint, "00000000000000000000000000000000")

            ' Open the service.
            myServiceHost.Open()
            Console.WriteLine("Listening...")
            Console.ReadLine()

            ' Close the service.
            myServiceHost.Close()
            '</snippet8>
        End Sub

        Private Sub ClientRun()
            '<snippet15>
            ' Create the binding.
            Dim myBinding As New WSHttpBinding()
            myBinding.Security.Mode = SecurityMode.Message
            myBinding.Security.Message.ClientCredentialType = MessageCredentialType.None

            ' Create the endpoint address.
            Dim ea As New EndpointAddress("http://localhost/Calculator")

            ' Create the client.
            Dim cc As New CalculatorClient(myBinding, ea)

            ' Begin using the client.
            Try
                cc.Open()

                Console.WriteLine(cc.Add(100, 11))
                Console.ReadLine()

                ' Close the client.
                cc.Close()
            Catch tex As TimeoutException
                Console.WriteLine(tex.Message)
                cc.Abort()
            Catch cex As CommunicationException
                Console.WriteLine(cex.Message)
                cc.Abort()
            Finally
                Console.WriteLine("Closed the client")
                Console.ReadLine()
            End Try
            '</snippet15>
        End Sub
    End Class
End Namespace 'SecuredUsingMessageSecurityWithAnonClient

Namespace SecuredUsingMessageSecurityWithUsername

    Public Class MyService

        Public Shared Sub Run()
            '<snippet9>
            ' Create the binding.
            Dim binding As New WSHttpBinding()
            binding.Security.Mode = SecurityMode.Message
            binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName

            ' Create the URI for the endpoint.
            Dim httpUri As New Uri("http://localhost/Calculator")

            ' Create the service host.
            Dim myServiceHost As New ServiceHost(GetType(ServiceModel.Calculator), httpUri)
            myServiceHost.AddServiceEndpoint(GetType(ICalculator), binding, "")

            ' Specify a certificate to authenticate the service.
            myServiceHost.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, _
            StoreName.My, X509FindType.FindBySubjectName, "Contoso.com")

            myServiceHost.Open()
            Console.WriteLine("Listening...")
            Console.ReadLine()

            ' Close the service.
            myServiceHost.Close()
            '</snippet9>
        End Sub


        Private Sub ClientRun()
            '<snippet16>
            ' Create the binding.
            Dim myBinding As New WSHttpBinding()
            myBinding.Security.Mode = SecurityMode.Message
            myBinding.Security.Message.ClientCredentialType = _
               MessageCredentialType.UserName

            ' Create the endpoint address.
            Dim ea As New EndpointAddress("http://machineName/Calculator")

            ' Create the client.
            Dim cc As New CalculatorClient(myBinding, ea)

            ' Set the user name and password. The code to
            ' return the user name and password is not shown here. Use
            ' an interface to query the user for the information.
            cc.ClientCredentials.UserName.UserName = ReturnUsername()
            cc.ClientCredentials.UserName.Password = ReturnPassword()

            ' Begin using the client.
            Try
                cc.Open()

                Console.WriteLine(cc.Add(100, 11))
                Console.ReadLine()

                ' Close the client.
                cc.Close()
            Catch tex As TimeoutException
                Console.WriteLine(tex.Message)
                cc.Abort()
            Catch cex As CommunicationException
                Console.WriteLine(cex.Message)
                cc.Abort()
            Finally
                Console.WriteLine("Closed the client")
                Console.ReadLine()
            End Try
            '</snippet16>
        End Sub


        Private Function ReturnUsername() As String
            Return "someone@example.com"

        End Function 'ReturnUsername


        Private Function ReturnPassword() As String
            Return "notReally"

        End Function 'ReturnPassword
    End Class
End Namespace
Namespace SecuredUsingMessageWithCertClient

    Public Class MyService

        Public Shared Sub Run()
            '<snippet10>
            ' Create the binding.
            Dim binding As New WSHttpBinding()
            binding.Security.Mode = SecurityMode.Message
            binding.Security.Message.ClientCredentialType = _
                MessageCredentialType.Certificate

            ' Create the URI for the endpoint.
            Dim httpUri As New Uri("http://localhost/Calculator")

            ' Create the service host.
            Dim myServiceHost As New ServiceHost(GetType(ServiceModel.Calculator), httpUri)
            myServiceHost.AddServiceEndpoint(GetType(ICalculator), binding, "")

            ' Specify a certificate to authenticate the service.
            myServiceHost.Credentials.ServiceCertificate.SetCertificate( _
               StoreLocation.LocalMachine, StoreName.My, _
               X509FindType.FindBySubjectName, "Contoso.com")

            ' Open the service.
            myServiceHost.Open()
            Console.WriteLine("Listening...")
            Console.ReadLine()

            ' Close the service.
            myServiceHost.Close()
            '</snippet10>
        End Sub


        Private Sub ClientRun()
            '<snippet17>
            ' Create the binding.
            Dim myBinding As New WSHttpBinding()
            myBinding.Security.Mode = SecurityMode.Message
            myBinding.Security.Message.ClientCredentialType = _
               MessageCredentialType.Certificate

            ' Create the endpoint address.
            Dim ea As New EndpointAddress("http://machineName/Calculator")

            ' Create the client.
            Dim cc As New CalculatorClient(myBinding, ea)

            ' Specify a certificate to use for authenticating the client.
            cc.ClientCredentials.ClientCertificate.SetCertificate( _
               StoreLocation.CurrentUser, StoreName.My, _
               X509FindType.FindBySubjectName, "Cohowinery.com")

            ' Begin using the client.
            Try
                cc.Open()

                Console.WriteLine(cc.Add(100, 11))
                Console.ReadLine()

                ' Close the client.
                cc.Close()
            Catch tex As TimeoutException
                Console.WriteLine(tex.Message)
                cc.Abort()
            Catch cex As CommunicationException
                Console.WriteLine(cex.Message)
                cc.Abort()
            Finally
                Console.WriteLine("Closed the client")
                Console.ReadLine()
            End Try
            '</snippet17>
        End Sub
    End Class
End Namespace


Namespace SecuredUsingMessageWithWindowsClient

    Public Class MyService

        Public Shared Sub Run()
            '<snippet11>
            ' Create the binding.
            Dim binding As New NetTcpBinding()
            binding.Security.Mode = SecurityMode.Message
            binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows

            ' Create the URI for the endpoint.
            Dim netTcpUri As New Uri("net.tcp://localhost:8008/Calculator")

            ' Crate the service host and add an endpoint.
            Dim myServiceHost As New ServiceHost(GetType(ServiceModel.Calculator), netTcpUri)
            myServiceHost.AddServiceEndpoint(GetType(ICalculator), binding, "")

            ' Open the service.
            myServiceHost.Open()
            Console.WriteLine("Listening ....")
            Console.ReadLine()

            ' Close the service.
            myServiceHost.Close()
            '</snippet11>
        End Sub



        Private Sub ClientRun()
            '<snippet18>
            ' Create the binding.
            Dim myBinding As New NetTcpBinding()
            myBinding.Security.Mode = SecurityMode.Message
            myBinding.Security.Message.ClientCredentialType = MessageCredentialType.Windows

            ' Create the endpoint address.
            Dim ea As New EndpointAddress("net.tcp://machineName:8008/Calculator")

            ' Create the client.
            Dim cc As New CalculatorClient(myBinding, ea)

            ' Begin using the client.
            Try
                cc.Open()

                Console.WriteLine(cc.Add(100, 11))
                Console.ReadLine()

                ' Close the client.
                cc.Close()
            Catch tex As TimeoutException
                Console.WriteLine(tex.Message)
                cc.Abort()
            Catch cex As CommunicationException
                Console.WriteLine(cex.Message)
                cc.Abort()
            Finally
                Console.WriteLine("Closed the client")
                Console.ReadLine()
            End Try
            '</snippet18>
        End Sub
    End Class
End Namespace 'SecuredUsingMessageWithWindowsClient


Namespace MessageSecurityWithKerberosAuth

    Public Class MyService

        Public Shared Sub Run()
            '<snippet12>
            ' Create the service host.
            Dim myServiceHost As New ServiceHost(GetType(ServiceModel.Calculator))

            ' Create the binding.
            Dim binding As New WSHttpBinding()
            binding.Security.Mode = SecurityMode.Message
            binding.Security.Message.ClientCredentialType = _
               MessageCredentialType.Windows

            ' Disable credential negotiation and establishment of the
            ' security context.
            binding.Security.Message.NegotiateServiceCredential = False
            binding.Security.Message.EstablishSecurityContext = False

            ' Create a URI for the endpoint address.
            Dim httpUri As New Uri("http://localhost/Calculator")

            ' Create the EndpointAddress with the SPN for the Identity.
            Dim ea As New EndpointAddress(httpUri, _
            EndpointIdentity.CreateSpnIdentity("service_spn_name"))

            ' Get the contract from the ICalculator interface (not shown here).
            ' See the sample applications for an example of the ICalculator.
            Dim contract As ContractDescription = ContractDescription.GetContract(GetType(ICalculator))

            ' Create a new ServiceEndpoint.
            Dim se As New ServiceEndpoint(contract, binding, ea)

            ' Add the service endpoint to the service.
            myServiceHost.Description.Endpoints.Add(se)

            ' Open the service.
            myServiceHost.Open()
            Console.WriteLine("Listening...")
            Console.ReadLine()

            ' Close the service.
            myServiceHost.Close()
            '</snippet12>
        End Sub



        Private Sub ClientRun()
            '<snippet19>
            ' Create the binding.
            Dim myBinding As New WSHttpBinding()
            myBinding.Security.Mode = SecurityMode.Message
            myBinding.Security.Message.ClientCredentialType = _
               MessageCredentialType.Windows

            ' Disable credential negotiation and the establishment of
            ' a security context.
            myBinding.Security.Message.NegotiateServiceCredential = False
            myBinding.Security.Message.EstablishSecurityContext = False

            ' Create the endpoint address and set the SPN identity.
            ' The SPN must match the identity of the service's SPN.
            ' If using SvcUtil to generate a configuration file, the SPN
            ' will be published as the <servicePrincipalName> element under the
            ' <identity> element.
            Dim ea As New EndpointAddress(New Uri("http://machineName/calculator"), _
            EndpointIdentity.CreateSpnIdentity("service_spn_name"))

            ' Create the client.
            Dim cc As New CalculatorClient(myBinding, ea)

            ' Begin using the client.
            Try
                cc.Open()

                Console.WriteLine(cc.Add(100, 11))
                Console.ReadLine()

                ' Close the client.
                cc.Close()
            Catch tex As TimeoutException
                Console.WriteLine(tex.Message)
                cc.Abort()
            Catch cex As CommunicationException
                Console.WriteLine(cex.Message)
                cc.Abort()
            Finally
                Console.WriteLine("Closed the client")
                Console.ReadLine()
            End Try
            '</snippet19>
        End Sub
    End Class
End Namespace


Namespace SecuredUsingMessageSecurityWithInteroperableCertClient

    Public Class MyService

        Public Shared Sub Run()
            '<snippet13>
            ' Create the binding.
            Dim binding As New WSHttpBinding()
            binding.Security.Mode = SecurityMode.Message
            binding.Security.Message.ClientCredentialType = _
            MessageCredentialType.Certificate
            binding.Security.Message.NegotiateServiceCredential = False
            binding.Security.Message.EstablishSecurityContext = False

            ' Create the URI for the endpoint.
            Dim httpUri As New Uri("http://localhost/Calculator")

            ' Create the service host.
            Dim myServiceHost As New ServiceHost(GetType(ServiceModel.Calculator), httpUri)

            ' Specify a certificate to authenticate the service.
            myServiceHost.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, _
            StoreName.My, X509FindType.FindBySubjectName, "contoso.com")

            ' Add an endpoint to the service.
            myServiceHost.AddServiceEndpoint(GetType(ICalculator), binding, "")

            ' Open the service.
            myServiceHost.Open()
            Console.WriteLine("Listening...")
            Console.ReadLine()

            ' Close the service.
            myServiceHost.Close()
            '</snippet13>
        End Sub


        Private Sub ClientRun()
            '<snippet20>
            ' Create the binding.
            Dim myBinding As New WSHttpBinding()
            myBinding.Security.Mode = SecurityMode.Message
            myBinding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate

            ' Disable credential negotiation and the establishment of
            ' a security context.
            myBinding.Security.Message.NegotiateServiceCredential = False
            myBinding.Security.Message.EstablishSecurityContext = False

            ' Create the endpoint address.
            Dim ea As New EndpointAddress("http://localhost/Calculator")

            ' Create the client.
            Dim cc As New CalculatorClient(myBinding, ea)

            ' Specify a certificate to use for authenticating the client.
            cc.ClientCredentials.ClientCertificate.SetCertificate( _
                StoreLocation.CurrentUser, StoreName.My, _
                X509FindType.FindBySubjectName, "Cohowinery.com")

            ' Specify a default certificate for the service.
            cc.ClientCredentials.ServiceCertificate.SetDefaultCertificate( _
                StoreLocation.CurrentUser, StoreName.TrustedPeople, _
                X509FindType.FindBySubjectName, "Contoso.com")

            ' Begin using the client.
            Try
                cc.Open()

                Console.WriteLine(cc.Add(100, 11))
                Console.ReadLine()

                ' Close the client.
                cc.Close()
            Catch tex As TimeoutException
                Console.WriteLine(tex.Message)
                cc.Abort()
            Catch cex As CommunicationException
                Console.WriteLine(cex.Message)
                cc.Abort()
            Finally
                Console.WriteLine("Closed the client")
                Console.ReadLine()
            End Try
            '</snippet20>
        End Sub
    End Class
End Namespace

Namespace ServiceModel
    <ServiceContract()> _
    Interface ICalculator
        <OperationContract()> _
        Function Add(ByVal a As Double, ByVal b As Double) As Double
    End Interface



    Public Class Calculator
        Implements ICalculator

        Public Function Add(ByVal a As Double, ByVal b As Double) As Double Implements ICalculator.Add
            Return a + b

        End Function
    End Class


    Public Class Utility

        Public Shared Sub EnableMex(ByRef sh As ServiceHost)
            Dim sb As New ServiceMetadataBehavior()
            sb.HttpGetEnabled = True
            sb.HttpGetUrl = New Uri("http://localhost:8008/metadata")
            sh.Description.Behaviors.Add(sb)

        End Sub
    End Class
End Namespace 'ServiceModel

Namespace ClientCalculator
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"), System.ServiceModel.ServiceContractAttribute(ConfigurationName:="ICalculator")> _
    Public Interface ICalculator

        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ICalculator/Add", ReplyAction:="http://tempuri.org/ICalculator/AddResponse")> _
        Function Add(ByVal a As Double, ByVal b As Double) As Double
    End Interface 'ICalculator

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
    Public Interface ICalculatorChannel
        : Inherits ICalculator, System.ServiceModel.IClientChannel
    End Interface 'ICalculatorChannel
End Namespace 'ClientCalculator


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


    Public Sub New(ByVal endpointConfigurationName As String, _
    ByVal remoteAddress As System.ServiceModel.EndpointAddress)
        MyBase.New(endpointConfigurationName, remoteAddress)

    End Sub


    Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, _
    ByVal remoteAddress As System.ServiceModel.EndpointAddress)
        MyBase.New(binding, remoteAddress)

    End Sub


    Public Function Add(ByVal a As Double, ByVal b As Double) As Double Implements ICalculator.Add
        Return MyBase.Channel.Add(a, b)

    End Function
End Class
