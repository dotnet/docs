'<snippet0>
Imports System.ServiceModel
Imports System.ServiceModel.Security
Imports System.Security.Cryptography.X509Certificates
'</snippet0>

Class Test

    Shared Sub Main(ByVal args() As String)
        Try
            Dim t As New Test()
            t.TcpTransportCert()
        Catch iexc As InvalidOperationException
            Console.WriteLine(iexc.Message)
            Console.ReadLine()
        Catch exc As System.Exception
            Console.WriteLine(exc.Message)
            Console.ReadLine()
        End Try

    End Sub


    Private Sub TcpTransportCert()
        '<snippet1>
        ' This string uses a function to prepend the computer name at run time.
        Dim addressTCP As String = String.Format("net.tcp://{0}:8036/Calculator", _
        System.Net.Dns.GetHostEntry("").HostName)

        Dim b As New NetTcpBinding()
        b.Security.Mode = SecurityMode.Transport
        b.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate

        ' You must create an array of URI objects to have a base address.
        Dim a As New Uri(addressTCP)
        Dim baseAddresses() As Uri = {a}

        ' Create the ServiceHost. The service type (Calculator) is not
        ' shown here.
        Dim sh As New ServiceHost(GetType(Calculator), baseAddresses)

        ' Add an endpoint to the service. Insert the thumbprint of an X.509 
        ' certificate found on your computer. 
        Dim c As Type = GetType(ICalculator)
        sh.AddServiceEndpoint(c, b, "MyCalculator")
        sh.Credentials.ServiceCertificate.SetCertificate( _
                        StoreLocation.LocalMachine, _
                        StoreName.My, _
                        X509FindType.FindBySubjectName, _
                        "contoso.com")

        ' This next line is optional. It specifies that the client's certificate
        ' does not have to be issued by a trusted authority, but can be issued
        ' by a peer if it is in the Trusted People store. Do not use this setting
        ' for production code. The default is PeerTrust, which specifies that 
        ' the certificate must originate from a trusted certificate authority.
        ' sh.Credentials.ClientCertificate.Authentication.CertificateValidationMode =
        ' X509CertificateValidationMode.PeerOrChainTrust
        Try
            sh.Open()

            Dim address As String = sh.Description.Endpoints(0).ListenUri.AbsoluteUri
            Console.WriteLine("Listening @ {0}", address)
            Console.WriteLine("Press enter to close the service")
            Console.ReadLine()
            sh.Close()
        Catch ce As CommunicationException
            Console.WriteLine("A communication error occurred: {0}", ce.Message)
            Console.WriteLine()
        Catch exc As System.Exception
            Console.WriteLine("An unforeseen error occurred: {0}", exc.Message)
            Console.ReadLine()
        End Try
        '</snippet1>
    End Sub

    Private Sub TcpMessageCert()
        '<snippet2>
        ' This string uses a function to prepend the computer name at run time.
        Dim addressTCP As String = String.Format( _
        "net.tcp://{0}:8036/Calculator", System.Net.Dns.GetHostEntry("").HostName)

        ' Create an instance of the NetTcpBinding and set its security mode to Message.
        Dim b As New NetTcpBinding()
        b.Security.Mode = SecurityMode.Message

        ' Specify that the client must authenticate itself using an X.509 certificate.
        b.Security.Message.ClientCredentialType = MessageCredentialType.Certificate
        Dim a As New Uri(addressTCP)
        Dim baseAddresses() As Uri = {a}

        ' Create the ServiceHost. The service type (Calculator) is not
        ' shown here.
        Dim sh As New ServiceHost(GetType(Calculator), baseAddresses)

        ' Add an endpoint to the service. The code to define the service 
        ' type (ICalculator) is not shown here. The code also requires 
        ' you to insert the thumbprint of an X.509 certificate on your
        ' computer. The SetCertificate method specifies where the certificate
        ' is stored, and how to find it, as well as the value to find.
        Dim c As Type = GetType(ICalculator)
        sh.AddServiceEndpoint(c, b, "MyCalculator")
        Try
            sh.Credentials.ServiceCertificate.SetCertificate( _
                        StoreLocation.LocalMachine, _
                        StoreName.My, _
                        X509FindType.FindBySubjectName, _
                        "contoso.com")
            sh.Open()

            Dim address As String = sh.Description.Endpoints(0).ListenUri.AbsoluteUri
            Console.WriteLine("Listening @ {0}", address)
            Console.WriteLine("Press enter to close the service")
            Console.ReadLine()
            sh.Close()
        Catch ce As CommunicationException
            Console.WriteLine("A communication error occurred: {0}", ce.Message)
            Console.WriteLine()
        Catch exc As System.Exception
            Console.WriteLine("An unforeseen error occurred: {0}", exc.Message)
            Console.ReadLine()
        End Try
        '</snippet2>

    End Sub


    Private Sub BasicTCPMessage()
        '<snippet3>
        ' Create the binding for an endpoint.
        Dim b As New NetTcpBinding()
        b.Security.Mode = SecurityMode.Message

        ' Create the ServiceHost for a calculator.
        Dim baseUri As New Uri("net.tcp://MachineName/tcpBase")
        Dim baseAddresses() As Uri = {baseUri}
        Dim sh As New ServiceHost(GetType(Calculator), baseAddresses)

        ' Add an endpoint using the binding and a new address.
        Dim c As Type = GetType(ICalculator)
        sh.AddServiceEndpoint(c, b, "MyEndpoint")

        ' Set a certificate as the credential for the service.
        sh.Credentials.ServiceCertificate.SetCertificate( _
                        StoreLocation.LocalMachine, _
                        StoreName.My, _
                        X509FindType.FindBySubjectName, _
                        "contoso.com")
        Try
            sh.Open()
            Console.WriteLine("Listening....")
            Console.ReadLine()
            sh.Close()
        Catch ce As CommunicationException
            Console.WriteLine("A communication error occurred: {0}", ce.Message)
            Console.WriteLine()
        Catch exc As System.Exception
            Console.WriteLine("An unforeseen error occurred: {0}", exc.Message)
            Console.ReadLine()
        End Try
        '</snippet3>
    End Sub

    Private Sub RunClient()
        '<snippet4>
        ' Create a binding using Transport and a certificate.
        Dim b As New NetTcpBinding()
        b.Security.Mode = SecurityMode.Transport
        b.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate

        ' Create an EndPointAddress.
        Dim ea As New EndpointAddress("net.tcp://localHost:8036/Calculator/MyCalculator")

        ' Create the client.
        Dim cc As New CalculatorClient(b, ea)

        ' Set the certificate for the client.
        cc.ClientCredentials.ClientCertificate.SetCertificate( _
        StoreLocation.LocalMachine, StoreName.My, X509FindType.FindBySubjectName, "cohowinery.com")
        Try
            cc.Open()
            ' Begin using the client.
            Console.WriteLine(cc.Divide(1001, 2))
            cc.Close()
        Catch adExc As AddressAccessDeniedException
            Console.WriteLine(adExc.Message)
            Console.ReadLine()
        Catch exc As System.Exception
            Console.WriteLine(exc.Message)
            Console.ReadLine()
        End Try
        '</snippet4>
    End Sub



