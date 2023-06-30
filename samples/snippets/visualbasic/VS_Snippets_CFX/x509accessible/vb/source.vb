
Imports System.Security.Cryptography.X509Certificates
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports Project.ClientCalculator

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


        Public Shared Sub Run()

            ' Create the binding.
            Dim binding As New WSHttpBinding()
            binding.Security.Mode = SecurityMode.Transport
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic

            ' Create the URI for the endpoint.
            Dim httpUri As New Uri("https://localhost:8006/Calculator")

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

        End Sub

        Public Shared Sub ClientRun()


            ' Create the binding.
            Dim myBinding As New WSHttpBinding()
            myBinding.Security.Mode = SecurityMode.Transport
            myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic

            ' Create the endpoint address. Note that the machine name must
            ' must match the subject or DNS field of the X.509 certificate
            ' used to authenticate the service.
            Dim ea As New EndpointAddress("https://machineName:8006/Calculator")

            ' Create the client. The code for the calculator
            ' client is not shown here. See the sample applications
            ' for examples of the calculator code.
            Dim cc As New CalculatorClient(myBinding, ea)

            ' The client must provide a username and password. The code
            ' to return the username and password is not shown here. Use
            ' a database to store the username and passwords, or use the
            ' ASP.NET Membership provider database.
            cc.ClientCredentials.UserName.UserName = ReturnUsername()
            cc.ClientCredentials.UserName.Password = ReturnPassword()

            ' Begin using the client.
            cc.Open()

            Console.WriteLine(cc.Add(100, 11))
            Console.ReadLine()

            ' Close the client.
            cc.Close()


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


        End Sub


        Public Shared Sub RunClient()

            ' Create the binding.
            Dim myBinding As New NetTcpBinding()
            myBinding.Security.Mode = SecurityMode.Transport
            myBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows

            ' Create the endpoint address.
            Dim myEndpointAddress As New EndpointAddress("net.tcp://localhost:8008/Calculator")

            ' Create the client. The code for the calculator is not
            ' shown here. client is not shown here. See the sample applications
            ' for examples of the calculator code.
            Dim cc As New CalculatorClient(myBinding, myEndpointAddress)
            cc.Open()

            ' Begin using the client.
            Console.WriteLine(cc.Add(100, 11))
            Console.ReadLine()

            ' Close the client.
            cc.Close()


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

            ' Create the binding.
            Dim binding As New WSHttpBinding()
            binding.Security.Mode = SecurityMode.Transport
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None

            ' Create the URI for the endpoint.
            Dim httpUri As New Uri("https://localhost:8006/Calculator")

            ' Create the service host and add an endpoint.
            Dim myServiceHost As New ServiceHost(GetType(ServiceModel.Calculator), httpUri)
            myServiceHost.AddServiceEndpoint(GetType(ServiceModel.ICalculator), binding, "")

            ' Open the service host.
            myServiceHost.Open()
            Console.WriteLine("Press Enter to exit....")
            Console.ReadLine()

            ' Close the service.
            myServiceHost.Close()

        End Sub



        Public Shared Sub RunClient()

            ' Create the binding.
            Dim myBinding As New WSHttpBinding()
            myBinding.Security.Mode = SecurityMode.Transport
            myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None

            ' Create the endpoint address. Note that the machine name must
            ' must match the subject or DNS field of the X.509 certificate
            ' used to authenticate the service.
            Dim ea As New EndpointAddress("https://machineName:8006/Calculator")

            ' Create the client. The code for the calculator
            ' client is not shown here. See the sample applications
            ' for examples of the calculator code.
            Dim cc As New CalculatorClient(myBinding, ea)

            ' Begin using the client.
            cc.Open()
            Console.WriteLine(cc.Add(100, 1111))

            ' Close the client.
            cc.Close()

        End Sub
    End Class
End Namespace 'SecuredByTransportWithAnonymousClient

