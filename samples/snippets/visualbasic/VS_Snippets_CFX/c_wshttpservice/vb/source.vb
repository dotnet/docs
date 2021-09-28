
Imports System.Collections.Generic
Imports System.Security.Cryptography.X509Certificates
Imports System.ServiceModel
Imports System.ServiceModel.Security
Imports System.Text



Class Service

    Private Sub Basic()
        '<snippet1>
        Dim b As New WSHttpBinding()
        b.Name = "myBinding"
        b.Security.Mode = SecurityMode.Message
        b.Security.Message.ClientCredentialType = MessageCredentialType.Windows
        '</snippet1>
    End Sub


    Private Sub Basic2()
        '<snippet2>
        Dim b As New WSHttpBinding()
        b.Security.Mode = SecurityMode.Transport
        b.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows
        Dim httpAddress As String = "https://ComputerName:8012/SecureTransport"
        Dim baseUri As New Uri(httpAddress)
        Dim baseAddresses() As Uri = {baseUri}
        Dim serviceType As Type = GetType(ICalculator)
        Dim myServiceHost As New ServiceHost(GetType(Calculator), baseAddresses)
        myServiceHost.AddServiceEndpoint(serviceType, b, "myEndpoint")
        myServiceHost.Open()
        '</snippet2>
    End Sub
    Private Sub WSHttpTransportCert()
        '<snippet3>
        ' This string uses a function to prepend the computer name at run time.
        Dim addressHttp As String = String.Format("http://{0}:8080/Calculator", _
        System.Net.Dns.GetHostEntry("").HostName)

        Dim b As New WSHttpBinding()
        b.Security.Mode = SecurityMode.Transport
        b.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate

        ' You must create an array of URI objects to have a base address.
        Dim a As New Uri(addressHttp)
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
        '</snippet3>
    End Sub
End Class

<ServiceContract()> _
Interface ICalculator
    <OperationContract()> _
    Function Divide(ByVal a As Double, ByVal b As Double) As Double
End Interface


Public Class Calculator
    Implements ICalculator

    Public Function Divide(ByVal a As Double, ByVal b As Double) As Double Implements ICalculator.Divide
        Return a / b
    End Function
End Class
