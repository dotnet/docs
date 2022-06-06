Imports System.ServiceModel
Imports System.Security.Permissions
Imports System.Security.Cryptography.X509Certificates




Public Class Test

    Public Shared Sub Main()
        Try
            Dim t As New Test()
            't.TcpMessageWithCredentialWindows();
            t.AllConfig()
        Catch exc As System.Exception
            Console.WriteLine(exc.Message)
            Console.ReadLine()
        End Try

    End Sub

    Private Sub AllConfig()
        Dim sh As New ServiceHost(GetType(Calculator))
        sh.Open()
        Console.WriteLine("Listening")
        Console.ReadLine()

    End Sub


    Private Sub MakeTransportBinding()
        '<snippet5>
        '<snippet1>
        Dim b As New WSHttpBinding()
        b.Security.Mode = SecurityMode.Transport
        '</snippet1>
        b.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows
        '</snippet5>
    End Sub

    Private Sub MakeMessgeBinding()
        '<snippet6>
        '<snippet2>
        Dim b As New WSHttpBinding()
        b.Security.Mode = SecurityMode.Message
        '</snippet2>
        b.Security.Message.ClientCredentialType = MessageCredentialType.Certificate
        '</snippet6>
    End Sub


    Private Sub TransportWithMessageBinding()
        '<snippet3>
        Dim b As New WSHttpBinding()
        b.Security.Mode = SecurityMode.TransportWithMessageCredential
        '</snippet3>
    End Sub


    Private Sub SetModeViaConstructor()
        '<snippet4>
        Dim b As New WSHttpBinding(SecurityMode.Message)
        '</snippet4>
    End Sub

    Private Sub HttpMessageWithCredential()
        '<snippet7>
        Dim b As New WSHttpBinding()
        b.Security.Mode = SecurityMode.TransportWithMessageCredential
        b.Security.Message.ClientCredentialType = MessageCredentialType.Certificate

        ' The SSL certificate is bound to port 8006 using the HttpCfg.exe tool.
        Dim httpsAddress As New Uri("https://localMachineName:8006/base")
        Dim sh As New ServiceHost(GetType(Calculator), httpsAddress)
        sh.AddServiceEndpoint(GetType(ICalculator), b, "HttpsCalculator")
        sh.Open()
        Console.WriteLine("Listening")
        Console.ReadLine()
        '</snippet7>
    End Sub


    Private Sub TcpMessageWithCredential()
        '<snippet8>
        Dim b As New NetTcpBinding(SecurityMode.TransportWithMessageCredential)
        b.Security.Message.ClientCredentialType = MessageCredentialType.Certificate
        Dim netTcpAdddress As New Uri("net.tcp://baseAddress")
        Dim sh As New ServiceHost(GetType(Calculator), netTcpAdddress)
        sh.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindByIssuerName, "Contoso.com")
        sh.AddServiceEndpoint(GetType(ICalculator), b, "TcpCalculator")
        sh.Open()
        Console.WriteLine("Listening")
        Console.ReadLine()
        '</snippet8>
    End Sub


    Private Sub TcpMessageWithCredentialWindows()
        '<snippet9>
        Dim b As New NetTcpBinding(SecurityMode.TransportWithMessageCredential)
        b.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows
        b.Security.Message.ClientCredentialType = MessageCredentialType.Certificate
        Dim netTcpAdddress As New Uri("net.tcp://Tcp")
        Dim sh As New ServiceHost(GetType(Calculator), netTcpAdddress)
        sh.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindByIssuerName, "Contoso.com")
        sh.AddServiceEndpoint(GetType(ICalculator), b, "TcpCalculator")
        sh.Open()
        Console.WriteLine("Listening")
        Console.ReadLine()
        '</snippet9>
    End Sub
End Class



<ServiceContract()> _
Interface ICalculator
    <OperationContract()> _
    Function Add(ByVal a As Double, ByVal b As Double) As Double
End Interface 'ICalculator


Public Class Calculator
    Implements ICalculator

    Public Function Add(ByVal a As Double, ByVal b As Double) As Double Implements ICalculator.Add
        Return a + b

    End Function
End Class