Namespace SecuredTransferUsingCertificates

    Public Class MyService

        Public Shared Sub Run()

            ' Create the binding. The service needs a valid certificate
            ' attached to port 8006. The client also needs a valid certificate.
            Dim binding As New WSHttpBinding()
            binding.Security.Mode = SecurityMode.Transport
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate

            ' Create the URI for the endpoint.
            Dim httpUri As New Uri("https://localhost:8006/Calculator")

            ' Create the service and add an endpoint.
            Dim myServiceHost As New ServiceHost(GetType(ServiceModel.Calculator), httpUri)
            myServiceHost.AddServiceEndpoint(GetType(ServiceModel.ICalculator), binding, "")

            ' Open the service.
            myServiceHost.Open()
            Console.WriteLine("Listening...")
            Console.ReadLine()

            ' Close the service.
            myServiceHost.Close()

        End Sub



        Private Sub ClientRun()

            ' Create the binding.
            Dim myBinding As New WSHttpBinding()
            myBinding.Security.Mode = SecurityMode.Transport
            myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate

            ' Create the endpoint address. Note that the machine name must
            ' must match the subject or DNS field of the X.509 certificate
            ' used to authenticate the service.
            Dim ea As New EndpointAddress("https://localhost:8006/Calculator")

            ' Create the client. The code for the calculator
            ' client is not shown here. See the sample applications
            ' for examples of the calculator code.
            Dim cc As New CalculatorClient(myBinding, ea)

            ' The client must specify a certificate trusted by the server.
            ' <snippet1>
            cc.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.My, X509FindType.FindBySubjectName, "contoso.com")
            ' </snippet1>
            ' Begin using the client.
            Console.WriteLine(cc.Add(100, 1111))
            cc.Open()

            ' Close the client.
            cc.Close()

        End Sub
    End Class
End Namespace 'SecuredTransferUsingCertificates

Namespace SecuredUsingMessageSecurityWithAnonClient

    Public Class SecureService

        Public Shared Sub Run()

            ' Create the binding.
            Dim binding As New WSHttpBinding()
            binding.Security.Mode = SecurityMode.Message
            binding.Security.Message.ClientCredentialType = MessageCredentialType.None

            ' Create the URI for the endpoint.
            Dim httpUri As New Uri("http://localhost:90/Calculator")

            ' Create the service host and add an endpoint.
            Dim myServiceHost As New ServiceHost(GetType(ServiceModel.Calculator), httpUri)
            myServiceHost.AddServiceEndpoint(GetType(ServiceModel.ICalculator), binding, "")

            ' Specify a certificate to authenticate the service.
            myServiceHost.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindByThumbprint, "00000000000000000000000000000000")

            ' Open the service.
            myServiceHost.Open()
            Console.WriteLine("Listening...")
            Console.ReadLine()

            ' Close the service.
            myServiceHost.Close()

        End Sub



        Private Sub ClientRun()

            ' Create the binding.
            Dim myBinding As New WSHttpBinding()
            myBinding.Security.Mode = SecurityMode.Message
            myBinding.Security.Message.ClientCredentialType = MessageCredentialType.None

            ' Create the endpoint address.
            Dim ea As New EndpointAddress("http://localhost:90/Calculator")

            ' Create the client.
            Dim cc As New CalculatorClient(myBinding, ea)

            ' Begin using the client.
            cc.Open()
            Console.WriteLine(cc.Add(200, 1111))
            Console.ReadLine()

            ' Close the client.
            cc.Close()

        End Sub
    End Class
End Namespace 'SecuredUsingMessageSecurityWithAnonClient

Namespace SecuredUsingMessageSecurityWithUsername

    Public Class MyService

        Public Shared Sub Run()

            ' Create the binding.
            Dim binding As New WSHttpBinding()
            binding.Security.Mode = SecurityMode.Message
            binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName

            ' Create the URI for the endpoint.
            Dim httpUri As New Uri("http://localhost:90/Calculator")

            ' Create the service host.
            Dim myServiceHost As New ServiceHost(GetType(ServiceModel.Calculator), httpUri)
            myServiceHost.AddServiceEndpoint(GetType(ICalculator), binding, "")

            ' Specify a certificate to authenticate the service.
            myServiceHost.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindBySubjectName, "Contoso.com")

            myServiceHost.Open()
            Console.WriteLine("Listening...")
            Console.ReadLine()

            ' Close the service.
            myServiceHost.Close()

        End Sub


        Private Sub ClientRun()

            ' Create the binding.
            Dim myBinding As New WSHttpBinding()
            myBinding.Security.Mode = SecurityMode.Message
            myBinding.Security.Message.ClientCredentialType = MessageCredentialType.UserName

            ' Create the endpoint address.
            Dim ea As New EndpointAddress("http://localhost:90/Calculator")

            ' Create the client.
            Dim cc As New CalculatorClient(myBinding, ea)

            ' Set the username and password. The code to
            ' return the username and password is not shown here. Use
            ' an interface to query the user for the information.
            cc.ClientCredentials.UserName.UserName = ReturnUsername()
            cc.ClientCredentials.UserName.Password = ReturnPassword()

            ' Begin using the client.
            cc.Open()
            Console.WriteLine(cc.Add(200, 1111))
            Console.ReadLine()

            ' Close the client.
            cc.Close()

        End Sub


        Private Function ReturnUsername() As String
            Return "someone@example.com"

        End Function 'ReturnUsername


        Private Function ReturnPassword() As String
            Return "notReally"

        End Function 'ReturnPassword
    End Class