End Class



Public Class Calculator
    Implements ICalculator
    Public Function Divide(ByVal a As Double, ByVal b As Double) As Double Implements ICalculator.Divide
        Return a / b

    End Function

    Public Function CalculateTax(ByVal a As Double) As Double Implements ICalculator.CalculateTax

        Return a * 1.0862

    End Function
End Class


'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.42
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------


<System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"), System.ServiceModel.ServiceContractAttribute(ConfigurationName:="ICalculator")> _
Public Interface ICalculator

    <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ICalculator/Divide", ReplyAction:="http://tempuri.org/ICalculator/DivideResponse")> _
    Function Divide(ByVal a As Double, ByVal b As Double) As Double

    <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ICalculator/CalculateTax", ReplyAction:="http://tempuri.org/ICalculator/CalculateTaxResponse")> _
    Function CalculateTax(ByVal a As Double) As Double
End Interface 'ICalculator

<System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
Public Interface ICalculatorChannel
    : Inherits ICalculator, System.ServiceModel.IClientChannel
End Interface



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


    Public Function Divide(ByVal a As Double, ByVal b As Double) As Double _
    Implements ICalculator.Divide
        Return MyBase.Channel.Divide(a, b)

    End Function 'Divide


    Public Function CalculateTax(ByVal a As Double) As Double _
    Implements ICalculator.CalculateTax
        Return MyBase.Channel.CalculateTax(a)

    End Function 'CalculateTax
End Class
