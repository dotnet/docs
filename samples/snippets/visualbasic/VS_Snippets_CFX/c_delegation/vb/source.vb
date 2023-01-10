Imports System.ServiceModel.Description
Imports System.ServiceModel.Security
Imports System.ServiceModel
Imports System.Security.Principal
Imports System.Security.Permissions

Namespace SnippetsPart1

    Interface IHelloService
        Function Hello(ByVal message As String) As String
    End Interface


    Friend Class Test

        Shared Sub Main()

        End Sub
    End Class


    <ServiceContract()> _
    Public Interface IHelloContract
        <OperationContract()> _
        Function Hello(ByVal message As String) As String
    End Interface

    '<snippet1>    
    Public Class HelloService
        Implements IHelloService

        <OperationBehavior(Impersonation:=ImpersonationOption.Required)> _
        Public Function Hello(ByVal message As String) As String Implements IHelloService.Hello
            Dim callerWindowsIdentity As WindowsIdentity = ServiceSecurityContext.Current.WindowsIdentity
            If (callerWindowsIdentity Is Nothing) Then
                Throw New InvalidOperationException("The caller cannot be mapped to a Windows identity.")
            End If

            Dim backendServiceAddress As EndpointAddress = New EndpointAddress("http://localhost:8000/ChannelApp")
            ' Any binding that performs Windows authentication of the client can be used.
            Dim channelFactory As ChannelFactory(Of IHelloService) = _
              New ChannelFactory(Of IHelloService)(New NetTcpBinding(), backendServiceAddress)
            Dim channel As IHelloService = channelFactory.CreateChannel()
            Return channel.Hello(message)
        End Function
    End Class
    '</snippet1>

    Public Class RunService

        Private Sub Run()
            '<snippet2>
            ' Create a binding that sets a certificate as the client credential type.
            Dim b As WSHttpBinding = New WSHttpBinding()
            b.Security.Message.ClientCredentialType = MessageCredentialType.Certificate

            ' Create a service host that maps the certificate to a Windows account.
            Dim httpUri As Uri = New Uri("http://localhost/Calculator")
            Dim sh As ServiceHost = New ServiceHost(GetType(HelloService), httpUri)
            sh.Credentials.ClientCertificate.Authentication.MapClientCertificateToWindowsAccount = True
            '</snippet2>
        End Sub

    End Class
End Namespace