End Namespace 'SecuredUsingMessageSecurityWithUsername
Namespace SecuredUsingMessageWithCertClient

    Public Class MyService

        Public Shared Sub Run()

            ' Create the binding.
            Dim binding As New WSHttpBinding()
            binding.Security.Mode = SecurityMode.Message
            binding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate

            ' Create the URI for the endpoint.
            Dim httpUri As New Uri("http://localhost:90/Calculator")

            ' Create the service host.
            Dim myServiceHost As New ServiceHost(GetType(ServiceModel.Calculator), httpUri)
            myServiceHost.AddServiceEndpoint(GetType(ICalculator), binding, "")

            ' Specify a certificate to authenticate the service.
            myServiceHost.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindBySubjectName, "Contoso.com")

            ' Open the service.
            myServiceHost.Open()
            Console.WriteLine("Listening...")
            Console.ReadLine()

            ' Close the service.
            myServiceHost.Close()

        End Sub


        Private Sub ClientRun()

            ' Create the binding.
            Dim myBinding As New WSHttpBinding()
            myBinding.Security.Mode = SecurityMode.Message
            myBinding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate

            ' Create the endpoint address.
            Dim ea As New EndpointAddress("http://localhost:90/Calculator")

            ' Create the client.
            Dim cc As New CalculatorClient(myBinding, ea)

            ' Specify a certificate to use for authenticating the client.
            cc.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.My, X509FindType.FindBySubjectName, "Contoso.com")

            ' Begin using the client.
            cc.Open()
            Console.WriteLine(cc.Add(200, 1111))
            Console.ReadLine()

            ' Close the client.
            cc.Close()

        End Sub
    End Class
End Namespace 'SecuredUsingMessageWithCertClient


Namespace SecuredUsingMessageWithWindowsClient

    Public Class MyService

        Public Shared Sub Run()

            ' Create the binding.
            Dim binding As New NetTcpBinding()
            binding.Security.Mode = SecurityMode.Message
            binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows

            ' Create the URI for the endpoint.
            Dim netTcpUri As New Uri("net.tcp://localhost:8006/Calculator")

            ' Crate the service host and add an endpoint.
            Dim myServiceHost As New ServiceHost(GetType(ServiceModel.Calculator), netTcpUri)
            myServiceHost.AddServiceEndpoint(GetType(ICalculator), binding, "")

            ' Open the service.
            myServiceHost.Open()
            Console.WriteLine("Listening ....")
            Console.ReadLine()

            ' Close the service.
            myServiceHost.Close()

        End Sub



        Private Sub ClientRun()

            ' Create the binding.
            Dim myBinding As New WSHttpBinding()
            myBinding.Security.Mode = SecurityMode.Message
            myBinding.Security.Message.ClientCredentialType = MessageCredentialType.Windows

            ' Create the endpoint address.
            Dim ea As New EndpointAddress("http://localhost:90/Calculator")

            ' Create the client.
            Dim cc As New CalculatorClient(myBinding, ea)

            ' Begin using the client.
            cc.Open()
            Console.WriteLine(cc.Add(200, 1111))
            Console.ReadLine()

            ' Close the client.
            cc.Close()

        End Sub
    End Class
End Namespace 'SecuredUsingMessageWithWindowsClient


Namespace MessageSecurityWithKerberosAuth

    Public Class MyService

        Public Shared Sub Run()

            ' Create the service host.
            Dim myServiceHost As New ServiceHost(GetType(ServiceModel.Calculator))

            ' Create the binding.
            Dim binding As New WSHttpBinding()
            binding.Security.Mode = SecurityMode.Message
            binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows

            ' Disable credential negotiation and establishment of the
            ' security context.
            binding.Security.Message.NegotiateServiceCredential = False
            binding.Security.Message.EstablishSecurityContext = False

            ' Create a URI for the endpoint address.
            Dim httpUri As New Uri("http://localhost:8006/Calculator")

            ' Create the EndpointAddress with the SPN for the Identity.
            Dim ea As New EndpointAddress(httpUri, EndpointIdentity.CreateSpnIdentity("service_spn_name"))

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

        End Sub



        Private Sub ClientRun()

            ' Create the binding.
            Dim myBinding As New WSHttpBinding()
            myBinding.Security.Mode = SecurityMode.Message
            myBinding.Security.Message.ClientCredentialType = MessageCredentialType.Windows

            ' Disable credential negotiation and the establishment of
            ' a security context.
            myBinding.Security.Message.NegotiateServiceCredential = False
            myBinding.Security.Message.EstablishSecurityContext = False

            ' Create the endpoint address and set the SPN identity.
            ' The SPN must match the identity of the service's SPN.
            ' If using SvcUtil to generate a configuration file, the SPN
            ' will be published as the <servicePrincipalName> element under the
            ' <identity> element.
            Dim ea As New EndpointAddress(New Uri("http://localhost:8006/calculator"), EndpointIdentity.CreateSpnIdentity("service_spn_name"))

            ' Create the client.
            Dim cc As New CalculatorClient(myBinding, ea)

            ' Begin using the client.
            cc.Open()
            Console.WriteLine(cc.Add(200, 1111))
            Console.ReadLine()

            ' Close the client.
            cc.Close()

        End Sub
    End Class
End Namespace 'MessageSecurityWithKerberosAuth


Namespace SecuredUsingMessageSecurityWithInteroperableCertClient

    Public Class MyService

        Public Shared Sub Run()

            ' Create the binding.
            Dim binding As New WSHttpBinding()
            binding.Security.Mode = SecurityMode.Message
            binding.Security.Message.ClientCredentialType =
            MessageCredentialType.Certificate
            binding.Security.Message.NegotiateServiceCredential = False
            binding.Security.Message.EstablishSecurityContext = False

            ' Create the URI for the endpoint.
            Dim httpUri As New Uri("http://localhost:8006/Calculator")

            ' Create the service host.
            Dim myServiceHost As New ServiceHost(GetType(ServiceModel.Calculator), httpUri)

            ' Specify a certificate to authenticate the service.
            myServiceHost.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindBySubjectName, "contoso.com")

            ' Add an endpoint to the service.
            myServiceHost.AddServiceEndpoint(GetType(ICalculator), binding, "")

            ' Open the service.
            myServiceHost.Open()
            Console.WriteLine("Listening...")
            Console.ReadLine()

            ' Close the service.
            myServiceHost.Close()

        End Sub


        Private Sub ClientRun()

            ' Create the binding.
            Dim myBinding As New WSHttpBinding()
            myBinding.Security.Mode = SecurityMode.Message
            myBinding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate

            ' Disable credential negotiation and the establishment of
            ' a security context.
            myBinding.Security.Message.NegotiateServiceCredential = False
            myBinding.Security.Message.EstablishSecurityContext = False

            ' Create the endpoint address.
            Dim ea As New EndpointAddress("http://localhost:90/Calculator")

            ' Create the client.
            Dim cc As New CalculatorClient(myBinding, ea)

            ' Specify a certificate to use for authenticating the client.
            cc.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.My, X509FindType.FindBySubjectName, "Contoso.com")

            ' Specify a default certificate for the service.
            cc.ClientCredentials.ServiceCertificate.SetDefaultCertificate(StoreLocation.CurrentUser, StoreName.TrustedPeople, X509FindType.FindBySubjectName, "cohowinery.com")

            ' Begin using the client.
            cc.Open()
            Console.WriteLine(cc.Add(200, 1111))
            Console.ReadLine()

            ' Close the client.
            cc.Close()

        End Sub
    End Class
End Namespace

Namespace ServiceModel
    <ServiceContract()>
    Interface ICalculator
        <OperationContract()>
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
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"), System.ServiceModel.ServiceContractAttribute(ConfigurationName:="ICalculator")>
    Public Interface ICalculator

        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ICalculator/Add", ReplyAction:="http://tempuri.org/ICalculator/AddResponse")>
        Function Add(ByVal a As Double, ByVal b As Double) As Double
    End Interface 'ICalculator

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")>
    Public Interface ICalculatorChannel
        Inherits ICalculator, System.ServiceModel.IClientChannel
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


    Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
        MyBase.New(endpointConfigurationName, remoteAddress)

    End Sub


    Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
        MyBase.New(binding, remoteAddress)

    End Sub


    Public Function Add(ByVal a As Double, ByVal b As Double) As Double Implements ICalculator.Add
        Return MyBase.Channel.Add(a, b)

    End Function
End Class
